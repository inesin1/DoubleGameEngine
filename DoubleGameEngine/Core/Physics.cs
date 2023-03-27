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
        public bool Active { get; set; } = false;

        /// <summary>
        /// Значение гравитации
        /// </summary>
        public float Gravity { get; set; } = 9.8f;

        /// <summary>
        /// Контекст, в котором работает физика
        /// </summary>
        private GameScreen _context;

        /// <summary>
        /// Таблица коллизий
        /// </summary>
        private int[,] _intGrid;

        public Physics(GameScreen context, int[,] intGrid) { 
            _context = context;
            _intGrid = intGrid;
        }

        public void Update(float elapsedTime) {
            foreach (GameObject gameObject in _context.GameObjects.Values)
            {
                Dictionary<Side, Vector2> sidesCoords = new Dictionary<Side, Vector2> {
                        { Side.Top, new Vector2((gameObject.Position.X + gameObject.Size.X / 2) / 16, gameObject.Position.Y / 16) },
                        { Side.Right, new Vector2((gameObject.Position.X + gameObject.Size.X) / 16, (gameObject.Position.Y + gameObject.Size.Y / 2) / 16) },
                        { Side.Bottom, new Vector2((gameObject.Position.X + gameObject.Size.X / 2) / 16, (gameObject.Position.Y + gameObject.Size.Y) / 16 ) },
                        { Side.Left, new Vector2(gameObject.Position.X / 16, (gameObject.Position.Y + gameObject.Size.Y / 2) / 16) }
                    };

                foreach (KeyValuePair<Side, Vector2> sideCoords in sidesCoords)
                {
                    HandleIntGrid(elapsedTime, gameObject, sideCoords.Key, sideCoords.Value);
                }

                gameObject.Velocity += Vector2.UnitY * Gravity;

                if (!gameObject.IsGrounded)
                    gameObject.Position += gameObject.Velocity * elapsedTime;
            }
        }

        /// <summary>
        /// Обрабатывает пересечение игрового объекта со значениями в таблице коллизий intGrid
        /// </summary>
        /// <param name="elapsedTime">Прошедшее время</param>
        /// <param name="gameObject">Игровой объект</param>
        /// <param name="side">Пересекающая сторона</param>
        /// <param name="sideCoords">Координаты пересекающей стороны</param>
        private void HandleIntGrid(float elapsedTime ,GameObject gameObject, Side side, Vector2 sideCoords) {
            try
            {
                switch (_intGrid[(int)sideCoords.Y / 16, (int)sideCoords.X / 16])
                {
                    case 1:
                        switch (side)
                        {
                            case Side.Bottom:
                                gameObject.IsGrounded = true;
                                gameObject.Velocity = new Vector2(gameObject.Velocity.X, 0);
                                break;
                        }
                        break;
                }
            }
            catch { }
        }
    }
}
