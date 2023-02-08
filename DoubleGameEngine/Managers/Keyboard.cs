using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameKeyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace DoubleGameEngine.Managers
{
    /// <summary>
    /// Взаимодействие с клавиатурой
    /// </summary>
    public static class Keyboard
    {
        public static Keys[] PressedKeys => MonoGameKeyboard.GetState().GetPressedKeys();

        private static KeyboardState _previousKeyboardState;
        private static KeyboardState _currentKeyboardState = MonoGameKeyboard.GetState();

        public static bool IsKeyDown(Keys key) { 
            return MonoGameKeyboard.GetState().IsKeyDown(key);
        }

        public static bool IsKeyPressed(Keys key) {
            return _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key) { 
            return MonoGameKeyboard.GetState().IsKeyUp(key);
        }

        /// <summary>
        /// Обновляет состояние клавиатуры
        /// </summary>
        public static void Update() {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = MonoGameKeyboard.GetState();
        }
    }
}
