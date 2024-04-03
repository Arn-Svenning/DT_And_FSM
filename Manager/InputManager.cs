using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.Manager
{
    internal class InputManager
    {
        private static KeyboardState currentKeyState;
        private static KeyboardState previousKeyState;
        
        public static void UpdateInput()
        {
            KeyboardGetState();
        }
        public static KeyboardState KeyboardGetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static bool HoldKey(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }
        public static bool NoKeysPressed()
        {
            Keys[] keys = currentKeyState.GetPressedKeys();
            return keys.Length == 0;
        }
    }
}
