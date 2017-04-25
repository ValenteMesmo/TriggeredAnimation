using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsAnimation;

namespace TriggeredAnimation
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //TextureAnimation IdleAnimation { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        AudioService AudioService;
        private Cartolina_Idle_mouth Cartolina_mouth;
        private Cartolina_Idle Cartolina_Body;
        private Cartolina_Idle_Eye_Animation Cartolina_eye;
        private Cartolina_Olhos_Fechados OlhosFechandos;

        protected override void Initialize()
        {
            base.Initialize();
            AudioService = new AudioService();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Cartolina_eye = new Cartolina_Idle_Eye_Animation(Content);
            Cartolina_mouth = new Cartolina_Idle_mouth(Content);
            Cartolina_Body = new Cartolina_Idle(Content);
            OlhosFechandos = new Cartolina_Olhos_Fechados(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }       
        
        protected override void Draw(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                        
            Cartolina_mouth.Update(AudioService.Current);

            var width = 131;
            var height = 132;

            var x = width;
            var y = height;

            if (AudioService.Current > 0)
            {
                x = 0;
                y = 0;
            }

            GraphicsDevice.Clear(Color.Blue);
            spriteBatch.Begin();
            
            Cartolina_Body.Draw(spriteBatch, 0, 0, Color.White);
            Cartolina_eye.Draw(
                spriteBatch,
                24 + (int)(gamePadState.ThumbSticks.Left.X * 5),
                71 - (int)(gamePadState.ThumbSticks.Left.Y * 2),
                Color.White);

            OlhosFechandos.Draw(spriteBatch, 14, 58, Color.White);
            Cartolina_mouth.Draw(spriteBatch, 24, 98, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
