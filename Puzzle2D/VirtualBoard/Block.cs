namespace Puzzle2D.VirtualBoard
{
    public class Block
    {
        public int posX;
        public int posY;
        public int number;
        public PanelColor colorSideA;
        public PanelColor colorSideB;

        public Block()//needed for serialization
        {
        }
    }
}
