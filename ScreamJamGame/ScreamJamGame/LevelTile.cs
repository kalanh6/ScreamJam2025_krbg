using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ScreamJamGame
{
    internal class LevelTile
    {
        private Rectangle drawnRect;
        private Rectangle sourceRect;
        private Texture2D spriteSheet;

        /// <summary>
        /// Constructs a LevelTile object
        /// </summary>
        /// <param name="spriteSheet">Which image is being used?</param>
        /// <param name="drawnRect">Where will this tile be drawn in the game window?</param>
        /// <param name="sourceRect">Which rectangle in the sprite sheet will be rendered?</param>
        public LevelTile(Texture2D spriteSheet, Rectangle drawnRect, Rectangle sourceRect)
        {
            // Which image is being used?
            this.spriteSheet = spriteSheet;

            // External class will decide where this LevelTile location will be rendered
            //   and where the source rectangle is.
            this.drawnRect = drawnRect;
            this.sourceRect = sourceRect;
        }

        /// <summary>
        /// Render this LevelTile to the game window.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(spriteSheet, drawnRect, sourceRect, Color.White);
        }
    }
}
