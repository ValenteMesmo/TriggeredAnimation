﻿using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System;
using System.Threading;

namespace ConvertAnimationsFromXml
{
    public class Program
    {
        public  static void Main(string[] args)
        {
            Run();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            Watch(currentDir.FullName);
        }

        private static void Watch(string fullName)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = fullName;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.json";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to quit.");
            while (Console.Read() != 'q') ;
        }

        private static  void OnChanged(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(2000);
            ConvertFile(new FileInfo(e.FullPath));
            Console.WriteLine($"Arquivo atualizado: {Path.GetFileName(e.FullPath)}");
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Thread.Sleep(2000);

            File.Delete(e.OldFullPath);
            Console.WriteLine($"Arquivo renomeado: {Path.GetFileName(e.OldFullPath)} > {Path.GetFileName(e.FullPath)}");
            ConvertFile(new FileInfo(e.FullPath));
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(2000);

            Console.WriteLine($"Arquivo excluido: {Path.GetFileName(e.FullPath)}");
            File.Delete(e.FullPath);
        }

        private static void ConvertFile(FileInfo file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.Name);
            var content = JsonConvert.DeserializeObject<AnimationFramesFile>(File.ReadAllText(file.FullName))
                .frames
                .GroupBy(f => f.filename.Remove(f.filename.Length - 4));

            var methods = "";
            foreach (var group in content)
            {
                var rectangles = "";
                foreach (var item in group)
                {
                    rectangles += $@"
                new Rectangle({item.frame.x}, {item.frame.y}, {item.frame.w}, {item.frame.h}),";
                }
                rectangles = rectangles.Remove(rectangles.Length - 1);
                methods +=
$@"
        public static SimpleAnimation Load_{group.Key.Replace(' ', '_')}(ContentManager content, int X = 0, int Y = 0)
        {{
            if (Texture == null)
               Texture = content.Load<Texture2D>(""{fileName}"");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {{
                {rectangles}
            }});

            return new SimpleAnimation(Texture, animation, X, Y);
        }}
";
            }

            File.WriteAllText(
$"SpriteSheet_{fileName.Replace(' ','_')}.cs",
$@"using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TriggeredAnimation;

namespace MonogameAutoGeneratedContent{{
    public static class SpriteSheet_{fileName.Replace(' ', '_')}
    {{
        private static Texture2D Texture;
        {methods}
    }}
}}");
            //file.Delete();
        }

    }
    public class AnimationFramesFile
    {
        public AnimationFramesFileFrame[] frames { get; set; }
    }

    public class AnimationFramesFileFrame
    {
        public string filename { get; set; }
        public AnimationFramesFileRectangle frame { get; set; }
    }

    public class AnimationFramesFileRectangle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
    }
}
