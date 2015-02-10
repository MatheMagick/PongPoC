using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongPoC
{
    internal sealed class TextMenuItem : IMenuItem
    {
        private readonly Action _executeAction;

        internal TextMenuItem(string text, bool isSelectable, Action executeAction)
        {
            Text = text;
            IsSelectable = isSelectable;
            _executeAction = executeAction;
        }

        public string Text { get; private set; }
        public bool IsSelectable { get; private set; }

        public void CheckInput(KeyboardHandler keyboardHandler)
        {
            keyboardHandler.CheckKeyState(Keys.Enter, _executeAction);
        }

        public void Draw(SpriteBatch batch, SpriteFont fontSprite, float currentPositionY, Color color)
        {
            Vector2 textSize = fontSprite.MeasureString(this.Text);
            Vector2 textPosition = new Vector2(( GlobalSettings.Width - textSize.X ) / 2, currentPositionY);

            batch.DrawString(fontSprite, this.Text, textPosition, color);
        }
    }
}