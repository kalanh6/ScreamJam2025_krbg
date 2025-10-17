using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ScreamJamGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Skill_Issue_Game;

public static class FileReaderWriter
{
    private static StreamReader reader;

    /// <summary>
    /// Reads the file
    /// </summary>
    /// <returns>World hight/Width, enemy pos, player pos, End pos, and empty pos</returns>
    /// /// <newCodeExplanation>N/A</newCodeExplanation>
    /// <coderName>Alejandro</coderName>
    public static Vector2 LoadLevel()
    {
        reader = new StreamReader("../../../Content/MutantMassacreLevel.txt");

        char[] reference = new char[10];
        
        List<Vector2> floorTiles = new List<Vector2>();
        List<Vector2> tableL = new List<Vector2>();
        List<Vector2> tableR = new List<Vector2>();
        List<Vector2> tables = new List<Vector2>();
        List<Vector2> walls = new List<Vector2>();
        List<Vector2> tableS = new List<Vector2>();
        List<Vector2> enemy = new List<Vector2>();
        List<Vector2> door = new List<Vector2>();
        List<Vector2> keycard = new List<Vector2>();


        Vector2 playerCords = new Vector2(0, 0);

        //first 6 lines are references for what each character in level map means
        for (int i = 0; i < 10; i++)
        {
            //w -,floor
            //x, enemy
            //0,wall
            //t, table
            //s, table special
            //p,player
            //e, door
            //k, keycard
            //l, table left
            //r, table right

            reference[i] = reader.ReadLine()![0];
        }

        //the first line after is the world height
        int width = int.Parse(reader.ReadLine()!.Split(',')[0]);
        int height = int.Parse(reader.ReadLine()!.Split(',')[0]);
        
        List<string> map = new List<string>();
        string temp;
        //while the 
        while ((temp = reader.ReadLine()) != null)
        {
            map.Add(temp);
        }
        
        for (int y = 0; y < map.Count; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                //switch case can't be used with non-constant variables
                
                if (map[y][x] == reference[0])
                {
                    //add to enemy list
                    floorTiles.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[1])
                {
                    //add to meteor list
                    enemy.Add(new Vector2(x * 50, y * 50));
                    floorTiles.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[2])
                {
                    walls.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[3])
                {
                    tables.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[4])
                {
                    tableS.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[5])
                {
                    //send player coordinates
                    playerCords = new Vector2(x * 50, y * 50);
                    floorTiles.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[6])
                {
                   door.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[7])
                {
                    keycard.Add(new Vector2(x * 50, y * 50));
                    floorTiles.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[8])
                {
                    tableL.Add(new Vector2(x * 50, y * 50));
                }
                else if (map[y][x] == reference[9])
                {
                    tableR.Add(new Vector2(x * 50, y * 50));
                }
            }

        }
        //read file, 
        //record world height, send it to camera to set the world height. [static class]
        //record enemies & asteroids(positions only, size will be constant), send it to enemy manager. [static class]
        //record player starting position and send it to game1
        //      [could be sent as a return value since it will be called in game 1].
        TileManager.fileLoad(floorTiles);
        ObjectManager.fileLoad(tables, tableR,tableS,tableL,walls);
        Camera.fileLoad(width, height, playerCords);
        reader.Close();
        return playerCords;
        
        
    }
}