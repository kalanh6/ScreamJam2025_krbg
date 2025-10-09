using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreamJamGame
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        protected Rectangle position;

        internal Rectangle Rectangle { get { return position; } }

        internal GameObject(Rectangle position, Texture2D sprite)
        {
            this.position = position;
            this.sprite = sprite;
        }
        
        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
