﻿using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace ConvertAnimationsFromXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (var file in currentDir.GetFiles())
            {
                if (file.Extension.ToLower() == ".json".ToLower())
                    ConvertFile(file);
            }
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
        public static Animation Load_{group.Key.Replace(' ', '_')}(ContentManager content)
        {{
            if (Texture == null)
               Texture = content.Load<Texture2D>(""{fileName}"");
            var animation = new FrameChooser(60, new Rectangle[]
            {{
                {rectangles}
            }});

            return new Animation(Texture, animation);
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