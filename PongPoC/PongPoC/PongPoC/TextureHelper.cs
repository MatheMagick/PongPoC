using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC
{
    public static class TextureHelper
    {
        public static Texture2D CreateSolidTexture(int width, int height, Color color)
        {
            Texture2D result = new Texture2D(PongGame.Instance.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];

            for (int i=0; i < data.Length; ++i)
            {
                data[i] = color;
            }

            result.SetData(data);

            return result;
        }
    }
}
