using DoubleGameEngine.Core;
using DoubleGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.RegularExpressions;

#nullable enable
namespace DoubleGameEngine.GameObjects
{
    /// <summary>
    /// Родительский класс для игровых объектов
    /// </summary>
    public class GameObject
    {
        public GameScreen Context { get; }                       // Контекст
        public Vector2 Position { get; set; } = Vector2.Zero;   // Позиция
        public Vector2 Origin { get; set; } = Vector2.Zero;     // Центр координат
        public Texture2D? Texture {                             // Текстура
            get { 
                return texture; 
            } 
            set {
                if (value != null)
                {
                    texture = value;
                    Size = new Vector2(value.Width, value.Height);
                }
            } 
        }
        Texture2D texture;
        public float Rotation { get; set; } = 0;                // Угол поворота
        public Vector2 Scale { get; set; } = Vector2.One;       // Масштабирование
        public Vector2 Size { get; set; } = Vector2.Zero;       // Размер спрайта
        public float Speed { get; set; }                        // Скорость
        public bool IsGrounded { get; set; } = false;           // На земле ли
        public bool IsFixed { get; set; } = false;              // Зафиксирован ли
        public Vector2 Velocity { get; set; } = new Vector2();  // Значение перемещения
        public Animation? Animation { get; set; }               // Анимация
        public Dictionary<string, Animation>? Animations { get; protected set; } // Список анимаций

        protected Dictionary<string, Keys> _input => Context.Game.Input;  // Ввод
        protected ContentManager _content => Context.Content;             // Менеджер контента

        public GameObject(GameScreen context) { Context = context; Init(); }

        /// <summary>
        /// Инициализация игрового объекта. Запускается один раз при создании
        /// </summary>
        public virtual void Init()
        {
                
        }

        /// <summary>
        /// Обновление состояния игрового объекта. Запускается каждый кадр
        /// </summary>
        public virtual void Update(float elapsedTime)
        {
            Size *= Scale;

            Animation?.Update(elapsedTime);
        }

        /// <summary>
        /// Отрисовывает игровой объект
        /// </summary>
        public virtual void Draw()
        {
            try
            {
                Context.SpriteBatch.Draw(
                    Texture,
                    Position,
                    Animation != null ? Animation.SpriteRectangle : null,
                    Color.White,
                    Rotation,
                    Origin,
                    Scale,
                    SpriteEffects.None,
                    0
                    );
            }
            catch
            {
                Texture = _content.Load<Texture2D>("s_TextureError");
            }
        }

        /// <summary>
        /// Проверка столкновения текущего объекта с другим объектом
        /// </summary>
        /// <param name="gameObject">Объект, с которым проверяется столкновение</param>
        /// <returns>Есть ли столкновение</returns>
        public bool isCollide(GameObject gameObject)
        {
            return
                Position.X + Size.X / 2 >= gameObject.Position.X - gameObject.Size.X / 2 &&
                Position.X - Size.X / 2 <= gameObject.Position.X + gameObject.Size.X / 2 &&
                Position.Y + Size.Y / 2 >= gameObject.Position.Y - gameObject.Size.Y / 2 &&
                Position.Y - Size.Y / 2 <= gameObject.Position.Y + gameObject.Size.Y / 2;
        }

        /// <summary>
        /// Проверка столкновения одного объекта с другим
        /// </summary>
        /// <param name="gameObject1">Первый объект</param>
        /// <param name="gameObject2">Второй объект</param>
        /// <returns>Есть ли столкновение</returns>
        public static bool CheckCollision(GameObject gameObject1, GameObject gameObject2)
        {
            return
                gameObject1.Position.X + gameObject1.Size.X / 2 >= gameObject2.Position.X - gameObject2.Size.X / 2 &&
                gameObject1.Position.X - gameObject2.Size.X / 2 <= gameObject2.Position.X + gameObject2.Size.X / 2 &&
                gameObject1.Position.Y + gameObject1.Size.Y / 2 >= gameObject2.Position.Y - gameObject2.Size.Y / 2 &&
                gameObject1.Position.Y - gameObject1.Size.Y / 2 <= gameObject2.Position.Y + gameObject2.Size.Y / 2;
        }

        /// <summary>
        /// Обрабатывает столкновения
        /// </summary>
        public void HandleCollision(Side side, GameObject gameObject) {
            Console.WriteLine("Столкновение с " + gameObject);
        }
    }

    public enum Side
    {
        Top,
        Right,
        Bottom,
        Left
    }
}
