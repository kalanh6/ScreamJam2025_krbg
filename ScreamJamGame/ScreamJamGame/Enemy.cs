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
        private Rectangle enemyBounds;

        //Class-specific fields
        private bool isStunned;
        private int stunTimer;
        private Player player;

        public Rectangle EnemyBounds
        {
            get { return enemyBounds; }
            set { enemyBounds = value; }
        }

        public bool IsStunned
        {
            get { return isStunned; }
            set { isStunned = value; }
        }

        public int StunTimer
        {
            get { return stunTimer; }
            set { stunTimer = value; }
        }

        public Enemy(GraphicsDevice graphicsDevice, Rectangle bounds, Texture2D texture, Player player) : base (bounds, texture)
        {
            enemyBounds = bounds;
            enemyTexture = texture;
            isStunned = false;
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            if (player.IsAlive == true && isStunned == false)
            {
                if (player.PlayerBounds.Intersects(enemyBounds) && player.IsAlive == true)
                {
                    player.IsAlive = false;
                }

                if (enemyBounds.X > player.PlayerBounds.X)
                {
                    enemyBounds.X -= 1;
                }
                else if (enemyBounds.X < player.PlayerBounds.X)
                {
                    enemyBounds.X += 1;
                }

                if (enemyBounds.Y > player.PlayerBounds.Y)
                {
                    enemyBounds.Y -= 1;
                }
                else if (enemyBounds.Y < player.PlayerBounds.Y)
                {
                    enemyBounds.Y += 1;
                }
            }
            else if (player.IsAlive == true && isStunned == true)
            {
                if (stunTimer <=0)
                {
                    isStunned = false;
                }
                else
                {
                    stunTimer -= 1;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyBounds, Color.White);
        }
    }
}
