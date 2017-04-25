using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
    public interface IGetNextAnimationFrame
    {
        Rectangle GetNextFrame(DateTime now);
        void Reset();
        bool Ended();
    }

    public class BaseAnimation: IGetNextAnimationFrame
    {
        private int currentIndex;
        private readonly Rectangle[] Frames;
        private readonly int totalFrames;
        private int frameRate;
        private DateTime nextFrameTime;

        public BaseAnimation(int frameRate, params Rectangle[] Frames)
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

            nextFrameTime = now.AddMilliseconds(frameRate);

            currentIndex++;
            if (currentIndex > totalFrames)
                currentIndex = totalFrames;

            return Frames[currentIndex];
        }

        public bool Ended()
        {
            return currentIndex == totalFrames;
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
