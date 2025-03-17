using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackChessJmaa
{
    public partial class Form1: Form
    {
        Pieces currentPiece = null;
        PictureBox pcbFrom = null;
        PictureBox pcbTo = null;
        int horizontal = 0;
        int vertical = 0;
        string pieceOptions = "";
        List<Board> boardlist = new List<Board>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox picturebox in gbxBoard.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.LightGray;
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.AllowDrop = true;
            }

            boardlist.Clear();
            boardlist.Add(new Board(1, 1, "pbxBoardOne"));
            boardlist.Add(new Board(2, 1, "pbxBoardTwo"));
            boardlist.Add(new Board(3, 1, "pbxBoardThree"));
            boardlist.Add(new Board(1, 2, "pbxBoardFour"));
            boardlist.Add(new Board(2, 2, "pbxBoardFive"));
            boardlist.Add(new Board(3, 2, "pbxBoardSix"));
            boardlist.Add(new Board(1, 3, "pbxBoardSeven"));
            boardlist.Add(new Board(2, 3, "pbxBoardEight"));
            boardlist.Add(new Board(3, 3, "pbxBoardNine"));
        }
    }
}
