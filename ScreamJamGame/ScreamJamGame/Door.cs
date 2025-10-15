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

        private Vector2 doorPos;
        private Rectangle doorBounds;
        private bool opened;
        private Player player;

        public Door(GraphicsDevice graphicsDevice, Texture2D doorTexture, Vector2 doorPos, Rectangle doorBounds, Player player) : base (doorBounds, doorTexture)
        {
            _graphicsDevice = graphicsDevice;
            this.doorTexture = doorTexture;
            this.doorPos = doorPos;
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
