using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongPoC
{
    internal sealed class SelectionMenuItem<T> : IMenuItem
    {
        private readonly string _label;
        private readonly T[] _items;

        private readonly Texture2D _leftArrowTexture = TextureHelper.CreateSolidTriangle(10, 10, Color.White, Color.Black, Orientation.Left);
        private readonly Texture2D _rightArrowTexture = TextureHelper.CreateSolidTriangle(10, 10, Color.White, Color.Black, Orientation.Right);
        private const float HorizontalDistanceBetweenItems = 10.0f;
        private int _selectedIndex;

        public SelectionMenuItem(string label, T[] items, int selectedIndex)
        {
            _label = label;
            _items = items;
            _selectedIndex = selectedIndex;
        }

        public T SelectedItem
        {
            get
            {
                return _items[_selectedIndex];
            }
        }

        public string Text
        {
            get { return _label; }
        }

        public bool IsSelectable
        {
            get { return true; }
        }

        public void CheckInput(KeyboardHandler keyboardHandler)
        {
            keyboardHandler.CheckKeyState(Keys.Left, ExecuteKeyLeft);
            keyboardHandler.CheckKeyState(Keys.Right, ExecuteKeyRight);
        }

        private void ExecuteKeyLeft()
        {
            --_selectedIndex;

            if (_selectedIndex < 0)
            {
                _selectedIndex = _items.Length - 1;
            }
        }

        private void ExecuteKeyRight()
        {
            ++_selectedIndex;

            if (_selectedIndex == _items.Length)
            {
                _selectedIndex = 0;
            }
        }

        public void Draw(SpriteBatch batch, SpriteFont fontSprite, float currentPositionY, Color color)
        {
            var labelSize = fontSprite.MeasureString(_label);
            string optionText = _items[_selectedIndex].ToString();
            var optionTextSize = fontSprite.MeasureString(optionText);
            float arrowOffset = (labelSize.Y - _leftArrowTexture.Height)/2;
            var n = 5;
            float horizontalSize = labelSize.X + 3 * HorizontalDistanceBetweenItems + _leftArrowTexture.Width +
                                   optionTextSize.X + _rightArrowTexture.Width;

            Vector2 itemPosition = new Vector2((GlobalSettings.Width - horizontalSize ) / 2, currentPositionY);
            batch.DrawString(fontSprite, _label, itemPosition, color);
            itemPosition.X += (labelSize.X + HorizontalDistanceBetweenItems);
            itemPosition.Y += arrowOffset;

            batch.Draw(_leftArrowTexture, itemPosition, color);

            itemPosition.X += ( _leftArrowTexture.Width + HorizontalDistanceBetweenItems );
            itemPosition.Y -= arrowOffset;

            batch.DrawString(fontSprite, optionText, itemPosition, color);

            itemPosition.X += ( optionTextSize.X + HorizontalDistanceBetweenItems );
            itemPosition.Y += arrowOffset;

            batch.Draw(_rightArrowTexture, itemPosition, color);
        }
    }
}