using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ScreamJamGame
{
    internal delegate void OnButtonClicked(GameState newState);
    internal class Button
    {
        //the rectangle for size and position, and the text to display
        private Rectangle rect;
        private String text;

        //the sprite of the button, and the sprite of the font
        private SpriteFont font;
        private Texture2D sprite;

        //size of the text
        private Vector2 size;

        //the state to update & draw on, and the state to transition to
        private GameState activeState;
        private GameState newState;

        //the 2 mouseState watchers
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        /// <summary>
        /// check the buttons designated state to see if it matches the game's current state
        /// </summary>
        internal GameState ActiveState
        {
            get { return activeState; }
        }

        public event OnButtonClicked ButtonEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="sprite"></param>
        /// <param name="activeState"></param>
        public Button(Rectangle rect, String text, SpriteFont font, Texture2D sprite, GameState activeState, GameState newState)
        {
            this.rect = rect;
            this.text = text;

            this.font = font;
            this.sprite = sprite;

            this.activeState = activeState;
            this.newState = newState;

            size = font.MeasureString(text);

            previousMouseState = Mouse.GetState();
        }

        /// <summary>
        /// draws the button and it's text
        /// </summary>
        /// <param name="spriteBatch">N/A</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                sprite,
                rect,
                Color.Black);

            spriteBatch.DrawString(
                font,
                text,
                new Vector2(rect.Center.X - size.X / 2, rect.Center.Y - size.Y / 2),
                Color.White);
        }

        /// <summary>
        /// if the button is pressed, it triggers the event
        /// <summary>
        public void Update()
        {
            currentMouseState = Mouse.GetState();

            //if the left button is pressed, it wasn't pressed last frame,
            //and the mouse intersects with the button rectangle
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                previousMouseState.LeftButton == ButtonState.Released &&
                rect.Contains(currentMouseState.Position))
            {
                ButtonEvent(newState);
            }

            previousMouseState = currentMouseState;
        }
    }
}
