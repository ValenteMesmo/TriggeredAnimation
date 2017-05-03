using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
    public class ReverseFrameChooser : FrameController
    {
        private int frameRate;
        private DateTime nextFrameTime;

        public ReverseFrameChooser(int frameRate, params Rectangle[] Frames) : base(Frames)
        {
            this.frameRate = frameRate;
            currentIndex = lastIndex;
        }

        public override void Reset()
        {
            currentIndex = lastIndex;
        }

        public override Rectangle GetNextFrame(DateTime now)
        {
            if (now < nextFrameTime)
                return Frames[currentIndex];

            if (HasEnded())
                Reset();
            else {
                currentIndex--;
                if (currentIndex < 0)
                    Reset();

            }

            nextFrameTime = now.AddMilliseconds(frameRate);

       
            return Frames[currentIndex];
        }

        public override bool HasEnded()
        {
            return currentIndex == 0;
        }

        public override void SetFrameRate(int value)
        {
            frameRate = value;
        }
    }
}
