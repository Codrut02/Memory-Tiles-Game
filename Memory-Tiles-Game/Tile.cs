using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Tiles_Game
{
    public class Tile
    {
        public bool Shown { get; set; }

        public string ImagePath { get; set; }

        public Tile(string imagePath)
        {
            ImagePath = imagePath;
            Shown = false;
        }

        public Tile(string imagePath, bool shown)
        {
            ImagePath = imagePath;
            Shown = shown;
        }

        public void ChangeShown()
        {
            Shown = !Shown;
        }
    }
}
