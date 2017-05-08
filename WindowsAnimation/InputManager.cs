using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TriggeredAnimation
{
    public class InputManager
    {
        public bool Y { get; private set; }
        public bool A { get; private set; }
        public bool B { get; private set; }
        public bool X { get; private set; }

        public bool RB { get; private set; }
        public bool RT { get; private set; }

        public bool LB { get; private set; }
        public bool LT { get; private set; }

        public bool LS { get; private set; }
        public bool RS { get; private set; }

        public bool Dpad_Up { get; private set; }
        public bool Dpad_Down { get; private set; }
        public bool Dpad_Left { get; private set; }
        public bool Dpad_Right { get; private set; }

        public float LS_X_Value { get; set; }
        public float LS_Y_Value { get; set; }

        public float RS_X_Value { get; set; }
        public float RS_Y_Value { get; set; }

        public void Update()
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();

            Y = gamePadState.Buttons.Y == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.I);
            A = gamePadState.Buttons.A == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.K);
            B = gamePadState.Buttons.B == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.L);
            X = gamePadState.Buttons.X == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.J);

            RB = gamePadState.Buttons.RightShoulder == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Z);
            RT = gamePadState.Triggers.Right > 0
                || keyboardState.IsKeyDown(Keys.X);

            LB = gamePadState.Buttons.LeftShoulder == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.M);
            LT = gamePadState.Triggers.Left > 0
                || keyboardState.IsKeyDown(Keys.N);

            LS = gamePadState.Buttons.LeftStick == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.Q);
            RS = gamePadState.Buttons.RightStick == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.E);

            Dpad_Up = gamePadState.DPad.Up == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.W);
            Dpad_Down = gamePadState.DPad.Down == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.S);
            Dpad_Left = gamePadState.DPad.Left == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.A);
            Dpad_Right = gamePadState.DPad.Right == ButtonState.Pressed
                || keyboardState.IsKeyDown(Keys.D);

            LS_X_Value = gamePadState.ThumbSticks.Left.X;
            LS_Y_Value = gamePadState.ThumbSticks.Left.Y;

            RS_X_Value = gamePadState.ThumbSticks.Right.X;
            RS_Y_Value = gamePadState.ThumbSticks.Right.Y;
        }
    }
}
