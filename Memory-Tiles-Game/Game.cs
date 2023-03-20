using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memory_Tiles_Game
{
    public class Game
    {
        public Tile[,] BoardMatrix { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        List<string> ImagesPaths = new List<string>()
        {
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\1.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\2.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\3.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\4.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\5.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\6.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\7.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\8.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\9.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\10.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\11.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\12.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\13.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\14.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\15.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\16.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\17.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\18.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\19.png",
            "C:\\Users\\codru.LAPTOP-F7RR2UR3\\Documents\\Memory-Tiles-Game\\BoardImages\\20.png",
        };

        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            GenerateMatrixBoard();
        }

        public void GenerateMatrixBoard()
        {
            List<string> paths = new();
            for (int i = 0; i < (Rows * Columns) / 2; i++)
            {
                paths.Add(ImagesPaths.ElementAt(i));
                paths.Add(ImagesPaths.ElementAt(i));
            }
            Random rand = new();
            for (int i = paths.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                string temp = paths[j];
                paths[j] = paths[i];
                paths[i] = temp;
            }

            BoardMatrix = new Tile[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    BoardMatrix[i, j] = new Tile(paths[(i * Columns) + j]);
                }
            }
        }
     
    }
}
