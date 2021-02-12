using System.Drawing;

namespace Puzzle2D.Extentions
{
    public static class PanelColorExtentions
    {
        public static void pickNextColor(this ref PanelColor color)
        {
            switch (color)
            {
                case (PanelColor.Unknown):
                    color = PanelColor.Black;
                    break;
                case (PanelColor.Black):
                    color = PanelColor.Blue;
                    break;
                case (PanelColor.Blue):
                    color = PanelColor.Red;
                    break;
                case (PanelColor.Red):
                    color = PanelColor.Yellow;
                    break;
                case (PanelColor.Yellow):
                    color = PanelColor.Black;
                    break;
            }
        }

        public static Pen ConvertToPen(this PanelColor color)
        {
            switch (color)
            {
                case (PanelColor.Unknown): return new Pen(Color.Coral);
                case (PanelColor.Black): return new Pen(Color.Black);
                case (PanelColor.Blue): return new Pen(Color.Blue);
                case (PanelColor.Red): return new Pen(Color.Red);
                case (PanelColor.Yellow): return new Pen(Color.Yellow);
                default: return new Pen(Color.Coral);
            }
        }
        public static Brush ConvertToBrush(this PanelColor color)
        {
            switch (color)
            {
                case (PanelColor.Unknown): return Brushes.LightGray;
                case (PanelColor.Black): return Brushes.Black;
                case (PanelColor.Blue): return Brushes.Blue;
                case (PanelColor.Red): return Brushes.Red;
                case (PanelColor.Yellow): return Brushes.Yellow;
                default: return Brushes.LightGray;
            }
        }
        public static Color ConvertToColor(this PanelColor color)
        {
            switch (color)
            {
                case (PanelColor.Unknown): return Color.LightGray;
                case (PanelColor.Black): return Color.Black;
                case (PanelColor.Blue): return Color.Blue;
                case (PanelColor.Red): return Color.Red;
                case (PanelColor.Yellow): return Color.Yellow;
                default: return Color.LightGray;
            }
        }
        
        public static int ConvertToInt(this PanelColor color)
        {
            switch (color)
            {
                case (PanelColor.Unknown): return 1;
                case (PanelColor.Black): return 2;
                case (PanelColor.Blue): return 3;
                case (PanelColor.Red): return 4;
                case (PanelColor.Yellow): return 5;
                default: return 6;
            }
        }


        public static string SerializeObject(this PanelColor[,] toSerialize)
        {
            string result = "";
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    result += toSerialize[x, y].ConvertToInt().ToString();
                }
            }
            return result;
        }
    }
}
