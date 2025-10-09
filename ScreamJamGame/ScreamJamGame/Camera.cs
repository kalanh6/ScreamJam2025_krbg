using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        internal static int maxWidth {  get { return _worldWidth; } }
        internal static int maxHeight { get { return _worldHeight; } }

        internal static Vector2 Screen { get { return new Vector2(_screenWidth, _screenHeight); } }

        internal static void fileLoad(int width, int height, Vector2 playerCords)
        {

        }

        public static void Load(int screenWidth, int screenHeight, int worldWidth, int worldHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _worldWidth = worldWidth;
            _worldHeight = worldHeight;
            _position = new Vector2(0, 0);
        }

        public static void Update(Vector2 direction)
        {

        }
    }
}
