using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC.GameObjects
{
    internal sealed class Ball
    {
        private Vector2 _position;
        private Vector2 _velocity = new Vector2(200,200);
        private readonly Texture2D _ballTexture;

        internal const int Width = 10;
        internal const int Height = 10;

        public Ball(Vector2 position)
        {
            _position = position;
            _ballTexture = TextureHelper.CreateSolidSquare(Width, Height, Color.White);
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public void Update(GameTime gameTime, Pad player, Pad enemy)
        {
            CheckPlayerCollision(player);
            CheckEnemyCollision(enemy);
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            CheckBounds();
        }

        internal void Draw(SpriteBatch batch)
        {
            batch.Draw(_ballTexture, _position, Color.White);
        }

        private void CheckBounds()
        {
            int MaxY = GlobalSettings.Height - Height;
            int MinY = 0;

            if (_position.Y > MaxY)
            {
                _position = new Vector2(_position.X, MaxY);
                _velocity.Y = -_velocity.Y;
            }
            else if (_position.Y < MinY)
            {
                _position = new Vector2(_position.X, MinY);
                _velocity.Y = -_velocity.Y;
            }
        }

        private void CheckPlayerCollision(Pad pad)
        {
            if ( _velocity.X < 0 && _position.X <= Pad.Width)
            {
                if ( pad.Position.Y <= (_position.Y + Height )&& pad.Position.Y + Pad.Height >= _position.Y)
                {
                    Vector2 middleOfPad = pad.Position + new Vector2(0, Pad.Height/2);
                    Vector2 newVelocity = _position - middleOfPad;
                    newVelocity.Normalize();
                    Vector2 oldVelocity = _velocity;
                    _velocity.Normalize();
                    _velocity = newVelocity*(oldVelocity/_velocity);
                    _velocity *= 1.1f;
                }
            }
        }

        private void CheckEnemyCollision(Pad pad)
        {
            if (_velocity.X > 0 && _position.X >= ( GlobalSettings.Width - Pad.Width ))
            {
                if (pad.Position.Y <= ( _position.Y + Height ) && pad.Position.Y + Pad.Height + Height >= _position.Y)
                {
                    _velocity.X *= -1;
                }
            }
        }
    }
}