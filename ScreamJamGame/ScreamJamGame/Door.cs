using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
    internal class Door : GameObject
    {
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;
        private Texture2D doorTexture;

        private Rectangle doorBounds;
        private bool opened;
        private Player player;

        public bool Opened
        {
            get { return opened; }
        }

        public Door(GraphicsDeviceManager graphicsMgr, Texture2D doorTexture, Rectangle doorBounds, Player player) : base (doorBounds, doorTexture)
        {
            _graphicsManager = graphicsMgr;
            this.doorTexture = doorTexture;
            this.doorBounds = doorBounds;
            this.player = player;
            opened = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (player.PlayerBounds.Intersects(doorBounds) && player.HasKey == true && !opened)
            {
                opened = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!opened)
            {
                spriteBatch.Draw(doorTexture, doorBounds, Color.White);
            }
        }
    }
}
