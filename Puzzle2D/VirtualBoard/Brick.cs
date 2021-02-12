using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle2D.VirtualBoard
{
    public class Brick
    {

        public List<Block> blocks = new List<Block>();
		public int rotation = 0;
		public string side = "A";
		public int number;

        public Brick()//needed for serialization
        {

        }

		#region history methods

		public string GetPositionOfBrick()
		{
			Block firstBlock = blocks.Single(x => x.number == 1);
			return side + rotation.ToString() + (firstBlock.posX - 8).ToString() + (firstBlock.posY - 8).ToString();
		}
		
		public void MoveBrickToRequirePosition(string commands)
		{
			while (commands.Substring(0, 1) != side) FlipSide();
			while (commands.Substring(1, 1) != rotation.ToString()) TryTurnBrickClockwise();
			MoveTo(Int32.Parse(commands.Substring(2, 1)) + 8, Int32.Parse(commands.Substring(3, 1)) + 8);
		}

		#endregion history methods

		#region move methods

		public bool TryTurnBrickClockwise() 
		{
			int firstBlokX = 0;
			int firstBlokY = 0;
			rotation++;
            for (int k = 0; k < blocks.Count; k++)
            {
				var blok = blocks.Single(x => x.number == k);
				if (k == 0)
				{
					firstBlokX = blok.posX;
					firstBlokY = blok.posY;
				}
				int oldX = blok.posX;
				int oldY = blok.posY;
				blok.posX = firstBlokX + (firstBlokY - oldY);
				blok.posY = firstBlokY - (firstBlokX - oldX);
			}
			if (rotation >= 4)
			{
				rotation = 0;
				return true;
			}
			else 
			{
				return false;
			}
		}

        public void MoveTo(int inPosX, int inPosY)
		{
			int firstBlockX = 0;
			int firstBlockY = 0;
			for (int k = 0; k < blocks.Count; k++)
			{
				var blok = blocks.Single(x => x.number == k);
				if (k == 0) 
				{
					firstBlockX = blok.posX;
					firstBlockY = blok.posY;
				}
				blok.posX += inPosX - firstBlockX;
				blok.posY += inPosY - firstBlockY;
			}
		}

        public bool FlipSide()
		{
			int firstBlokX = 0;
			int firstBlokY = 0;
			for (int k = 0; k < blocks.Count; k++)
			{
				var blok = blocks.Single(x => x.number == k);
				if (k == 0)
				{
					firstBlokX = blok.posX;
					firstBlokY = blok.posY;
				}
				int oldX = blok.posX;
				int oldY = blok.posY;
				blok.posX = firstBlokX + (firstBlokX - oldX);
			}
			if (side == "B")
			{
				side = "A";
				return true;
			}
			else
			{
				side = "B";
				return false;
			}
		}
        #endregion

        public bool DoYouHave(int inPosX, int inPosY)
		{
			foreach (var blok in blocks)
			{
				if (blok.posX == inPosX && blok.posY == inPosY) return true;
			}
			return false;
		}

		public bool DoesItFitInBox()
		{
			foreach (var blok in blocks)
			{
				if (blok.posX < 8 || blok.posX > 15) return false;
				if (blok.posY < 8 || blok.posY > 15) return false;
			}
			return true;
		}

		#region Advance Move Methods

		internal void ResetPosition()
		{
			while (rotation != 0) TryTurnBrickClockwise();
			MoveTo(8, 8);
		}

		internal bool MoveToNextFitBoxPosition()
		{
			while (true)
			{
				if (MoveToNextPosition()) return true;
				if (DoesItFitInBox()) return false;			
			}
		}
		internal bool MoveToNextPosition()
		{
			Block block = blocks.Single(x => x.number == 0);
			int firstBlockX = block.posX;
			int firstBlockY = block.posY;
			if (firstBlockX >= 7 + 8  && firstBlockY >= 7 + 8 )
			{
				MoveTo(8, 8);
				if (TryTurnBrickClockwise())
				{
					return FlipSide();
				}
				return false;
			}
			if (firstBlockY >= (7 + 8)) MoveTo(firstBlockX + 1, 8);
			if (firstBlockY < (7 + 8)) MoveTo(firstBlockX, firstBlockY + 1);
			return false;
		}
		#endregion Advance Move Methods

	}
}
