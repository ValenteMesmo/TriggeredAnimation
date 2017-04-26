using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
    public class FrameChosserByScale
    {
        private int currentIndex;
        private readonly Rectangle[] Frames;
        private readonly int totalFrames;
        private DateTime nextFrameTime;
        private Func<float> GetScale;
        public FrameChosserByScale(Func<float> GetScale, params Rectangle[] Frames)
        {
            currentIndex = 0;
            this.Frames = Frames;
            this.GetScale = GetScale;
            totalFrames = Frames.Length - 1;
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        public Rectangle GetNextFrame(DateTime now)
        {
            var index = (GetScale() * (totalFrames)) / 0.08f;

            currentIndex = (int)Math.Floor(index);

            if (currentIndex > totalFrames)
                currentIndex = totalFrames;
            else if (currentIndex < 0)
                currentIndex = 0;

            return Frames[currentIndex];
        }

        public bool HasEnded()
        {
            return currentIndex == totalFrames;
        }
    }

    public class FrameChooser
    {
        private int currentIndex;
        private readonly Rectangle[] Frames;
        private readonly int totalFrames;
        private int frameRate;
        private DateTime nextFrameTime;

        public FrameChooser(int frameRate, params Rectangle[] Frames)
        {
            this.frameRate = frameRate;
            currentIndex = 0;
            this.Frames = Frames;
            totalFrames = Frames.Length - 1;
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        public Rectangle GetNextFrame(DateTime now)
        {
            if (now < nextFrameTime)
                return Frames[currentIndex];

            if (HasEnded())
                currentIndex = 0;

            nextFrameTime = now.AddMilliseconds(frameRate);

            currentIndex++;
            if (currentIndex > totalFrames)
                currentIndex = totalFrames;

            return Frames[currentIndex];
        }

        public bool HasEnded()
        {
            return currentIndex == totalFrames;
        }

        public FrameChosserByScale AsScale(Func<float> GetScale) {
            return new FrameChosserByScale(GetScale, Frames);
        }
    }
}
