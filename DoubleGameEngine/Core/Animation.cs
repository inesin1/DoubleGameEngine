using DoubleGameEngine.GameObjects;
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
    /// Анимация
    /// </summary>
    public class Animation
    {
        public GameObject Context;                               // Контекст
        public int SpriteCount { get; }                          // Кол-во спрайтов
        public int SpriteIndex { get; set; }                     // Индекс текущего спрайта
        public float Speed { get; set; }                         // Скорость
        public Rectangle SpriteRectangle { get; private set; }   // Прямоугольник текущего спрайта

        private int _index;                                      // Индекс анимации в спрайтбоксе
        private float _currentTime;                              // Текущее время таймера

        /// <summary>
        /// Конструктор анимации
        /// </summary>
        /// <param name="context">Игровой объект, которому принадлежит анимация</param>
        /// <param name="index">Индекс анимации в спрайтбоксе</param>
        /// <param name="spriteCount">Количество спрайтов</param>
        /// <param name="speed">Скорость</param>
        public Animation(GameObject context, int index, int spriteCount = 1, float speed = 100)
        {
            Context = context;
            SpriteCount = spriteCount;
            SpriteIndex = 0;
            Speed = speed;
            SpriteRectangle = Rectangle.Empty;
            _index = index;
            _currentTime = 0;
        }

        /// <summary>
        /// Обновляет анимацию
        /// </summary>
        /// <param name="elapsedTime">Время, прошедшее с предыдущего кадра</param>
        public void Update(float elapsedTime)
        {
            if (_currentTime >= Speed)
            {
                _currentTime = 0;

                SpriteIndex++;

                if (SpriteIndex >= SpriteCount)
                {
                    SpriteIndex = 0;
                }
            }

            SpriteRectangle = new Rectangle(SpriteIndex * (int)Context.Size.X, _index * (int)Context.Size.Y, (int)Context.Size.X, (int)Context.Size.Y);

            _currentTime += elapsedTime;
        }
    }
}
