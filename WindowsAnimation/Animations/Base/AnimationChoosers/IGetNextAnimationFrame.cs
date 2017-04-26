﻿using Microsoft.Xna.Framework;
using System;

namespace TriggeredAnimation
{
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
    }
}