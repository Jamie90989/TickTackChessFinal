using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TickTackChessJmaa
{
	class Pieces
	{
		private string name = "";
		private string moveOptions = "";
		private int curHor, curVer, newHor, newVer;

		public Pieces(string c_name)
		{
			name = c_name;
		}

		public string GetName()
		{
			return name;
		}

		public void SetLocation(int _newHor, int _newVer)
		{
			curHor = _newHor;
			curVer = _newVer;
		}

		public string GetMoveoptions(int _newHor, int _newVer)
		{
			newHor = _newHor;
			newVer = _newVer;
			moveOptions = "";

			switch (name)
			{
				
				case "pcbrookBlack":
					MoveRook();
					break;
				case "pcbrookWhitebg":
					MoveRook();
					break;
				case "pcbknightBlackbg":
					MoveKnight();
					break;
				case "pcbknightWhite":
					MoveKnight();
					break;
				case "pcbqueenBlackbg":
					MoveQueen();
					break;
				case "pcbqueenWhite":
					MoveQueen();
					break;
				default: break;
			}

			return moveOptions;
		}

		public void MoveRook()
		{
			int temp_hor = Math.Abs(newHor - curHor);
			int temp_ver = Math.Abs(newVer - curVer);

			if (temp_ver == 2 || temp_ver == 1)
			{
				if (temp_hor == 0)
				{
					moveOptions = $"{newHor}{newVer}";
				}

			}
			else if (temp_hor == 2 || temp_hor == 1)
			{
				if (temp_ver == 0)
				{
					moveOptions = $"{newHor}{newVer}";
				}
			}
			Console.WriteLine(moveOptions + "test");
		}
		public void MoveKnight()
		{
			int temp_hor = Math.Abs(newHor - curHor);
			int temp_ver = Math.Abs(newVer - curVer);

			if ((temp_hor == 2 && temp_ver == 1) || (temp_hor == 1 && temp_ver == 2))
			{
				moveOptions = $"{newHor}{newVer}"; // Valid knight move
			}

		}
		public void MoveQueen()
		{
			int temp_hor = Math.Abs(newHor - curHor);
			int temp_ver = Math.Abs(newVer - curVer);

			if (temp_hor == 0 || temp_ver == 0)
			{
				moveOptions = $"{newHor}{newVer}"; // Valid horizontal or vertical move
			}
			// Diagonal move (bishop-like)
			else if (temp_hor == temp_ver)
			{
				moveOptions = $"{newHor}{newVer}"; // Valid diagonal move
			}
		}

		public int GetCurrentHorizontal()
		{
			return curHor;
		}

		public int GetCurrentVertical()
		{
			return curVer;
		}

	}
}

