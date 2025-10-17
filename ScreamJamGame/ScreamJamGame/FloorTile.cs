using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
    internal class FloorTile: GameObject
    {
        public FloorTile(Rectangle rect, Texture2D texture): base(rect, texture)
        {

        }

        public void Move(Vector2 direction)
        {
            position.X += (int)direction.X;
            position.Y += (int)direction.Y;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                    sprite,
                    position,
                    Color.White);
        }
    }
}
