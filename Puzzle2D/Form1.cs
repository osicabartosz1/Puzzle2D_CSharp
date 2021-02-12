using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Puzzle2D.VirtualBoard;
using Puzzle2D.MultiThread;
using System.IO;

namespace Puzzle2D
{
    public partial class Form1 : Form
    {
        MultiThreads multiThread;
        public Form1()
        {
            InitializeComponent();
            panel = new InputPanelManagement(panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string name = openFileDialog1.FileName;
            
            if (name == null || name == "") return;
            try
            {
                panel.ReadTableValues(name);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel.PrintLines(e);
            panel.PrintColors(e);
        }

        private void button3_Click(object sender, EventArgs e)//Save
        {
            saveFileDialog1.ShowDialog();
            string name = saveFileDialog1.FileName;
            if (name == null || name == "") return;
            try
            {
                panel.SaveTableValues(name);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Count Colors
            panel.CountColors();

            //Check Feasibility
            //TODO


            //Success
            panel1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Visible = false;
            button1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Visible = true;
            button3.Enabled = false;
            button3.Visible = true;
            button4.Visible = true;
            button4.Visible = true;
            panel1.Enabled = true;
            panel.ClearTable();
            panel1.Refresh();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            panel.PanelClick(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
            folderBrowserDialog1.ShowDialog();
            string name = folderBrowserDialog1.SelectedPath;
            if (name == null || name == "") return;
            button5.Enabled = false;
            button6.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = false;

            try
            {
                Directory.CreateDirectory(name);
                multiThread = new MultiThreads(panel.table, Int32.Parse(Value_NumberOfThreads.Text), Int32.Parse(Value_NumberOfStaticBricks.Text), name);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            if (textBox1.Text.Length / 4 != Int32.Parse(Value_NumberOfStaticBricks.Text))
                textBox1.Text = multiThread.GetFirstStaticBoardState();

            multiThread.LatestStaticBoard = textBox1.Text;
            multiThread.StartObserver();
        }


        private void Value_NumberOfThreads_Click(object sender, EventArgs e)
        {
            Value_NumberOfThreads.Text = (Int32.Parse(Value_NumberOfThreads.Text)%8 + 1).ToString();
        }

        private void Value_NumberOfStaticBricks_Click(object sender, EventArgs e)
        {
            Value_NumberOfStaticBricks.Text = (Int32.Parse(Value_NumberOfStaticBricks.Text) % 15 + 1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            multiThread.NumberOfThreads = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            if (textBox1.Text.Length / 4 != Int32.Parse(Value_NumberOfStaticBricks.Text)) textBox1.Text = "";
        }

        private void button5_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (multiThread == null) return;
            if (multiThread.Observer == null) return;
            if (multiThread.Observer.Status == TaskStatus.RanToCompletion)
            {
                button5.Enabled = true;
                button2.Enabled = true;
                button1.Enabled = true;
            }
            progressBar2.Value = (int)Math.Ceiling(multiThread.CalculateProgres);
            label3.Text = multiThread.LatestStaticBoard;
        }
    }
}
