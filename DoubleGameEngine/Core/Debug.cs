using DoubleGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGameEngine.Core
{
    /// <summary>
    /// Дебаг
    /// </summary>
    public static class Debug
    {
        public static bool Active { get; set; } = false;

        public static GameScreen GameScreen;

        private static List<Rectangle> _objects; 

        public static void Update(float elapsedTime) { 
            
        }

        public static void Draw() {
            foreach (Rectangle obj in _objects) {
                //GameScreen.SpriteBatch.Draw(obj);
            }
        }
    }
}
