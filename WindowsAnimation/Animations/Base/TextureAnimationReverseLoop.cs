using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using System;

namespace TriggeredAnimation
{

    public abstract class TextureAnimationReverseLoop
    {
        private int currentFrame;
        private readonly AnimationFramesFileRectangle[] Frames;
        private readonly int totalFrames;
        private Texture2D SpriteTexture;

        protected abstract string GetJsonData();
        public abstract string GetAssetName();
        public abstract int GetFrameRate();

        public TextureAnimationReverseLoop(
            ContentManager content)
        {

            SpriteTexture = content.Load<Texture2D>(GetAssetName());
            currentFrame = 0;
            Frames = JsonConvert.DeserializeObject<AnimationFramesFile>(GetJsonData())
                .frames.Select(f => f.frame).ToArray();
            totalFrames = Frames.Length - 1;
        }

        DateTime nextFrameTime;
        int increment = 1;
        private void Update()
        {
            if (DateTime.Now < nextFrameTime)
                return;

            nextFrameTime = DateTime.Now.AddMilliseconds(GetFrameRate());

            currentFrame += increment;
            if (currentFrame == totalFrames)
                increment = -1;
            if (currentFrame == 0)
                increment = 1;
        }

        public void Draw(SpriteBatch batch, int x, int y, Color color)
        {
            Update();
            batch.Draw(
                SpriteTexture,
                new Rectangle(
                    x,
                    y,
                    Frames[currentFrame].w,
                    Frames[currentFrame].h),
                new Rectangle(
                Frames[currentFrame].x,
                Frames[currentFrame].y,
                Frames[currentFrame].w,
                Frames[currentFrame].h),
                color);
        }

        private class AnimationFramesFile
        {
            public AnimationFramesFileFrame[] frames { get; set; }
        }

        private class AnimationFramesFileFrame
        {
            public string filename { get; set; }
            public AnimationFramesFileRectangle frame { get; set; }
        }

        private class AnimationFramesFileRectangle
        {
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }
    }
}
