using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        private Texture2D eyesSprite;
        private Cartolina_Idle_mouth Cartolina_mouth;
        private Cartolina_Idle_Body Cartolina_Body;

        protected override void Initialize()
        {
            base.Initialize();
            AudioService = new AudioService();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            eyesSprite = Content.Load<Texture2D>("eyes");

            Cartolina_mouth = new Cartolina_Idle_mouth(Content);
            Cartolina_Body = new Cartolina_Idle_Body(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Cartolina_Body.Update();
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
            //spriteBatch.Draw(
            //   RoundButton,
            //   new Rectangle(
            //       0, 
            //       0, 
            //       200 , 
            //       200 ),
            //   new Rectangle(x,y , width, height),
            //   Color.Red);


            Cartolina_Body.Draw(spriteBatch, new Rectangle(0, 0, 200, 220), Color.White);
            spriteBatch.Draw(eyesSprite, new Rectangle(50, 50, 200, 200), Color.White);
            Cartolina_mouth.Draw(spriteBatch, new Rectangle(55, 130, 100, 50), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
