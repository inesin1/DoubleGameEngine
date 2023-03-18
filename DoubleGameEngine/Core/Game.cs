using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Keyboard = DoubleGameEngine.Managers.Keyboard;

namespace DoubleGameEngine.Core
{
    /// <summary>
    /// Игра
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager _graphics;                  // Окно
        public SpriteBatch SpriteBatch;                             // Холст

        public ScreenManager ScreenManager { get; }                 // Менеджер экранов

        public Dictionary<string, Keys> Input { get; private set; }   // Ввод


        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);

            ScreenManager = new ScreenManager();
            Components.Add(ScreenManager);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Input = new Dictionary<string, Keys>();
            Dictionary<string, string> input = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("Input.json"));
            foreach (var pair in input)
            {
                Input.Add(pair.Key, Enum.Parse<Keys>(pair.Value));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}