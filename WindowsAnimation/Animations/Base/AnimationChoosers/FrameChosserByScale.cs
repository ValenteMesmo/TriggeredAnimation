using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
    public class FrameChosserByScale : FrameController
    {
        private Func<float> GetScale;
        public FrameChosserByScale(Func<float> GetScale, params Rectangle[] Frames) : base(Frames)
        {
            currentIndex = 0;
            this.GetScale = GetScale;
        }

        public override void Reset()
        {
            currentIndex = 0;
        }

        public override Rectangle GetNextFrame(DateTime now)
        {
            var index = (GetScale() * (lastIndex)) / 0.1f;

            currentIndex = (int)Math.Floor(index);

            if (currentIndex > lastIndex)
                currentIndex = lastIndex;
            else if (currentIndex < 0)
                Reset();

            return Frames[currentIndex];
        }

        public override bool HasEnded()
        {
            return currentIndex == 0;
        }

        public override void SetFrameRate(int value)
        {
        }
    }
}
