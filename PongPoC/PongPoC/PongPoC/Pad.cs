using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC
{
    internal abstract class Pad
    {
        private readonly Texture2D _padTexture = TextureHelper.CreateSolidTexture(Width, Height, Color.White);

        public static int Width { get { return 20; } }

        public static int Height { get { return 80; } }

        protected Pad(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public abstract void Update(GameTime gameTime);

        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_padTexture, Position, Color.White);
        }
    }
}