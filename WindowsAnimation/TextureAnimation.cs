using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Linq;
using System;
using Microsoft.Xna.Framework.Content;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;

namespace TriggeredAnimation
{
    public class FixedSizedQueue<T> : IOrderedEnumerable<T>
    {
       private ConcurrentQueue<T> q = new ConcurrentQueue<T>();

        public FixedSizedQueue(int Limit)
        {
            this.Limit = Limit;
        }

        public int Limit { get; set; }

        public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (this)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return q.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return q.GetEnumerator();
        }
    }


    public abstract class ScaleAnimation
    {
        private int currentFrame;
        private readonly AnimationFramesFileRectangle[] Frames;
        private readonly int totalFrames;
        private Texture2D SpriteTexture;

        protected abstract string GetJsonData();
        public abstract string GetAssetName();

        public ScaleAnimation(ContentManager content)
        {
            SpriteTexture = content.Load<Texture2D>(GetAssetName());
            currentFrame = 0;
            Frames = JsonConvert.DeserializeObject<AnimationFramesFile>(GetJsonData())
                .frames.Select(f => f.frame).ToArray();
            totalFrames = Frames.Length - 1;
        }

        
        public void Update(float scale)
        {
            var index = (scale * (totalFrames))/0.08f;
            
                currentFrame = (int)
                //Math.Ceiling(
                Math.Floor(
                    index
            )
            ;

            if (currentFrame > totalFrames)
                currentFrame = totalFrames;
            else if (currentFrame < 0)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch batch, Rectangle destination, Color color)
        {
            batch.Draw(
                SpriteTexture,
                destination,
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

    public abstract class TextureAnimation
    {
        private int currentFrame;
        private readonly AnimationFramesFileRectangle[] Frames;
        private readonly int totalFrames;
        private Texture2D SpriteTexture;

        protected abstract string GetJsonData();
        public abstract string GetAssetName();

        public TextureAnimation(ContentManager content)
        {
            SpriteTexture = content.Load<Texture2D>(GetAssetName());
            currentFrame = 0;
            Frames = JsonConvert.DeserializeObject<AnimationFramesFile>(GetJsonData())
                .frames.Select(f => f.frame).ToArray();
            totalFrames = Frames.Length - 1;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch batch, Rectangle destination, Color color)
        {
            batch.Draw(
                SpriteTexture,
                destination,
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
