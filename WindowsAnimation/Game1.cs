﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameAutoGeneratedContent;
using System;
using System.Collections.Generic;
using WindowsAnimation;

namespace TriggeredAnimation
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Animation> Animations = new List<Animation>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        AudioService AudioService;

        protected override void Initialize()
        {
            base.Initialize();
            AudioService = new AudioService();
        }

        SimpleAnimation Corpo;
        Animator Boca;
        Animation Load_Olhos_abertos;

        Animator Transformacao;

        Animator Botao_Y;
        Animator Botao_A;
        Animator Botao_X;
        Animator Botao_B;

        Animator Botao_Up;
        Animator Botao_Down;
        Animator Botao_Left;
        Animator Botao_Right;

        Animator Analog_L;
        Animator Analog_R;

        Animator Botao_R2;
        Animator Botao_R1;

        Animator Botao_L2;
        Animator Botao_L1;

        protected override void LoadContent()
        {
            var commonX = 100;
            var commonY = 100;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Load_Olhos_abertos = SpriteSheet_Carolina.Load_Olhos_abertos(Content, commonX + 63, commonY + 88);

            var Boca_padrao = SpriteSheet_Carolina.Load_Boca(Content, commonX + 12, commonY).AsScaleAnimation();
            var Boca_entristecendo = SpriteSheet_Carolina.Load_Boca_entristecendo(Content, 8, commonY);
            var Boca_desentristecendo = Boca_entristecendo.Reverse();
            var Boca_triste = SpriteSheet_Carolina.Load_Boca_triste(Content, commonX + 10, commonY).AsScaleAnimation();

            var ps4_abrindo = SpriteSheet_Carolina.Load_Corpo_ps4_abrindo(Content, commonX - 63, commonY + 178);
            var ps4_aberto = SpriteSheet_Carolina.Load_Corpo_ps4_aberto(Content, commonX - 63, commonY + 178);
            Transformacao = new Animator(
                new AnimationTransitionRule(ps4_abrindo, ps4_aberto)
            );

            Boca = new Animator(
                40, 138
                , new FlaggedAnimationTransitionRule(Boca_padrao, Boca_entristecendo, "triste")
                , new AnimationTransitionRule(Boca_entristecendo, Boca_triste)
                , new UnFlaggedAnimationTransitionRule(Boca_triste, Boca_desentristecendo, "triste")
                , new AnimationTransitionRule(Boca_desentristecendo, Boca_padrao)
            );

            Botao_Y = RoundButtonAnimator.Create(Content, commonX + 194, commonY + 175, "w");
            Botao_A = RoundButtonAnimator.Create(Content, commonX + 194, commonY + 220, "s");
            Botao_B = RoundButtonAnimator.Create(Content, commonX + 224, commonY + 197, "d");
            Botao_X = RoundButtonAnimator.Create(Content, commonX + 164, commonY + 197, "a");

            Botao_Up = RoundButtonAnimator.Create(Content, commonX - 54 + 42, commonY + 175    +10, "up");
            Botao_Down = RoundButtonAnimator.Create(Content, commonX - 54 + 42, commonY + 220  +10, "down");
            Botao_Left = RoundButtonAnimator.Create(Content, commonX - 84 + 42, commonY + 197  +10, "right");
            Botao_Right = RoundButtonAnimator.Create(Content, commonX - 24 + 42, commonY + 197 +10, "left");

            Analog_L = RoundButtonAnimator.Create(Content, commonX + 50, commonY + 220, "l3");
            Analog_R = RoundButtonAnimator.Create(Content, commonX + 110, commonY + 220, "r3");

            Botao_R2 = RoundButtonAnimator.Create(Content, commonX + 260, commonY + 165, "r2");
            Botao_R1 = RoundButtonAnimator.Create(Content, commonX + 261, commonY + 195, "r1");

            Botao_L2 = RoundButtonAnimator.Create(Content, commonX + -78, commonY + 182, "l2");
            Botao_L1 = RoundButtonAnimator.Create(Content, commonX + -77, commonY + 212, "l1");

            Corpo = SpriteSheet_Carolina.Load_Corpo(Content, commonX + 50, commonY + 50);
        }

        protected override void UnloadContent()
        {
        }
        GamePadState gamePadState;
        KeyboardState keyboardState;
        protected override void Update(GameTime gameTime)
        {
            gamePadState = GamePad.GetState(PlayerIndex.Two);
            keyboardState = Keyboard.GetState();

            Body_X.Set(gamePadState.ThumbSticks.Right.X * 5f);
            Body_Y.Set(gamePadState.ThumbSticks.Right.Y * 5f);

            Hand_X.Set(gamePadState.ThumbSticks.Left.X * 3);
            Hand_Y.Set(-gamePadState.ThumbSticks.Left.Y * 8);

            Eye_X.Set(
                (gamePadState.ThumbSticks.Left.X
                - gamePadState.ThumbSticks.Right.X)
                * 2
                );
            Eye_Y.Set((
                gamePadState.ThumbSticks.Left.Y
                - gamePadState.ThumbSticks.Right.Y
                ) * 2
                );

            Boca.Flag("triste",
                gamePadState.Buttons.A == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Z));

            Botao_Y.Flag("w", keyboardState.IsKeyDown(Keys.W));
            Botao_X.Flag("a", keyboardState.IsKeyDown(Keys.A));
            Botao_B.Flag("d", keyboardState.IsKeyDown(Keys.D));
            Botao_A.Flag("s", keyboardState.IsKeyDown(Keys.S));

            base.Update(gameTime);
        }

        EasyValue Body_X = new EasyValue(20);
        EasyValue Body_Y = new EasyValue(15);

        EasyValue Hand_X = new EasyValue(10);
        EasyValue Hand_Y = new EasyValue(10);

        EasyValue Eye_X = new EasyValue(10);
        EasyValue Eye_Y = new EasyValue(10);

        DateTime horaDePiscar;
        Random Random = new Random();

        protected override void Draw(GameTime gameTime)
        {
            if (horaDePiscar < DateTime.Now)
            {
                horaDePiscar = DateTime.Now.AddSeconds(Random.Next(1, 10));
                //Palpebra.ActivateTrigger("piscar");
            }

            GraphicsDevice.Clear(
                Color.White//Color.Blue
                );
            spriteBatch.Begin();


            Corpo.Draw(spriteBatch, Body_X, Body_Y);
            Transformacao.Draw(spriteBatch, Body_X, Body_Y);

            Boca.Draw(spriteBatch, Body_X, Body_Y);

            Load_Olhos_abertos.Draw(spriteBatch, Body_X, Body_Y);

            Botao_Down.Draw(spriteBatch, Body_X, Body_Y);
            Botao_Up.Draw(spriteBatch, Body_X, Body_Y);
            Botao_Left.Draw(spriteBatch, Body_X, Body_Y);
            Botao_Right.Draw(spriteBatch, Body_X, Body_Y);

            Botao_Y.Draw(spriteBatch, Body_X, Body_Y);
            Botao_X.Draw(spriteBatch, Body_X, Body_Y);
            Botao_B.Draw(spriteBatch, Body_X, Body_Y);
            Botao_A.Draw(spriteBatch, Body_X, Body_Y);

            Analog_L.Draw(spriteBatch, Body_X + Random.Next(1, 10), Body_Y + Random.Next(1, 10));
            Analog_R.Draw(spriteBatch, Body_X + Random.Next(1, 10), Body_Y + Random.Next(1, 10));

            Botao_R2.Draw(spriteBatch, Body_X, Body_Y);
            Botao_R1.Draw(spriteBatch, Body_X, Body_Y);

            Botao_L2.Draw(spriteBatch, Body_X, Body_Y);
            Botao_L1.Draw(spriteBatch, Body_X, Body_Y);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
