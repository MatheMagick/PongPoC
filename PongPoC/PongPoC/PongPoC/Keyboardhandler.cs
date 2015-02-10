using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace PongPoC
{
    internal sealed class KeyboardHandler
    {
        private readonly List<Keys> _keysPressed;

        internal KeyboardHandler()
        {
            _keysPressed = Keyboard.GetState().GetPressedKeys().ToList();
        }

        internal void CheckKeyState(Keys key, Action action)
        {
            if (Keyboard.GetState().IsKeyDown(key))
            {
                if (!_keysPressed.Contains(key))
                {
                    _keysPressed.Add(key);

                    if (action != null)
                    {
                        action();
                    }
                }
            }
            else
            {
                _keysPressed.Remove(key);
            }
        }
    }
}