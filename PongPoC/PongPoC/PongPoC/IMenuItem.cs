using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC
{
    internal interface IMenuItem
    {
        string Text { get; }
        bool IsSelectable { get; }
        void CheckInput(KeyboardHandler keyboardHandler);
        void Draw(SpriteBatch batch, SpriteFont fontSprite, float currentPositionY, Color color);
    }
}