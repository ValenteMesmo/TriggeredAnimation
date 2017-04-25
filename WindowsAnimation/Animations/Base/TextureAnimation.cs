using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TriggeredAnimation
{
    class AnimationLoop : IGetNextAnimationFrame
    {
        private readonly IGetNextAnimationFrame Animation;

        public AnimationLoop(IGetNextAnimationFrame Animation)
        {
            this.Animation = Animation;
        }

        public bool Ended()
        {
            return Animation.Ended();
        }

        public Rectangle GetNextFrame(DateTime now)
        {
            if (Animation.Ended())
                Animation.Reset();

            return Animation.GetNextFrame(now);
        }

        public void Reset()
        {
            Animation.Reset();
        }
    }

    public class TextureAnimation
    {
        private IGetNextAnimationFrame AnimationSelector;
        private Texture2D SpriteTexture;

        public TextureAnimation(
            IGetNextAnimationFrame AnimationSelector,
            Texture2D SpriteTexture)
        {

            this.SpriteTexture = SpriteTexture;
            this.AnimationSelector = AnimationSelector;
        }

        public void Draw(SpriteBatch batch, int x, int y, Color color)
        {
            var frame = AnimationSelector.GetNextFrame(DateTime.Now);
            batch.Draw(
                SpriteTexture,
                new Rectangle(
                    x,
                    y,
                    frame.Width,
                    frame.Height),
                frame,
                color);
        }

        public TextureAnimation AsLoop()
        {
            AnimationSelector = new AnimationLoop(AnimationSelector);
            return this;
        }
    }
}
