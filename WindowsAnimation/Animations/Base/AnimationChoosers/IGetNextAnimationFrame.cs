﻿using Microsoft.Xna.Framework;
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
            var index = (GetScale() * (lastIndex)) / 0.04f;

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
