using DoubleGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGameEngine.InterfaceItems
{
    /// <summary>
    /// Элемент интерфейса
    /// </summary>
    public class InterfaceItem
    {
        public GameScreen Context { get; }                       // Контекст
        public Vector2 Position { get; set; } = Vector2.Zero;   // Позиция
        public Vector2 Origin { get; set; } = Vector2.Zero;     // Центр координат
        public Texture2D Texture { get; set; }                  // Текстура
        public float Rotation { get; set; } = 0;                // Угол поворота
        public Vector2 Scale { get; set; }                      // Масштабирование
        public Vector2 Size { get; set; } = Vector2.Zero;       // Размер 

        protected ContentManager _content => Context.Content;   // Менеджер контента

        public InterfaceItem(GameScreen context) { Context = context; Init(); }

        /// <summary>
        /// Инициализирует элемент интерфейса
        /// </summary>
        public virtual void Init()
        {
            Scale = Vector2.One;
            Origin = new Vector2(Size.X / 2, Size.Y / 2);
        }

        /// <summary>
        /// Обновлеяет состояние элемента интерфейса
        /// </summary>
        public virtual void Update(float elapsedTime)
        {

        }

        /// <summary>
        /// Отрисовывает элемент интерфейса
        /// </summary>
        public virtual void Draw()
        {
            Context.SpriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                Rotation,
                Origin,
                Scale,
                SpriteEffects.None,
                0
                );
        }
    }
}
