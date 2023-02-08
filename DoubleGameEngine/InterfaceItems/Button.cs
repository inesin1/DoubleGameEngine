using DoubleGameEngine.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleGameEngine.InterfaceItems
{
    /// <summary>
    /// Кнопка
    /// </summary>
    public class Button : InterfaceItem
    {
        public Texture2D TextureHover { get; private set; }             // Текстура при наведении
        public bool IsHover { get; private set; }                       // Наведение курсора
        public bool IsClicked { get; private set; }                     // Нажата ли
        public bool IsHold { get; private set; }                        // Зажата ли
        public Rectangle ClickBox {                                     // Поле захвата мыши
            get { 
                return new Rectangle(
                    (int)Position.X, 
                    (int)Position.Y, 
                    Texture.Width, 
                    Texture.Height
                    ); 
            } 
        }

        private MouseState _currentMouseState;                          // Текущее состояние мыши
        private MouseState _previousMouseState;                         // Предыдущее состояние мыши

        public event EventHandler Click = (sender, e) => { };           // Событие нажатия
        public event EventHandler Hover = (sender, e) => { };           // Событие наведения

        #region Конструкторы
        public Button(GameScreen context, Texture2D texture, Texture2D textureHover = null) 
            : base(context) 
        {
            Texture = texture;
            TextureHover = textureHover;
        }
        public Button(GameScreen context, Texture2D texture, Vector2 position, Texture2D textureHover = null)
            : this(context, texture, textureHover)
        {
            Position = position;
        }
        #endregion

        public override void Update(float elapsedTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            // Расположение курсора
            Rectangle currentMouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);
            Rectangle previousMouseRectangle = new Rectangle(_previousMouseState.X, _previousMouseState.Y, 1, 1);

            IsHover = false;
            IsClicked = false;

            if (currentMouseRectangle.Intersects(ClickBox)) { 
                Hover.Invoke(this, new EventArgs());
                IsHover = true;

                if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton != ButtonState.Pressed) { 
                    Click.Invoke(this, new EventArgs());
                    IsClicked = true;
                }
            }

            base.Update(elapsedTime);
        }
    }
}
