using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzle2D.VirtualBoard
{
    class Board
    {
        public string History;
		public Task BoardTask;
		public List<Brick> bricksOnBoard = new List<Brick>();

		int NumberOfStaticBricks;
		string OutputFolder;
		BricksCollection bricksCollection;
		PanelColor[,] Pattern;

		public Board(string history, PanelColor[,] pattern, string outputFolder)
        {
			History = history;
			bricksCollection = BricksCollection.load();
			bricksCollection.ChangeAccordingTo(history);
			NumberOfStaticBricks = history.Length / 4;
			Pattern = pattern;
			OutputFolder = outputFolder;
		}

        private void AddBrick(Brick brick) 
        {
			bricksOnBoard.Add(brick);
        }

        private void RemoveBrick(Brick brick) 
        {
			bricksOnBoard.Remove(brick);
        }

		public bool IsThereAColision(Brick newBrick)
		{
			foreach (var brick in bricksOnBoard)
			{
				foreach (var block in brick.blocks)
				{
					if (newBrick.DoYouHave(block.posX, block.posY))
					{
						return true;
					} 
				}
			}
			return false;
		}

        private bool IsOnBoard(Brick newbrick)
        {
			return bricksOnBoard.Contains(newbrick);
        }

		internal bool DoesFitToPattern(Brick brick)
		{
			foreach (var block in brick.blocks)
			{
				if ((brick.side == "A" ? block.colorSideA : block.colorSideB) != Pattern[block.posX - 8, block.posY - 8]) return false;
			}
			return true;
		}

		public bool MoveToNextCorrectPosition(Brick newbrick)
		{
			if (IsOnBoard(newbrick))
			{
				RemoveBrick(newbrick);
				if (newbrick.MoveToNextFitBoxPosition()) return false;
			}
			
			while ((IsThereAColision(newbrick) || !newbrick.DoesItFitInBox() || !DoesFitToPattern(newbrick))) 
			{
				if(newbrick.MoveToNextFitBoxPosition()) return false;
			}
			AddBrick(newbrick);
			return true;
		}

		internal bool AddBrickRecursion(int numberOfBrick) 
		{
			if (numberOfBrick == 18) 
			{
				printBoard(SaveStateOfBoard());
				return false;
			}
			Brick newBrick = bricksCollection.Collection.Single(x => x.number == numberOfBrick);
			while (MoveToNextCorrectPosition(newBrick))
			{
				if (AddBrickRecursion(numberOfBrick + 1)) return true;
			}
			if (NumberOfStaticBricks >= numberOfBrick) return true;
			newBrick.ResetPosition();
			return false;
		}

		internal string AddBrickRecursionState(string numberOfBrick) 
		{
			if (Int32.Parse(numberOfBrick) == NumberOfStaticBricks) 
			{				
				return SaveStateOfBoard();
			}
			Brick newBrick = bricksCollection.Collection.Single(x => x.number == Int32.Parse(numberOfBrick));
			while (MoveToNextCorrectPosition(newBrick))
			{
				var result = AddBrickRecursionState((Int32.Parse(numberOfBrick) + 1).ToString());
				if (result != "") return result;
			}
 			newBrick.ResetPosition();
			return "";
		}

		internal void Start()
		{
			Action<object> action = (object obj) =>
			{
				AddBrickRecursion(0);
			};
			Task t1 = new Task(action, "alpha");
			t1.Start();
			BoardTask = t1;
		}

		#region Print board
		public void printBoard(string FileName = "")
        {
            var Start = File.ReadAllText(@"VirtualBoard\Board\Start.txt");
            var End = File.ReadAllText(@"VirtualBoard\Board\End.txt");

			FileName = "" == FileName ? Path.GetRandomFileName() : FileName;
			FileName += ".html";
			File.WriteAllText(Path.Combine(OutputFolder, FileName), "");
			File.AppendAllText(Path.Combine(OutputFolder, FileName), Start);

			int j = 8;
			while (j < 16) 
			{
				int i = 8;
				while (i < 16) 
				{					
					File.AppendAllText(Path.Combine(OutputFolder, FileName), valueOfField(i, j));
					File.AppendAllText(Path.Combine(OutputFolder, FileName), verticalBorder(i, j));
					i++;
				}
				i = 8;
				File.AppendAllText(Path.Combine(OutputFolder, FileName), "<div style = \"clear:both;\" ></div>\n");
				while (i < 16) 
				{
					File.AppendAllText(Path.Combine(OutputFolder, FileName), horizontalBorder(i, j));
					i++;
				}
				j++;
				File.AppendAllText(Path.Combine(OutputFolder, FileName), "<div style = \"clear:both;\" ></div>\n");
			}
			File.AppendAllText(Path.Combine(OutputFolder, FileName), End);
		}

        public string valueOfField(int inPosX, int inPosY) 
		{
            foreach (var brick in bricksOnBoard)
            {
                foreach (var block in brick.blocks)
                {
					if (block.posX == inPosX && block.posY == inPosY) 
					{
						return "<div class = \"squareKaleidoscope" + (brick.side == "A" ? block.colorSideA.ToString() : block.colorSideB.ToString()) + "\"></div>\n";
					}
				}
            }
			return "<div class = \"squareKaleidoscopeEmpty\"></div>\n";
		}
		public string verticalBorder(int inPosX, int inPosY)
		{
			if (inPosX == 22) return "";
			foreach (var brick in bricksOnBoard)
			{
				foreach (var block in brick.blocks)
				{
					if (block.posX == inPosX && block.posY == inPosY)
					{
						if(brick.DoYouHave(inPosX+1,inPosY)) return "<div class = \"openHorizontalBorder\"></div>\n";
					}
				}
			}
			return "<div class = \"closeHorizontalBorder\"></div>\n";
		}
		public string horizontalBorder(int inPosX, int inPosY)
		{
			if (inPosY == 22) return "";
			foreach (var brick in bricksOnBoard)
			{
				foreach (var block in brick.blocks)
				{
					if (block.posX == inPosX && block.posY == inPosY)
					{
						if (brick.DoYouHave(inPosX, inPosY + 1)) return "<div class = \"openVerticalBorder\"></div>\n";
					}
				}
			}
			return "<div class = \"closeVerticalBorder\"></div>\n";
		}
		#endregion

		public string SaveStateOfBoard() 
		{
			string result = "";
			foreach (var brick in bricksOnBoard)
			{
				result += brick.side + brick.rotation + (brick.blocks.Single(x => x.number == 0).posX - 8).ToString()  + (brick.blocks.Single(x => x.number == 0).posY -8).ToString();
			}
			return result;
		}

		#region Experimental methods

		private bool DoesItEmpty(int x, int y)
		{
			foreach (var brick in bricksOnBoard)
			{
				if (brick.DoYouHave(x, y))
				{
					return false;
				}
			}
			return true;
		}

		private int NumberOfSingleEmptyPlace_SimpleMethod()
		{
			int result = 0;

			for (int x = 8; x < 16; x++)
			{
				for (int y = 8; y < 16; y++)
				{
					if (DoesItEmpty(x, y))
					{
						int innerCount = 0;
						if ((x != 8) && (DoesItEmpty(x - 1, y))) innerCount++;
						if ((y != 8) && (DoesItEmpty(x , y - 1))) innerCount++;
						if ((x != 15) && (DoesItEmpty(x + 1, y))) innerCount++;
						if ((y != 15) && (DoesItEmpty(x, y + 1))) innerCount++;
						if (innerCount == 0) result++;
					}
				}
			}

			return result;
		}
        #endregion

    }
}
