using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TriggeredAnimation;

namespace MonogameAutoGeneratedContent{
    public static class ContentManagerExtensions_Corpo
    {        
        public static Animation LoadAnimation_Corpo(this ContentManager content)
        {
            var texture = content.Load<Texture2D>("Corpo");
            var rects = new Rectangle[]
            {

                new Rectangle(+2 + 0,      -2+0,    -2+476, +2+253),
                new Rectangle(+2 + 476,    -2+0,    -2+476, +2+253),
                new Rectangle(+2 + 0,      -2+253,  -2+476, +2+253),
                new Rectangle(+2 + 476,    -2+253,  -2+476, +2+253),
                new Rectangle(+2 + 0,      -2+506,  -2+476, +2+253),
                new Rectangle(+2 + 476,    -2+253,  -2+476, +2+253),
                new Rectangle(+2 + 0,      -2+253,  -2+476, +2+253),
                new Rectangle(+2 + 476,    -2+0,    -2+476, +2+253)
            };


            var animation = new FrameChooser(60, rects);

            return new Animation(texture, animation);
        }
    }
}