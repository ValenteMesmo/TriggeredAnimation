using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace TriggeredAnimation
{

    public abstract class FrameController
    {
        protected int currentIndex;
        protected readonly Rectangle[] Frames;
        protected int lastIndex { get; private set; }

        public FrameController(Rectangle[] Frames)
        {
            this.Frames = Frames.ToArray();
            lastIndex = Frames.Length - 1;
        }

        public abstract void Reset();
        public abstract void SetFrameRate(int value);
        public abstract Rectangle GetNextFrame(DateTime now);
        public abstract bool HasEnded();

        public FrameController AsScale(Func<float> getCurrent)
        {
            return new FrameChosserByScale(getCurrent, Frames);
        }

        public FrameController AsReverse()
        {
            return new ReverseFrameChooser(60, Frames);
        }
    }
}
