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
        public int ZIndex { get; private set; }

        public SimpleAnimation(
            Texture2D Texture,
            FrameController AnimationFrameChooser,
            int X,
            int Y,
            int ZIndex = 0)
        {
            this.Texture = Texture;
            this.AnimationFrameChooser = AnimationFrameChooser;
            this.X = X;
            this.Y = Y;
            this.ZIndex = ZIndex;
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
                Color.White,
                0,
                Vector2.Zero,
                SpriteEffects.None,
                ZIndex);
        }

        public void Reset()
        {
            AnimationFrameChooser.Reset();
        }

        public SimpleAnimation AsScaleAnimation()
        {
            //todo: remove audioservice from here
            var AudioService = new AudioService();
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsScale(AudioService.GetCurrent), X, Y);
        }

        public SimpleAnimation Reverse()
        {
            return new SimpleAnimation(Texture, AnimationFrameChooser.AsReverse(), X, Y);
        }

        public SimpleAnimation WithHigherZIndex()
        {
            return new SimpleAnimation(Texture, AnimationFrameChooser, X, Y, 1);
        }

        public void SetFrameRate(int value)
        {
            AnimationFrameChooser.SetFrameRate(value);
        }
    }
}
