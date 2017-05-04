using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TriggeredAnimation
{
    public interface Animation
    {
        void Draw(SpriteBatch batch, int x = 0, int y = 0);
        void Reset();
        bool HasEnded { get; }
    }

    public class EmptyAnimation : Animation
    {
        public bool HasEnded => true;

        public void Draw(SpriteBatch batch, int x = 0, int y = 0)
        {
        }

        public void Reset()
        {
        }
    }

    public class SimpleAnimation : Animation
    {
        public Texture2D Texture { get; }
        public FrameController AnimationFrameChooser { get; }
        public bool HasEnded
        {
            get
            {
                return AnimationFrameChooser.HasEnded();
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public SimpleAnimation(
            Texture2D Texture,
            FrameController AnimationFrameChooser,
            int X,
            int Y)
        {
            this.Texture = Texture;
            this.AnimationFrameChooser = AnimationFrameChooser;
            this.X = X;
            this.Y = Y;
        }

        public void Draw(SpriteBatch batch, int x = 0, int y = 0)
        {
            var frame = AnimationFrameChooser.GetNextFrame(DateTime.Now);
            batch.Draw(
                Texture,
                new Rectangle(
                    X + x,
                    Y + y,
                    frame.Width,
                    frame.Height),
                frame,
                Color.White);
        }

        public void Reset()
        {
            AnimationFrameChooser.Reset();
        }

        public SimpleAnimation AsScaleAnimation()
        {
            var AudioService = new AudioService();
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsScale(AudioService.GetCurrent), X, Y);
        }

        public SimpleAnimation Reverse()
        {
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsReverse(), X, Y);
        }

        public void SetFrameRate(int value)
        {
            AnimationFrameChooser.SetFrameRate(value);
        }
    }
}
