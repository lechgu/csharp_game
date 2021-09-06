
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
namespace Blocks
{
    public class InputManager
    {
        private KeyboardState oldKeys;
        private readonly Dictionary<Keys, Action> discretePresses = new();

        public void Handle(Keys keys, Action action)
        {
            discretePresses[keys] = action;
        }

        public void Reset()
        {
            oldKeys = Keyboard.GetState();
        }

        public void Update(double _)
        {
            var keys = Keyboard.GetState();
            foreach (var key in discretePresses.Keys)
            {
                if (keys.IsKeyDown(key) && !oldKeys.IsKeyDown(key))
                {
                    discretePresses[key]();
                }
            }
            oldKeys = keys;
        }
    }
}
