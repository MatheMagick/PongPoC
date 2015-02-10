using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PongPoC.GameObjects
{
    internal sealed class PlayerPad : Pad
    {
        private const float PlayerSpeed = 250;

        public PlayerPad(float x, float y)
            : base(x, y)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            Vector2 inputSpeed = new Vector2();

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                inputSpeed.Y += PlayerSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                inputSpeed.Y -= PlayerSpeed;
            }

            this.Position += inputSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int maxY = GlobalSettings.Height - Height;

            if (this.Position.Y < 0)
            {
                this.Position = new Vector2(this.Position.X, 0);
            }
            else if (this.Position.Y > maxY)
            {
                this.Position = new Vector2(this.Position.X, maxY);
            }
        }
    }
}