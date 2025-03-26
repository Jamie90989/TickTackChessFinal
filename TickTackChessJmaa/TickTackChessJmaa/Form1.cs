using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackChessJmaa
{
    public partial class Form1: Form
    {
        Pieces currentPiece = null;
		string teamColor = "";
        PictureBox pcbFrom = null;
        PictureBox pcbTo = null;
        int horizontal = 0;
        int vertical = 0;
        string pieceOptions = "";
		string playerTurn = "";
		
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
            boardlist.Add(new Board(1, 1, "pcbBoardOne"));
            boardlist.Add(new Board(2, 1, "pcbBoardTwo"));
            boardlist.Add(new Board(3, 1, "pcbBoardThree"));
            boardlist.Add(new Board(1, 2, "pcbBoardFour"));
            boardlist.Add(new Board(2, 2, "pcbBoardFive"));
            boardlist.Add(new Board(3, 2, "pcbBoardSix"));
            boardlist.Add(new Board(1, 3, "pcbBoardSeven"));
            boardlist.Add(new Board(2, 3, "pcbBoardEight"));
            boardlist.Add(new Board(3, 3, "pcbBoardNine"));

			piecelist.Clear();
			piecelist.Add(new Pieces("Black", "pcbknightBlackbg"));
			piecelist.Add(new Pieces("Black", "pcbqueenBlackbg"));
			piecelist.Add(new Pieces("Black", "pcbrookBlack"));
			piecelist.Add(new Pieces("White", "pcbrookWhitebg"));
			piecelist.Add(new Pieces("White", "pcbqueenWhite"));
			piecelist.Add(new Pieces("White", "pcbknightWhite"));
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

		private void pcbBoard_MouseDown(object sender, MouseEventArgs e)
		{
			if(rdoBlack.Enabled == false && rdoWhite.Enabled == false)
			{
				clearBoardColors();
				pcbFrom = (PictureBox)sender;

				if (pcbFrom.Image != null && pcbFrom.BackColor != Color.Red)
				{
					LocationOfPicturebox(pcbFrom.Name);
					currentPiece = piecelist.FirstOrDefault(x => x.GetCurrentHorizontal() == horizontal && x.GetCurrentVertical() == vertical);
					Console.WriteLine(currentPiece.GetName());
					GetBoardoptions();
					updateBoardPieceLocations();
					pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
				}
			}

		}

		private void LocationOfPicturebox(string pictureboxName)
		{
			switch (pictureboxName)
			{
				case "pcbBoardOne": horizontal = 1; vertical = 1; break;
				case "pcbBoardTwo": horizontal = 2; vertical = 1; break;
				case "pcbBoardThree": horizontal = 3; vertical = 1; break;
				case "pcbBoardFour": horizontal = 1; vertical = 2; break;
				case "pcbBoardFive": horizontal = 2; vertical = 2; break;
				case "pcbBoardSix": horizontal = 3; vertical = 2; break;
				case "pcbBoardSeven": horizontal = 1; vertical = 3; break;
				case "pcbBoardEight": horizontal = 2; vertical = 3; break;
				case "pcbBoardNine": horizontal = 3; vertical = 3; break;
				default:

					break;
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
		}


		public void updateBoardPieceLocations()
		{
			for(int i = 0; i < pieceOptions.Length; i += 2)
			{
				foreach(PictureBox pictureBox in gbxBoard.Controls.OfType<PictureBox>())
				{
					if (pictureBox.Tag.ToString() == pieceOptions[i].ToString() + pieceOptions[i + 1].ToString() && pictureBox.Image == null)
					{
						pictureBox.BackColor = Color.Green;
						
					}
				}
			}
		}

		public void clearBoardColors()
		{
			foreach (PictureBox pictureBox in gbxBoard.Controls.OfType<PictureBox>())
			{
				pictureBox.BackColor = Color.Transparent;
				pictureBox.Enabled = true;
			}
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
				vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(1, 1));
				currentPiece.SetLocation(horizontal, vertical);
				pcbTo.BackColor = Color.Transparent;


				if (pcbFrom.Parent is GroupBox groupBox && groupBox.Name == "gbxPieces")
				{
					pcbFrom.BackColor = Color.Red;
					checkRdo();
				}

				else
				{
					
					pcbFrom.Image = null;
					clearBoardColors();
					ChangeTurns();
				}
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

		public void checkRdo()
		{
			if(gbxPieces.Controls.OfType<PictureBox>().All(pb => pb.BackColor == Color.Red))
			{
				rdoBlack.Enabled = false;
				rdoWhite.Enabled = false;
			}
		}

		public void ChangeTurns()
		{
			teamColor = currentPiece.GetTeamColor();

			if (teamColor == "White")
			{
				//playerTurn = "playerTwo";
				lblText.Text = "Its players two turns to pick a champion";
				teamColor = "Black";

				foreach (Pieces item in piecelist)
				{
					if (item.GetTeamColor() == "White")
					{
						Board currentboard = boardlist.FirstOrDefault(x => x.GetHorizontal() == item.GetCurrentHorizontal() && x.GetVertical() == item.GetCurrentVertical());
						foreach (PictureBox pictureBox in gbxBoard.Controls.OfType<PictureBox>())
						{
							if (currentboard.GetImagename() == pictureBox.Name)
							{
								pictureBox.BackColor = Color.Red;
								pictureBox.Enabled = false;
							}
						}
					}
				}
			}
			else
			{
				lblText.Text = "Its players One turns to pick a champion";
				teamColor = "White";

				foreach (Pieces item in piecelist)
				{
					if (item.GetTeamColor() == "Black")
					{
						Board currentboard = boardlist.FirstOrDefault(x => x.GetHorizontal() == item.GetCurrentHorizontal() && x.GetVertical() == item.GetCurrentVertical());
						foreach (PictureBox pictureBox in gbxBoard.Controls.OfType<PictureBox>())
						{
							if (currentboard.GetImagename() == pictureBox.Name)
							{
								pictureBox.BackColor = Color.Red;
								pictureBox.Enabled = false;
							}
						}
					}
				}
			}


		}
		
	}
}
