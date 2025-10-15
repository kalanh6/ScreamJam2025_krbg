using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace ScreamJamGame
{
   internal class Projectile: GameObject
   {
        //Graphics fields
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;
        private Texture2D projTexture;

        //Position fields
        private Vector2 projPos;
        private Rectangle projBounds;

        //Class-specific fields
        private bool firing;
        private int travelTime;
        private Player player;
        private Enemy enemy;
        private MouseState prevMState;

        public Projectile(GraphicsDevice graphicsDevice, Rectangle bounds, Texture2D texture, Player player, Enemy enemy) : base(bounds, texture)
        {
            projBounds = bounds;
            projTexture = texture;
            firing = false;
            this.player = player;
            this.enemy = enemy;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mState = Mouse.GetState();
            if (firing = false && prevMState.LeftButton == ButtonState.Pressed && mState.LeftButton == ButtonState.Released)
            {
                firing = true;
                travelTime = 20;
                player.Ammo -= 1;
                projPos = player.PlayerPos;
            }
            else if(firing == true && projBounds.Intersects(enemy.EnemyBounds))
            {
                enemy.IsStunned = true;
                enemy.StunTimer = 60;
                firing = false;
            }
            else if(firing == true && travelTime == 0)
            {
                firing = false;
            }
            else if(firing == true)
            {
                projPos.X += 5;
                travelTime -= 1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(firing == true)
            {
                spriteBatch.Draw(projTexture, projBounds, Color.White);
            }
        }
    }
}
