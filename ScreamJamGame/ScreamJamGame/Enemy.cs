using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
   internal class Enemy: GameObject
   {
        //Graphics fields
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;
        private Texture2D enemyTexture;

        //Position fields
        private Vector2 enemyPos;
        private Rectangle enemyBounds;

        //Class-specific fields
        private Player player;

        public Enemy(GraphicsDevice graphicsDevice, Vector2 position, Rectangle bounds, Texture2D texture, Player player) : base (bounds, texture)
        {
            enemyPos = position;
            enemyBounds = bounds;
            enemyTexture = texture;
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            if (player.PlayerBounds.Intersects(enemyBounds) && player.IsAlive == true)
            {
                player.IsAlive = false;
            }
            else if (player.IsAlive == true)
            {
                string directionX;
                string directionY;

                if (enemyPos.X > player.PlayerPos.X)
                {
                    directionX = "left";
                }
                else
                {
                    directionX = "right";
                }

                if (enemyPos.Y > player.PlayerPos.Y)
                {
                    directionY = "up";
                }
                else
                {
                    directionY = "down";
                }

                if (directionX == "left")
                {
                    enemyPos.X -= 1;
                }
                else
                {
                    enemyPos.X += 1;
                }

                if (directionY == "up")
                {
                    enemyPos.Y -= 1;
                }
                else
                {
                    enemyPos.Y += 1;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBounds, Color.White);
        }
    }
}
