using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ScreamJamGame
{
    public class Level
    {
        private SpriteBatch _spriteBatch;

        private LevelTile[,] tileSet;

        private int intendedSize;

        private Texture2D spriteSheet;

        private Dictionary<string, Rectangle> textureMap;

        /// <summary>
        /// Constructs a Level object.
        /// </summary>
        /// <param name="spriteSheet">Which image are the sprites coming from?</param>
        /// <param name="filepath">Which file holds image data?</param>
        public Level(Texture2D spriteSheet, string filepath, SpriteBatch _spriteBatch)
        {

            // SpriteBatch reference is set
            this._spriteBatch = _spriteBatch;

            // Each LevelTile is 64 x 64 pixels by default
            intendedSize = 64;

            // The sprite sheet that contains all images
            this.spriteSheet = spriteSheet;

            // The Dictionary calculates a source rectangle for each of the chosen image tiles
            textureMap = new Dictionary<string, Rectangle>();

            int spriteWidth = 0;
            int spriteHeight = 0;

            try
            {
                StreamReader reader = new StreamReader(filepath);

                // Get string variables ready for file lines being split!
                string line = "";
                string[] splitData = null;


                while ((line = reader.ReadLine()) != null)
                {

                    if (line.StartsWith("/"))
                    {
                        continue;
                    }

                    if (line.Contains("---"))
                    {
                        continue;
                    }


                    splitData = line.Split(',');

                    if (splitData.Length == 2)
                    {
                        spriteWidth = int.Parse(splitData[0]);
                        spriteHeight = int.Parse(splitData[1]);
                        continue;
                    }

                    if (splitData.Length == 3)
                    {

                        string textureName = splitData[0];
                        int row = int.Parse(splitData[1]);
                        int column = int.Parse(splitData[2]);

                        int x = column * (spriteWidth + 1);
                        int y = row * (spriteHeight + 1);

                        textureMap[textureName] = new Rectangle(x, y, spriteWidth, spriteHeight);
                    }
                }
                // Close the stream
                reader.Close();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("FILE-READING ERROR UPON CONSTRUCTING LEVEL!");
                System.Diagnostics.Debug.WriteLine(error.Message);
            }

            LoadLevel("../../../Content/level1.csv");
        }

        /// <summary>
        /// Draw all LevelTiles to the game window.
        /// </summary>
        /// <param name="_spriteBatch">SpriteBatch object (passed in from Game1 Draw)</param>
        public void DisplayTiles()
        {
            // Iterate and draw all tiles in the 2D array of LevelTiles.
            for (int r = 0; r < tileSet.GetLength(0); r++)
            {
                for (int c = 0; c < tileSet.GetLength(1); c++)
                {
                    tileSet[r, c].Draw(_spriteBatch);
                }
            }
        }

        internal void LoadLevel(string filepath)
        {
            try
            {
                StreamReader reader = new StreamReader(filepath);
                string line = "";
                string[] splitData = null;
                int currentRow = 0;

                // Line 1: How large should the level tiles be?
                line = reader.ReadLine();
                splitData = line.Split(',');
                int tileWidth = int.Parse(splitData[1]);
                int tileHeight = int.Parse(splitData[2]);

                // Line 2: How many tiles are there?
                line = reader.ReadLine();
                splitData = line.Split(',');
                int tilesetColumns = int.Parse(splitData[1]);
                int tilesetRows = int.Parse(splitData[2]);

                // Initialize the tileSet array to the correct size
                tileSet = new LevelTile[tilesetColumns, tilesetRows];

                while ((line = reader.ReadLine()) != null)
                {
                    // Get this line of tile data and split by comma.
                    splitData = line.Split(',');

                    // For each of the tiles across a row...
                    for (int c = 0; c < splitData.Length; c++)
                    {
                        if (textureMap.ContainsKey(splitData[c]))
                        {
                            Rectangle sourceRect = textureMap[splitData[c]];

                            int x = c * intendedSize;
                            int y = currentRow * intendedSize;

                            tileSet[currentRow, c] = new LevelTile(spriteSheet, new Rectangle(x, y, intendedSize, intendedSize), sourceRect);
                        }
                    }
                    currentRow++;
                }
                reader.Close();
            }

            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("FILE-READING ERROR UPON LOADING LEVEL!");
                System.Diagnostics.Debug.WriteLine(error.Message);
            }
        }
    }
}
