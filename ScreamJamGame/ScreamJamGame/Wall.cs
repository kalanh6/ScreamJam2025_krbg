using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
    internal class Wall: GameObject
    {
        public Wall(Rectangle rect, Texture2D texture):base(rect,texture)
        {

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
