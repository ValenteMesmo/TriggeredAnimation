using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TriggeredAnimation;

namespace MonogameAutoGeneratedContent{
    public static class SpriteSheet_Carolina
    {
        private static Texture2D Texture;
        
        public static SimpleAnimation Load_Boca(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(0, 0, 32, 22),
                new Rectangle(0, 0, 32, 22),
                new Rectangle(0, 0, 32, 22),
                new Rectangle(0, 0, 32, 22),
                new Rectangle(32, 0, 32, 22),
                new Rectangle(32, 0, 32, 22),
                new Rectangle(32, 0, 32, 22),
                new Rectangle(32, 0, 32, 22),
                new Rectangle(32, 0, 32, 22),
                new Rectangle(64, 0, 32, 22),
                new Rectangle(64, 0, 32, 22),
                new Rectangle(64, 0, 32, 22),
                new Rectangle(64, 0, 32, 22),
                new Rectangle(64, 0, 32, 22),
                new Rectangle(96, 0, 32, 22),
                new Rectangle(96, 0, 32, 22),
                new Rectangle(96, 0, 32, 22),
                new Rectangle(96, 0, 32, 22),
                new Rectangle(96, 0, 32, 22),
                new Rectangle(128, 0, 32, 22),
                new Rectangle(128, 0, 32, 22),
                new Rectangle(128, 0, 32, 22),
                new Rectangle(128, 0, 32, 22),
                new Rectangle(128, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(160, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(192, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(224, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(256, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(288, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22),
                new Rectangle(320, 0, 32, 22)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Boca_entristecendo(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(352, 0, 40, 11),
                new Rectangle(392, 0, 40, 11),
                new Rectangle(432, 0, 40, 11),
                new Rectangle(472, 0, 40, 11),
                new Rectangle(0, 22, 40, 11)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Boca_triste(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(40, 22, 32, 13),
                new Rectangle(72, 22, 32, 13),
                new Rectangle(104, 22, 32, 13),
                new Rectangle(136, 22, 32, 13),
                new Rectangle(168, 22, 32, 13),
                new Rectangle(200, 22, 32, 13)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Controle(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(232, 22, 65, 41)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Corpo(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(297, 22, 102, 127),
                new Rectangle(399, 22, 102, 127),
                new Rectangle(0, 149, 102, 127),
                new Rectangle(102, 149, 102, 127),
                new Rectangle(204, 149, 102, 127),
                new Rectangle(306, 149, 102, 127),
                new Rectangle(408, 149, 102, 127),
                new Rectangle(0, 276, 102, 127)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Mao_direita(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(102, 276, 32, 34),
                new Rectangle(134, 276, 32, 34),
                new Rectangle(166, 276, 32, 34),
                new Rectangle(198, 276, 32, 34)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Mao_esquerda(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(230, 276, 32, 34),
                new Rectangle(262, 276, 32, 34),
                new Rectangle(294, 276, 32, 34),
                new Rectangle(326, 276, 32, 34)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Palpebras_arregaladas(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(358, 276, 64, 23),
                new Rectangle(422, 276, 64, 23)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Palpebras_arregalando(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(0, 403, 67, 31),
                new Rectangle(67, 403, 67, 31),
                new Rectangle(134, 403, 67, 31),
                new Rectangle(201, 403, 67, 31),
                new Rectangle(268, 403, 67, 31),
                new Rectangle(335, 403, 67, 31),
                new Rectangle(402, 403, 67, 31),
                new Rectangle(0, 434, 67, 31)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Palpebras_fechando(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(67, 434, 58, 22),
                new Rectangle(125, 434, 58, 22),
                new Rectangle(183, 434, 58, 22),
                new Rectangle(241, 434, 58, 22),
                new Rectangle(299, 434, 58, 22),
                new Rectangle(357, 434, 58, 22),
                new Rectangle(415, 434, 58, 22),
                new Rectangle(415, 434, 58, 22),
                new Rectangle(415, 434, 58, 22)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Pupila(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(0, 465, 42, 7),
                new Rectangle(42, 465, 42, 7)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

        public static SimpleAnimation Load_Sobrancelha(ContentManager content, int X = 0, int Y = 0)
        {
            if (Texture == null)
               Texture = content.Load<Texture2D>("Carolina");
            var animation = new SequentialFrameChooser(60, new Rectangle[]
            {
                
                new Rectangle(84, 465, 52, 5),
                new Rectangle(136, 465, 52, 5)
            });

            return new SimpleAnimation(Texture, animation, X, Y);
        }

    }
}