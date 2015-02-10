using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongPoC
{
    internal sealed class GameMenu
    {
        private readonly SpriteFont _fontSprite = PongGame.Instance.Content.Load<SpriteFont>("GameOverFont");
        private readonly IMenuItem[] _menuItems;
        private readonly float _startPositionY;
        private readonly bool _canHaveSelection = false;
        private int _selectionIndex;
        private double _timeAfterGameOver;
        private readonly KeyboardHandler _keyboardHandler;
        private double _fadeInDuration;
        private const int MenuSpacing = 10;

        public GameMenu(double fadeInDuration = 1.00, params IMenuItem[] items)
        {
            _fadeInDuration = fadeInDuration;
            _menuItems = items;

            Vector2 textSize = _fontSprite.MeasureString("Sample");
            float menuSize = _menuItems.Length * textSize.Y + ( _menuItems.Length - 1 ) * MenuSpacing;
            _startPositionY = ( GlobalSettings.Height - menuSize ) / 2;

            for (var i = 0; i < _menuItems.Length; i++)
            {
                if (_menuItems[i].IsSelectable)
                {
                    _canHaveSelection = true;
                    _selectionIndex = i;
                    break;
                }
            }

            _keyboardHandler = new KeyboardHandler();
        }

        public void Update(GameTime gameTime)
        {
            _timeAfterGameOver += gameTime.ElapsedGameTime.TotalSeconds;

            if (_canHaveSelection && _timeAfterGameOver >= 1.00)
            {
                _keyboardHandler.CheckKeyState(Keys.Down, this.KeyDownPressed);
                _keyboardHandler.CheckKeyState(Keys.Up, this.KeyUpPressed);

                _menuItems[_selectionIndex].CheckInput(_keyboardHandler);
            }
        }

        private void KeyDownPressed()
        {
            for (int i = _selectionIndex + 1; i < _menuItems.Length; i++)
            {
                if (_menuItems[i].IsSelectable)
                {
                    _selectionIndex = i;
                    break;
                }
            }
        }

        private void KeyUpPressed()
        {
            for (int i = _selectionIndex - 1; i >= 0; i--)
            {
                if (_menuItems[i].IsSelectable)
                {
                    _selectionIndex = i;
                    break;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            Color defaultColor = Color.White;

            if (_timeAfterGameOver < _fadeInDuration)
            {
                // Tint the font
                byte grayValue = Convert.ToByte(( _timeAfterGameOver % 1.00 ) * 255);
                defaultColor = new Color(grayValue, grayValue, grayValue);
            }

            float currentPosition = _startPositionY;

            for (int i = 0; i < _menuItems.Length; i++)
            {
                Color itemColor = ( _canHaveSelection && ( i == _selectionIndex ) ) ? new Color(defaultColor.R, 0, 0) : defaultColor;

                DrawMenuItem(_menuItems[i], batch, ref currentPosition, itemColor);
            }
        }

        private void DrawMenuItem(IMenuItem item, SpriteBatch batch, ref float currentPositionY, Color color)
        {
            Vector2 textSize = _fontSprite.MeasureString(item.Text);
            item.Draw(batch, _fontSprite, currentPositionY, color);

            currentPositionY += ( textSize.Y + MenuSpacing );
        }
    }
}