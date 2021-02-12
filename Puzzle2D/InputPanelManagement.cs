using Puzzle2D.Extentions;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Puzzle2D
{
    class InputPanelManagement
    {

        public PanelColor[,] table = new PanelColor[8,8];
        private Panel FormsPanel;
        private int CellWidth;
        private int CellHeight;
        private float lineThickness = 2.0F;

        public InputPanelManagement(Panel panel1)
        {
            FormsPanel = panel1;
            CellWidth = FormsPanel.Width/8;
            CellHeight = FormsPanel.Height/8;
        }

        internal void ReadTableValues(string FileName)
        {
            var text = File.ReadAllText(FileName.ToString());
            table = text.DeserializePanelColorTable();
        }

        public void PrintLines(PaintEventArgs e) 
        {
            Pen pen = new Pen(Brushes.Black);
            pen.Width = lineThickness;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            for (int i = 0; i <= 8; i++)
            {
                e.Graphics.DrawLine(pen, new Point(0, i * CellHeight), new Point(FormsPanel.Width, i * CellHeight));
            }
            for (int j = 0; j <= 8; j++)
            {
                e.Graphics.DrawLine(pen, new Point(j * CellWidth, 0), new Point(j * CellWidth, FormsPanel.Height));
            }
        }

        internal void SaveTableValues(string fileName)
        {
            string text = table.SerializeObject();
            File.WriteAllText(fileName ,text);
        }

        internal Dictionary<PanelColor, int> CountColors()
        {
            Dictionary<PanelColor, int> counter = new Dictionary<PanelColor, int>();
            foreach (var item in table)
            {
                if (!counter.ContainsKey(item)) counter.Add(item, 1);
                counter[item] += 1;
            }
            return counter;
        }

        internal void ClearTable()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    table[x, y] = PanelColor.Black;
                }
            }
        }

        public void PrintColors(PaintEventArgs e) 
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (table[x, y] != PanelColor.Unknown)
                    {
                        PrintColor(x, y);
                    }
                }
            }             
        }

        private void PrintColor(int x, int y)
        {
            var e = FormsPanel.CreateGraphics();
            Rectangle rec = new Rectangle(x * CellWidth + (int)lineThickness, y * CellHeight + (int)lineThickness, CellWidth - 2 * (int)lineThickness, CellHeight - 2 * (int)lineThickness);
            e.FillRectangle(table[x, y].ConvertToBrush(), rec);
        }

        public void PanelClick(MouseEventArgs e) 
        {
            int x = e.X / CellWidth;
            int y = e.Y / CellHeight;
            table[x, y].pickNextColor();
            PrintColor(x,y);
        }
    }
}
