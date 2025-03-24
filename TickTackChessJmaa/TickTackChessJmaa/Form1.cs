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
		List<Pieces> piecelist = new List<Pieces>();

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

			piecelist.Clear();
			piecelist.Add(new Pieces("pcbknightBlackbg"));
			piecelist.Add(new Pieces("pcbqueenBlackbg"));
			piecelist.Add(new Pieces("pcbrookBlack"));
			piecelist.Add(new Pieces("pcbrookWhitebg"));
			piecelist.Add(new Pieces("pcbqueenWhite"));
			piecelist.Add(new Pieces("pcbknightWhite"));

		}

		private void rdoBlack_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoBlack.Checked == true)
			{
				pcbknightBlackbg.Show();
				pcbqueenBlackbg.Show();
				pcbrookBlack.Show();

				pcbBoardOne.BackColor = Color.Green;
				pcbBoardTwo.BackColor = Color.Green;
				pcbBoardThree.BackColor = Color.Green;
			}
			else
			{
				pcbknightBlackbg.Hide();
				pcbqueenBlackbg.Hide();
				pcbrookBlack.Hide();

				pcbBoardOne.BackColor = Color.Transparent;
				pcbBoardTwo.BackColor = Color.Transparent;
				pcbBoardThree.BackColor = Color.Transparent;
			}
		}

		private void rdoWhite_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoWhite.Checked == true)
			{
				pcbknightWhite.Show();
				pcbqueenWhite.Show();
				pcbrookWhitebg.Show();

				pcbBoardSeven.BackColor = Color.Green;
				pcbBoardEight.BackColor = Color.Green;
				pcbBoardNine.BackColor = Color.Green;
			}
			else
			{
				pcbknightWhite.Hide();
				pcbqueenWhite.Hide();
				pcbrookWhitebg.Hide();

				pcbBoardSeven.BackColor = Color.Transparent;
				pcbBoardEight.BackColor = Color.Transparent;
				pcbBoardNine.BackColor = Color.Transparent;
			}
		}

		private void pcbPieces_mouseDown(object sender, MouseEventArgs e)
		{
			pcbFrom = (PictureBox)sender;

			if (pcbFrom.Image != null && pcbFrom.BackColor != Color.Red)
			{
				currentPiece = piecelist.FirstOrDefault(x => x.GetName() == pcbFrom.Name);
				pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
				
			}
		}


		public void GetBoardoptions()
		{
			pieceOptions = "";
			foreach (Board Board in boardlist)
			{
				if (currentPiece != null)
				{
					pieceOptions += currentPiece.GetMoveoptions(Board.GetHorizontal(), Board.GetVertical());
					

				}
			}
			//pieceOptions = "1213";
		}

		private void pcbBoard_DragOver(object sender, DragEventArgs e)
		{
			//.
		}

		private void pcbBoard_DragDrop(object sender, DragEventArgs e)
		{
			pcbTo = (PictureBox)sender;
			if (pcbTo.BackColor == Color.Green)
			{
				
				e.Effect = DragDropEffects.Copy;
				Image getPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
				pcbTo.Image = getPicture;
				horizontal = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
				vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
				currentPiece.SetLocation(horizontal, vertical);
				//currentPiece.SetLocation(curHor, curVer);
				pcbFrom.BackColor = Color.Red;
				pcbTo.BackColor = Color.Transparent;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void pcbBoard_DragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.Bitmap) && ((PictureBox)sender).BackColor == Color.Green)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
	}
}
