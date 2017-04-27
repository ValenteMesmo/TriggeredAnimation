using Microsoft.Xna.Framework;
using System;
using System.Linq;

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
            var index = (GetScale() * (totalFrames)) / 0.08f;

            currentIndex = (int)Math.Floor(index);

            if (currentIndex > totalFrames)
                currentIndex = totalFrames;
            else if (currentIndex < 0)
                Reset();

            return Frames[currentIndex];
        }

        public override bool HasEnded()
        {
            return currentIndex == totalFrames;
        }

        public override void SetFrameRate(int value)
        {
        }
    }

    public class ReverseFrameChooser : FrameController
    {
        private int frameRate;
        private DateTime nextFrameTime;

        public ReverseFrameChooser(int frameRate, params Rectangle[] Frames) : base(Frames)
        {
            this.frameRate = frameRate;
            currentIndex = totalFrames;
        }

        public override void Reset()
        {
            currentIndex = totalFrames;
        }

        public override Rectangle GetNextFrame(DateTime now)
        {
            if (now < nextFrameTime)
                return Frames[currentIndex];

            if (HasEnded())
                Reset();

            nextFrameTime = now.AddMilliseconds(frameRate);

            currentIndex--;
            if (currentIndex < 0)
                Reset();

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

            nextFrameTime = now.AddMilliseconds(frameRate);

            currentIndex++;
            if (currentIndex > totalFrames)
                currentIndex = totalFrames;

            return Frames[currentIndex];
        }

        public override bool HasEnded()
        {
            return currentIndex == totalFrames;
        }

        public override void SetFrameRate(int value)
        {
            frameRate = value;
        }
    }

    public abstract class FrameController
    {
        protected int currentIndex;
        protected readonly Rectangle[] Frames;
        protected int totalFrames { get; private set; }

        public FrameController(Rectangle[] Frames)
        {
            this.Frames = Frames.ToArray();
            totalFrames = Frames.Length - 1;
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
