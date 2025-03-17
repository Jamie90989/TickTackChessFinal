using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackChessJmaa
{
    class Board
    {
        private int horizontal = 0;
        private int vertical = 0;
        private string imagename = "";

        public Board(int c_horizontal, int c_vertical, string c_imagename)
        {
            horizontal = c_horizontal;
            vertical = c_vertical;
            imagename = c_imagename;
        }

        public int GetHorizontal()
        {
            return horizontal;
        }
        public int GetVertical()
        {
            return vertical;
        }
        public string GetImagename()
        {
            return imagename;
        }
    }
}


