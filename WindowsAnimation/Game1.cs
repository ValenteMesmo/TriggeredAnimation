﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WindowsAnimation;
using MonogameAutoGeneratedContent;
using System.Linq;

namespace TriggeredAnimation
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        AudioService AudioService;
        Animator Palpebra;

        protected override void Initialize()
        {
            base.Initialize();
            AudioService = new AudioService();
        }
        SimpleAnimation Corpo;
        SimpleAnimation Pupila;
        SimpleAnimation Boca;
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Pupila = SpriteSheet_Carolina.Load_Pupila(Content);
            Pupila.Y = 3;
            Pupila.Y = 1;
            Boca = SpriteSheet_Carolina.Load_Boca(Content).AsScaleAnimation();
            //Boca.Y = -40;
            //Boca.X = -12;
            Corpo = SpriteSheet_Carolina.Load_Corpo(Content);
            var PalpebrasFechando = SpriteSheet_Carolina.Load_Palpebras_fechando(Content);
            var PalpebrasAbertas = SpriteSheet_Carolina.Load_Palpebras_abertas(Content);
            //PalpebrasAbertas.X = -1;
            var PalpebrasAbrindo = PalpebrasFechando.Reverse();
            var PalpebrasArregaladas = SpriteSheet_Carolina.Load_Palpebras_arregaladas(Content);
            PalpebrasArregaladas.Y = -5;
            var PalpebrasArregalando = SpriteSheet_Carolina.Load_Palpebras_arregalando(Content);
            var PalpebrasDesarregalando = PalpebrasArregalando.Reverse();
            PalpebrasArregalando.Y = -5;
            PalpebrasDesarregalando.Y = -5;
            
            PalpebrasAbrindo.SetFrameRate(10);
            PalpebrasFechando.SetFrameRate(10);
            PalpebrasArregalando.SetFrameRate(10);
            PalpebrasDesarregalando.SetFrameRate(10);

            Palpebra = new Animator(
                new TriggeredAnimationTransitionRule(
                    PalpebrasAbertas,
                    PalpebrasFechando,
                    "piscar")
                , new AnimationTransitionRule(
                    PalpebrasFechando,
                    PalpebrasAbrindo)
                , new AnimationTransitionRule(
                    PalpebrasAbrindo,
                    PalpebrasAbertas)
                , new FlaggedAnimationTransitionRule(
                    PalpebrasAbertas,
                    PalpebrasArregalando,
                    "arregalar")
                , new AnimationTransitionRule(
                    PalpebrasArregalando,
                    PalpebrasArregaladas)
                , new UnFlaggedAnimationTransitionRule(
                    PalpebrasArregaladas,
                    PalpebrasDesarregalando,
                    "arregalar")
                , new AnimationTransitionRule(
                    PalpebrasDesarregalando,
                    PalpebrasAbertas)
            );

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();



            easy_eye_X.Set(gamePadState.ThumbSticks.Left.X * 3);
            easy_eye_Y.Set(gamePadState.ThumbSticks.Left.Y * 1.5f);

            easy_X.Set(gamePadState.ThumbSticks.Right.X * 5);
            easy_Y.Set(-gamePadState.ThumbSticks.Right.Y * 3);

            Palpebra.Flag("arregalar",
                gamePadState.Buttons.X == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.X));

            base.Update(gameTime);
        }

        EasyValue easy_eye_X = new EasyValue(20);
        EasyValue easy_eye_Y = new EasyValue(15);

        EasyValue easy_X = new EasyValue(10);
        EasyValue easy_Y = new EasyValue(10);
        DateTime horaDePiscar;

        protected override void Draw(GameTime gameTime)
        {
            var bonusX = (int)easy_X.Get();
            var bonusY = (int)easy_Y.Get();

            if (horaDePiscar < DateTime.Now)
            {
                horaDePiscar = DateTime.Now.AddSeconds(8);
                Palpebra.ActivateTrigger("piscar");
            }

            GraphicsDevice.Clear(Color.Blue);
            spriteBatch.Begin();


            Corpo.Draw(
                spriteBatch,
                bonusX + 50,
                bonusY + 50,
                Color.White);

            Pupila.Draw(spriteBatch,
                bonusX + 75 + (int)(easy_eye_X.Get()),
                bonusY + 82 - (int)(easy_eye_Y.Get()),
                Color.White);


            Palpebra.Draw(
                spriteBatch,
                bonusX + 65,
                bonusY + 68,
                Color.White);


            Boca.Draw(
                spriteBatch
                , bonusX + 80
                , bonusY + 105
                , Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
