using System.Linq;

namespace Puzzle2D.Extentions
{
    public static class StringExtentions
    {
        public static PanelColor[,] DeserializePanelColorTable(this string toDeserialize)
        {
            PanelColor[,] result = new PanelColor[8,8];
            char[] serialised = toDeserialize.ToArray();

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    result[x,y] = serialised[x * 8 + y].ToString().ConvertToInt();
                }
            }
            return result;
        }

        public static PanelColor ConvertToInt(this string color)
        {
            switch (color)
            {
                case ("2"): return PanelColor.Black;
                case ("3"): return PanelColor.Blue;
                case ("4"): return PanelColor.Red;
                case ("5"): return PanelColor.Yellow;
                default: return PanelColor.Unknown;
            }
        }
    }
}
