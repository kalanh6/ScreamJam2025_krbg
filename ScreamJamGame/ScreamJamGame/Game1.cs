using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ScreamJamGame
{
    internal enum GameState
    {
        MainMenu,
        Gameplay,
        Win,
        Lose,
        Credits
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D temp;
        private Player player;
        private Vector2 playerPos;

        private GameState state;

        private List<Button> buttons;
        private SpriteFont consolas24;
        Texture2D background;
        private static Rectangle backgroundRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            buttons = new List<Button>();
            backgroundRect= new Rectangle(0, -200, 1000, 1050);
            Camera.Load(
                _graphics.PreferredBackBufferWidth,  //screen width
                _graphics.PreferredBackBufferHeight, //screen height
                1000,  //world width
                1050);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            temp = Content.Load<Texture2D>("temp");
            consolas24 = Content.Load<SpriteFont>("consolas-24");

            playerPos = new Vector2(_graphics.PreferredBackBufferWidth/2,_graphics.PreferredBackBufferHeight/2);
            player = new Player(GraphicsDevice, playerPos, new Rectangle((int)playerPos.X, (int)playerPos.Y, 0, 0), temp);
            {

            }

            background = Content.Load<Texture2D>("download (5)");
            player.PlayerBounds = new Rectangle((int)player.PlayerPos.X, (int)player.PlayerPos.Y, 1000, 1050);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            foreach (Button button in buttons)
            {
                if (button.ActiveState == state)
                {
                    button.Update();
                }
            }

            buttons.Add(new Button(
                new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 76, 400, 150, 70), //_graphics.PreferredBackBufferWidth/2 - 76, 500,150,70
                "START",
                consolas24,
                temp,
                GameState.MainMenu,
                GameState.Gameplay));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, backgroundRect, Color.White);
            player.Draw(_spriteBatch);

            foreach (Button button in buttons)
            {
                if (button.ActiveState == state)
                {
                    button.Draw(_spriteBatch);
                }
            }
            _spriteBatch.DrawString(
                consolas24,
                $"{player.PlayerPos.X},{player.PlayerPos.Y}",
                new Vector2(400, 240),
                Color.Black
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public static void BackgroundMove(Vector2 change)
        {
            backgroundRect.Y += (int)(change.Y / backgroundRect.Height * Camera.MaxHeight);
            backgroundRect.X += (int)(change.X / backgroundRect.Width * Camera.MaxWidth);
        }
    }
}
