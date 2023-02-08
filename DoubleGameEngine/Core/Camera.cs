using DoubleGameEngine.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace DoubleGameEngine.Core
{
    /// <summary>
    /// Камера
    /// </summary>
    public static class Camera
    {
        public static Matrix TransformationMatrix { get; private set; } // Матрица
        public static Vector2 Position { get; set; }                   // Позиция камеры
        public static GameObject? Follow { get; set; }                 // Игровой объект для слежения

        /// <summary>
        /// Обновляет состояние камеры
        /// </summary>
        /// <param name="elapsedTime">Время между кадрами</param>
        public static void Update()
        {
            // Проверка на наличие объекта слежения
            Vector2 size = Vector2.Zero;
            if (Follow != null)
            {
                Position = Follow.Position;
                size = Follow.Size;
            }
            //

            Matrix position = Matrix.CreateTranslation(
                -Position.X - size.X / 2,
                -Position.Y - size.Y / 2,
                0
                );

            Matrix offset = Matrix.CreateTranslation(
                Variables.WindowWidth / 2,
                Variables.WindowHeight / 2,
                0
                );

            TransformationMatrix = position * offset;
        }
    }
}
