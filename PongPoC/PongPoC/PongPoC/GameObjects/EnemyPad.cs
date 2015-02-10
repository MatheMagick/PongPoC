using System;
using Microsoft.Xna.Framework;

namespace PongPoC.GameObjects
{
    internal sealed class EnemyPad : Pad
    {
        private readonly Ball _ball;
        private const float ENEMY_SPEED = 150;

        public EnemyPad(float x, float y, Ball ball) : base(x, y)
        {
            _ball = ball;
        }

        public override void Update(GameTime gameTime)
        {
            int desiredHeight;

            if (_ball.Velocity.X < 0)
            {
                desiredHeight = ( GlobalSettings.Height - Height ) / 2;
            }
            else
            {
                var ratio =( GlobalSettings.Width - _ball.Position.X - Ball.Width - Width ) /
                _ball.Velocity.X;
                Vector2 finalPosition = _ball.Position + _ball.Velocity * ratio;
                int screenHeight = GlobalSettings.Height - Ball.Height;
                float destinationY = finalPosition.Y;
                while (destinationY > screenHeight || destinationY < 0)
                {
                    if (destinationY > screenHeight)
                    {
                        destinationY = 2 * screenHeight - destinationY;
                    }
                    else if (destinationY < 0)
                    {
                        destinationY = -destinationY;
                    }
                }

                desiredHeight = Convert.ToInt32(destinationY - Height / 2);

                desiredHeight = Math.Min(desiredHeight, GlobalSettings.Height - Height);
            }

            int enemyY = Convert.ToInt32(this.Position.Y);
            // Ball is running away from enemy, return to middle
            if (enemyY != desiredHeight)
            {
                float enemyMoveY = ENEMY_SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemyMoveY = Math.Min(Math.Abs(this.Position.Y - desiredHeight), enemyMoveY);
                enemyMoveY *= enemyY < desiredHeight ? 1 : -1;
                this.Position += new Vector2(0, enemyMoveY);
            }
        }
    }
}
