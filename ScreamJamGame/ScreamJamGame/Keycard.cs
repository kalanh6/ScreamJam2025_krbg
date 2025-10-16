using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
   internal class Keycard: GameObject
   {
        private GraphicsDeviceManager _graphicsManager;
        private GraphicsDevice _graphicsDevice;
        private Texture2D keycardTexture;

        private Rectangle keycardBounds;

        private bool collected;
        private Player player;

        public Rectangle KeycardBounds
        {
            get { return keycardBounds; }
        }

        public Keycard(GraphicsDeviceManager graphicsMgr, Rectangle bounds, Texture2D texture, Player player) : base (bounds, texture)
        {
            _graphicsManager = graphicsMgr;
            keycardBounds = bounds;
            keycardTexture = texture;
            collected = false;
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            if (keycardBounds.Intersects(player.PlayerBounds) && !collected)
            {
                collected = true;
                player.HasKey = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!collected)
            {
                spriteBatch.Draw(keycardTexture, keycardBounds, Color.White);
            }
        }
    }
}
