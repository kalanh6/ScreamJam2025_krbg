using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreamJamGame
{
    internal static class Camera
    {
        private static int _screenWidth;
        private static int _screenHeight;

        private static int _worldHeight;
        private static int _worldWidth;

        private static Vector2 _position;
        private static int direction;

        /// <summary>
        /// Camera Offset
        /// </summary>
        internal static Vector2 Offset { get { return _position; } }

        internal static int MaxWidth {  get { return _worldWidth; } }
        internal static int MaxHeight { get { return _worldHeight; } }

        internal static Vector2 Screen { get { return new Vector2(_screenWidth, _screenHeight); } }

        public static void fileLoad(int width, int height, Vector2 playerCords)
        {
            _worldHeight = height;
            _worldWidth = width;
            _position.Y = (int)(playerCords.Y / 1.5);
            _position.Y = (int)(playerCords.X / 1.5);
        }

        public static void Load(int screenWidth, int screenHeight, int worldWidth, int worldHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _worldWidth = worldWidth;
            _worldHeight = worldHeight;
            _position = new Vector2(-100, -300);
        }

        public static void Update(Vector2 direction)
        {
            if (!(((_position.Y <= -500 && direction.Y < 0) || (_position.Y >= _worldHeight && direction.Y > 0))||(_position.X<=-500 && direction.X<0)|| (_position.X >= _worldHeight && direction.X > 0)))
            {
                _position += direction;
                Game1.BackgroundMove(direction);
            }
        }
        public static void Reset()
        {
            _position = new Vector2(-100, -300);
        }
    }
}
