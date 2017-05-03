using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
    public class SequentialFrameChooser : FrameController
    {
        private int frameRate;
        private DateTime nextFrameTime;

        public SequentialFrameChooser(int frameRate, params Rectangle[] Frames) : base(Frames)
        {
            this.frameRate = frameRate;
            currentIndex = 0;
        }

        public override void Reset()
        {
            currentIndex = 0;
        }

        public override Rectangle GetNextFrame(DateTime now)
        {
            if (now < nextFrameTime)
                return Frames[currentIndex];

            if (HasEnded())
                Reset();
            else
            {
                currentIndex++;
                if (currentIndex > lastIndex)
                    currentIndex = lastIndex;
            }

            nextFrameTime = now.AddMilliseconds(frameRate);

            return Frames[currentIndex];
        }

        public override bool HasEnded()
        {
            return currentIndex == lastIndex;
        }

        public override void SetFrameRate(int value)
        {
            frameRate = value;
        }
    }
}
