using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC
{
    public static class TextureHelper
    {
        public static Texture2D CreateSolidSquare(int width, int height, Color color)
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

        internal static Texture2D CreateSolidTriangle(int width, int height, Color triangleColor, Color backgroundColor, Orientation orientation)
        {
            Texture2D result = new Texture2D(PongGame.Instance.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];

            float ratio = (float)width/height;

            for (int i=0; i < data.Length; ++i)
            {
                int widthPos = Math.Abs( (i / width) - (width/2));
                int heightPos = i % width;

                if (orientation == Orientation.Right)
                {
                    if (widthPos + heightPos*ratio < ((float) width/2))
                    {
                        data[i] = triangleColor;
                    }
                    else
                    {
                        data[i] = backgroundColor;
                    }
                }
                else
                {
                    if (widthPos + (height - heightPos )* ratio < ( (float)width / 2 ))
                    {
                        data[i] = triangleColor;
                    }
                    else
                    {
                        data[i] = backgroundColor;
                    }
                }
            }

            result.SetData(data);

            return result;
        }
    }
}