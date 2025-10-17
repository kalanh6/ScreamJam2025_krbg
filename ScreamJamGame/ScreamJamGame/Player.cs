using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
    public class Player: GameObject
    {
        //Fields for creating the player texture
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;
        private Texture2D playerTexture;

        //General fields for player stats and sizing
        private Rectangle playerBounds;
        private bool isAlive;
        private bool hasKey;
        private int ammo;
        private string directionX;
        private string directionY;
        private int windowWidth;
        private int windowHeight;

        //Player input
        private KeyboardState keyState;

        //Bounds property
        public Rectangle PlayerBounds
        {
            get { return playerBounds; }
            set { playerBounds = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public bool HasKey
        {
            get { return hasKey; }
            set { hasKey = value; }
        }

        public int Ammo
        {
            get { return ammo; }
            set { ammo = value; }
        }

        public string DirectionX
        {
            get { return directionX; }
        }

        public string DirectionY
        {
            get { return directionY; }
        }

        //Constructor for player
        public Player (GraphicsDeviceManager graphicsMgr, Rectangle bounds, Texture2D texture, int width, int height) : base(bounds, texture)
        {
            _graphicsManager = graphicsMgr;
            playerTexture = texture;
            playerBounds = bounds;
            isAlive = true;
            ammo = 3;
            hasKey = false;
            windowWidth = width;
            windowHeight= height;
        }

        public override void Update (GameTime gameTime)
        {
            if (isAlive == true)
            {
                keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Left) && playerBounds.X>50)
                {
                    playerBounds.X -= 3;
                    directionX = "left";
                }
                if (keyState.IsKeyDown(Keys.Left)/* && position.X <= 0*/)
                {
                    Camera.Update(new Vector2(3, 0));
                }
                if (keyState.IsKeyDown(Keys.Right) && playerBounds.X < _graphicsManager.PreferredBackBufferWidth - 150)
                {
                    playerBounds.X += 3;
                    directionX = "right";
                }
                if (keyState.IsKeyDown(Keys.Right) /*&& position.X >= playerBounds.X*/)
                {
                    Camera.Update(new Vector2(-3, 0));
                }
                keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Keys.Up) && playerBounds.Y > 50)
                {
                    playerBounds.Y -= 3;
                    directionY = "up";
                }
                if (keyState.IsKeyDown(Keys.Up) && position.Y >= -500000000)
                {
                    Camera.Update(new Vector2(0, 3));
                }
                if (keyState.IsKeyDown(Keys.Down) && playerBounds.Y<_graphicsManager.PreferredBackBufferHeight-120)
                {
                    playerBounds.Y += 3;
                    directionY = "down";
                }
                if (keyState.IsKeyDown(Keys.Down) && position.Y >= playerBounds.Y)
                {
                    Camera.Update(new Vector2(0, -3));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive == true)
            {
                spriteBatch.Draw(playerTexture, playerBounds, Color.White);
            }
        }
        public void Reset(Vector2 newPosition)
        {
            position.X = (int)newPosition.X;
            position.Y = (int)newPosition.Y;
            if (position.Y >= windowHeight)
            {
                position.Y = windowHeight - 100;
            }
            isAlive = true;
        }
    }
}
