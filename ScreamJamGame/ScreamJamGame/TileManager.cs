using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Xna.Framework.Audio;
using System.Runtime.CompilerServices;
using ScreamJamGame;

namespace Skill_Issue_Game
{
    internal static class TileManager
    {
        // List of enemys, and the interval for enemies fireing [Brandon]
        private static List<FloorTile> tiles = new List<FloorTile>();
        private static Texture2D tileTexture;

        private static Texture2D _hitbox;
        /*public static int Count
        {
            get { return walls.Count; }
        }*/


        /// <summary>
        /// save the projectile sprite for use whenever a new projectile is created
        /// </summary>
        /// <param name="projectileSprite">sprite of projectile</param>
        /// <New Code="Explanation">nothing much to say</New>
        /// <Coder Name="Alejandro"></Coder>
        public static void LoadContent(Texture2D tile)
        {
            tileTexture = tile;
        }


        public static void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// draws all enemies in the list
        /// </summary>
        /// <param name="spriteBatch">spriteBatch to be drawn in</param>
        /// <newCodeExplanation>added meteors</newCodeExplanation>
        /// <coderName>Alejandro</coderName>
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (FloorTile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        //change for hitboxes
        /* public static void DrawHitbox(SpriteBatch spriteBatch)
         {
        foreach (Table table in tables)
             {
                 table.Draw(spriteBatch);
             }
             foreach (TableR tableR in tableRs)
             {
                 tableR.Draw(spriteBatch);
             }
             foreach (TableL tableL in tableLs)
             {
                 tableL.Draw(spriteBatch);
             }
             foreach (TableS tableS in tableSs)
             {
                 tableS.Draw(spriteBatch);
             }
             foreach (Wall wall in walls)
             {
                 wall.Draw(spriteBatch);
             }
         }*/

        /// <summary>
        /// Moves the ememys, and meteors
        /// </summary>
        /// <param name="direction"> direction of movement</param>
        /// <newCodeExplanation>N/A</newCodeExplanation>
        /// <coderName>Brandon Donaldson</coderName>
        /*public static void Move(Vector2 direction)
        {
           foreach (Table table in tables)
            {
                table.Move(direction);
            }
            foreach (TableR tableR in tableRs)
            {
                tableR.Move(direction);
            }
            foreach (TableL tableL in tableLs)
            {
                tableL.Move(direction);
            }
            foreach (TableS tableS in tableSs)
            {
                tableS.Move(direction);
            }
            foreach (Wall wall in walls)
            {
                wall.Move(direction);
            }
        }*/

      

        /// <summary>
        /// Adds in enemys at the pos given in the file
        /// </summary>
        /// <param name="enemyArray">enemys in the list</param>
        /// <param name="meteorArray">meteors in the list</para
        /// <newCodeExplanation>N/A</newCodeExplanation>
        /// <coderName>Alejandro</coderName>m>
        public static void fileLoad(List<Vector2> tileCords)
        {
            Reset();

            foreach (Vector2 position in tileCords)
            {
                tiles.Add(new FloorTile(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    tileTexture));
            }
        }

        /// <summary>
        /// Resets all enememies
        /// </summary>
        /// <newCodeExplanation>N/A</newCodeExplanation>
        /// <coderName>Alejandro</coderName>
        public static void Reset()
        {
            tiles = new List<FloorTile>();
        }
    }
}
