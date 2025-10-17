using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Skill_Issue_Game;
using System;
using System.Collections.Generic;

namespace ScreamJamGame
{
    public enum GameState
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
        private Projectile proj;
        private Enemy enemy;
        private Keycard keycard;
        private Door door;

        private Texture2D spriteSheet;
        private Texture2D table;
        private Texture2D tableR;
        private Texture2D tableL;
        private Texture2D tableS;
        private Texture2D wall;
        private Texture2D playerTexture;
        private Texture2D enemyTexture;
        private Texture2D tileTexture;




        private GameState state;

        private List<Button> buttons;
        private SpriteFont consolas24;
        //Texture2D background;
        private static Rectangle backgroundRect;
        private static int worldWidth;
        private static int worldHeight;

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
            
            worldWidth = 1000;
            worldHeight = 600;
            Camera.Load(
                _graphics.PreferredBackBufferWidth,  //screen width
                _graphics.PreferredBackBufferHeight, //screen height
                worldWidth,  //world width
                worldHeight);
            backgroundRect = new Rectangle(0, -1200, Camera.MaxWidth, Camera.MaxHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            temp = Content.Load<Texture2D>("temp");
            playerTexture = Content.Load<Texture2D>("Player");
            enemyTexture = Content.Load<Texture2D>("Monster");
            consolas24 = Content.Load<SpriteFont>("consolas-24");
            table = Content.Load<Texture2D>("TableEmpty");
            tableS = Content.Load<Texture2D>("TableFull");
            tableR = Content.Load<Texture2D>("TableR");
            tableL = Content.Load<Texture2D>("TableL");
            wall = Content.Load<Texture2D>("Wall");
            tileTexture = Content.Load<Texture2D>("Floor");

            state = GameState.MainMenu;
            TileManager.LoadContent(tileTexture);
            ObjectManager.LoadContent(table,tableR,tableL,tableS,wall);
            buttons.Add(new Button(
                new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 76, 400, 150, 70), //_graphics.PreferredBackBufferWidth/2 - 76, 500,150,70
                "START",
                consolas24,
                temp,
                GameState.MainMenu,
                GameState.Gameplay));

            foreach (Button button in buttons)
            {
                button.ButtonEvent += this.Transition;
            }


            player = new Player(_graphics, new Rectangle(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2, 50, 50), playerTexture, _graphics.PreferredBackBufferWidth-100, _graphics.PreferredBackBufferHeight - 100);

            proj = new Projectile(_graphics, new Rectangle(0, 0, 5, 5), temp, player, enemy);
            
            enemy = new Enemy(GraphicsDevice, new Rectangle(0, 0, 100, 100), enemyTexture, player);

            keycard = new Keycard(_graphics, new Rectangle(50, 50, 10, 10), temp, player);

            door = new Door(_graphics, temp, new Rectangle(_graphics.PreferredBackBufferWidth - 150, _graphics.PreferredBackBufferHeight / 2, 10, 50), player);

            //background = Content.Load<Texture2D>("download (5)");
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button button in buttons)
            {
                if (button.ActiveState == state)
                {
                    button.Update();

                }
            }


            // TODO: Add your update logic here
            switch (state)
            {
                case GameState.Gameplay:
                    player.Update(gameTime);
                    proj.Update(gameTime);
                    enemy.Update(gameTime);
                    keycard.Update(gameTime);
                    door.Update(gameTime);
                    if (player.IsAlive == false)
                        state = GameState.Lose;
                    if (door.Opened == true)
                        state = GameState.Win;
                    break;
            }

            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           GraphicsDevice.Clear(Color.Red);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            foreach (Button button in buttons)
            {
                if (button.ActiveState == state)
                {
                    button.Draw(_spriteBatch);
                }
            }

            switch (state)
            {
                case GameState.MainMenu:
                    GraphicsDevice.Clear(Color.White);

                    break;
                case GameState.Gameplay:
                    //_spriteBatch.Draw(background, backgroundRect, Color.White);
                    TileManager.Draw(_spriteBatch);
                    ObjectManager.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);
                    proj.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);
                    keycard.Draw(_spriteBatch);
                    door.Draw(_spriteBatch);
                    break;
                case GameState.Lose:
                    GraphicsDevice.Clear(Color.White);
                    break;
                case GameState.Win:
                    GraphicsDevice.Clear(Color.White);
                    break;
            }

           
            
            _spriteBatch.DrawString(
                consolas24,
                $"{player.PlayerBounds.X},{player.PlayerBounds.Y}",
                new Vector2(400, 240),
                Color.Black
            );
            /*
            _spriteBatch.DrawString(
                consolas24,
                $"{keycard.KeycardBounds.X},{keycard.KeycardBounds.Y}",
                new Vector2(400, 280),
                Color.Black
            );
            */
            _spriteBatch.DrawString(
                consolas24,
                $"{backgroundRect.X},{backgroundRect.Y}",
                new Vector2(400, 280),
                Color.Black
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        /*public static void BackgroundMove(Vector2 change)
        { 
            backgroundRect.Y += (int)(change.Y / backgroundRect.Height * Camera.MaxHeight);
            backgroundRect.X += (int)(change.X / backgroundRect.Width * Camera.MaxWidth);
        }*/
        public void Transition(GameState newState)
        {
            GameState tempState = state;
            state = newState;

            if (newState == GameState.Gameplay)
            {
                if (tempState != GameState.Lose)
                {

                }
                player.Reset(FileReaderWriter.LoadLevel());
                Camera.Reset();
                //ProjectileManager.Clear();
                //backgroundRect.Y = 0 - backgroundRect.Height + _graphics.PreferredBackBufferHeight;
            }
            /*if (newState == GameState.MainMenu && tempState != GameState.Credits)
            {

            }*/
        }
    }
}
