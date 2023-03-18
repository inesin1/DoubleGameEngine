using DoubleGameEngine.GameObjects;
using DoubleGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGameEngine.Core
{
    /// <summary>
    /// Игровая физика
    /// </summary>
    public class Physics
    {
        /// <summary>
        /// Активность физики
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Значение гравитации
        /// </summary>
        public float Gravity { get; set; }

        /// <summary>
        /// Контекст, в котором работает физика
        /// </summary>
        private GameScreen _context;

        public Physics(GameScreen context) { 
            _context = context;
        }

        public void Update(float elapsedTime) {
            CheckCollisions(elapsedTime);
        }

        private void CheckCollisions(float elapsedTime)
        {
            foreach (GameObject gameObject in _context.GameObjects.Values)
            {
                Dictionary<Side, Vector2> sidesCoords = new Dictionary<Side, Vector2> {
                        { Side.Top, new Vector2((gameObject.Position.X + gameObject.Size.X / 2) / 16, gameObject.Position.Y / 16) },
                        { Side.Right, new Vector2((gameObject.Position.X + gameObject.Size.X) / 16, (gameObject.Position.Y + gameObject.Size.Y / 2) / 16) },
                        { Side.Bottom, new Vector2((gameObject.Position.X + gameObject.Size.X / 2) / 16, (gameObject.Position.Y + gameObject.Size.Y) / 16 ) },
                        { Side.Left, new Vector2(gameObject.Position.X / 16, (gameObject.Position.Y + gameObject.Size.Y / 2) / 16) }
                    };

                try
                {
                    foreach (KeyValuePair<Side, Vector2> sideCoords in sidesCoords)
                    {
                        HandleIntGrid(elapsedTime, gameObject, sideCoords.Key, sideCoords.Value);
                    }
                }
                catch { }
            }
        }

        private void HandleIntGrid(float elapsedTime ,GameObject gameObject, Side side, Vector2 sideCoords) { 
            
        }
    }
}
