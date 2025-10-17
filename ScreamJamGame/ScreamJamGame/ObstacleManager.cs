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
    internal static class ObjectManager
    {
        // List of enemys, and the interval for enemies fireing [Brandon]
        private static List<Table> tables = new List<Table>();
        private static List<TableS> tableSs = new List<TableS>();
        private static List<TableR> tableRs = new List<TableR>();
        private static List<TableL> tableLs = new List<TableL>();
        private static List<Wall> walls = new List<Wall>();
        private static Texture2D tableRt;
        private static Texture2D tableLt;
        private static Texture2D tableSt;
        private static Texture2D tablet;
        private static Texture2D wallt;

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
        public static void LoadContent(Texture2D table, Texture2D tableR, Texture2D tableL, Texture2D tableS, Texture2D wall)
        {
            tables = new List<Table>();
            tableSs = new List<TableS>();
            tableRs = new List<TableR>();
            tableLs = new List<TableL>();
            walls = new List<Wall>();
            wallt = wall;
            tablet= table;
            tableRt = tableR;
            tableSt = tableS;
            tableLt = tableL;
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
        /// Checks to see if a player intersects with a meteor 
        /// </summary>
        /// <param name="player">player ref</param>
        /// <returns>True if its touched false if not</returns>
        /// <coderName>Brandon</coderName>
        public static bool CheckPlayerCollision(Player player)
        {
            foreach (Table table in tables)
            {
                if (table.Rectangle.Intersects(player.Rectangle))
                {
                    return true;
                }
            }
            foreach (TableR tableR in tableRs)
            {
                if (tableR.Rectangle.Intersects(player.Rectangle))
                {
                    return true;
                }
            }
            foreach (TableL tableL in tableLs)
            {
                if (tableL.Rectangle.Intersects(player.Rectangle))
                {
                    return true;
                }
            }
            foreach (TableS tableS in tableSs)
            {
                if (tableS.Rectangle.Intersects(player.Rectangle))
                {
                    return true;
                }
            }
            foreach (Wall wall in walls)
            {
                if (wall.Rectangle.Intersects(player.Rectangle))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds in enemys at the pos given in the file
        /// </summary>
        /// <param name="enemyArray">enemys in the list</param>
        /// <param name="meteorArray">meteors in the list</para
        /// <newCodeExplanation>N/A</newCodeExplanation>
        /// <coderName>Alejandro</coderName>m>
        public static void fileLoad(List<Vector2> tableC, List<Vector2> tableRC, List<Vector2> tableSC, List<Vector2> tableLC, List<Vector2> wallC)
        {
            Reset();

            foreach (Vector2 position in tableC)
            {
                tables.Add(new Table(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    tablet));
            }

            foreach (Vector2 position in tableSC)
            {
                tableSs.Add(new TableS(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    tableSt));
            }
            foreach (Vector2 position in tableRC)
            {
                tableRs.Add(new TableR(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    tableRt));
            }
            foreach (Vector2 position in tableLC)
            {
                tableLs.Add(new TableL(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    tableLt));
            }
            foreach (Vector2 position in wallC)
            {
                walls.Add(new Wall(
                    new Rectangle((int)position.X, (int)position.Y, 50, 50),
                    wallt));
            }
        }

        /// <summary>
        /// Resets all enememies
        /// </summary>
        /// <newCodeExplanation>N/A</newCodeExplanation>
        /// <coderName>Alejandro</coderName>
        public static void Reset()
        {
            tables = new List<Table>();
            tableSs = new List<TableS>();
            tableRs = new List<TableR>();
            tableLs = new List<TableL>();
            walls = new List<Wall>();
        }
    }
}
