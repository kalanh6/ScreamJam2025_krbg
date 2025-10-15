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
        private Vector2 playerPos;
        private Rectangle playerBounds;
        private bool hasWeapon;
        private bool isAlive;
        private bool hasKey;

        //Player input
        private KeyboardState keyState;

        //Position property
        public Vector2 PlayerPos
        {
            get { return playerPos; }
            set { playerPos = value; }
        }

        //Bounds property
        public Rectangle PlayerBounds
        {
            get { return playerBounds; }
        }

        public bool HasKey
        {
            get { return hasKey; }
            set { hasKey = value; }
        }

        //Constructor for player
        public Player (GraphicsDevice graphicsDevice, Vector2 position, Rectangle bounds, Texture2D texture) : base(bounds, texture)
        {
            _graphicsDevice = graphicsDevice;
            playerTexture = texture;
            playerPos = position;
            playerBounds = bounds;
            isAlive = true;
            hasWeapon = false;
            hasKey = false;
        }

        public override void Update (GameTime gameTime)
        {
            if (isAlive == true)
            {
                keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
                {
                    playerPos.X -= 1;
                }
                else if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
                {
                    playerPos.X += 1;
                }

                keyState = Keyboard.GetState();
                if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
                {
                    playerPos.Y -= 1;
                }
                else if (keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                {
                    playerPos.Y += 1;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive == true)
            {
                spriteBatch.Draw(playerTexture, playerPos, Color.White);
            }
        }
    }
}
