using DoubleGameEngine.Core;
using DoubleGameEngine.GameObjects;
using DoubleGameEngine.InterfaceItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DoubleGameEngine.GameScreens
{
    public class GameScreen : MonoGame.Extended.Screens.GameScreen
    {
        public new Core.Game Game => base.Game as Core.Game;
        public Physics Physics { get; set; }                                             // Физика
        public SpriteBatch SpriteBatch => Game.SpriteBatch;
        public OrthographicCamera Camera;                                                // Камера
        public Texture2D Background { get; set; }                                        // Текстура заднего фона

        public Dictionary<string, GameObject> GameObjects { get; private set; } = new Dictionary<string, GameObject>();           // Игровые объекты
        public Dictionary<string, InterfaceItem> InterfaceItems { get; private set; } = new Dictionary<string, InterfaceItem>();  // Элементы интерфейса

#nullable enable
        protected string? _level;
#nullable disable
        protected List<Entity> _entities;
        protected int[,] _intGrid;

        public GameScreen(Core.Game game) : base(game) { Initialize(); }

        public override void Initialize() {
            Camera = new OrthographicCamera(GraphicsDevice);

            if (_level != null) {
                // Парсинг заднего фона
                Background = Texture2D.FromFile(GraphicsDevice, $@"Levels\{_level}\background.png");
                
                // Парсинг entities.json
                _entities = JsonSerializer.Deserialize<List<Entity>>(File.ReadAllText($@"Levels\{_level}\entities.json"));

                // Парсинг IntGrid
                string[] intGridLines = File.ReadAllLines($@"Levels\{_level}\intGrid.csv");
                _intGrid = new int[intGridLines.Length, intGridLines[0].Length / 2];
                for (int i = 0; i < intGridLines.Length; i++) {
                    for (int j = 0; j < intGridLines[0].Length / 2; j++) {
                        _intGrid[i, j] = Convert.ToInt32(intGridLines[i].Split(",")[j]);
                    }
                }
            }

            Physics = new Physics(this, _intGrid);
        }

        public override void Update(GameTime gameTime) {
            foreach (GameObject gameObject in GameObjects.Values)
            {
                gameObject.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            foreach (InterfaceItem interfaceItem in InterfaceItems.Values)
            {
                interfaceItem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            Physics.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(GameTime gameTime)
        {
            Matrix transformationMatrix = Camera.GetViewMatrix();  

            GraphicsDevice.Clear(Color.White);
            SpriteBatch.Begin(transformMatrix: transformationMatrix);

            SpriteBatch.Draw(Background, Vector2.Zero, Color.White);

            foreach (GameObject gameObject in GameObjects.Values) {
                gameObject.Draw();
            }

            foreach (InterfaceItem interfaceItem in InterfaceItems.Values)
            {
                interfaceItem.Draw();
            }

            SpriteBatch.End();
        }
    }
}
