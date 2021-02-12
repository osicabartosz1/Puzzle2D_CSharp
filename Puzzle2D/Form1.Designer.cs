
namespace Puzzle2D
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Value_NumberOfThreads = new System.Windows.Forms.Label();
            this.Value_NumberOfStaticBricks = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 800);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 99);
            this.button1.TabIndex = 1;
            this.button1.Text = "Set a pattern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(828, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 99);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load a pattern";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(828, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(239, 99);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save a pattern";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(828, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(239, 99);
            this.button4.TabIndex = 4;
            this.button4.Text = "Check and Done";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(828, 593);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(239, 99);
            this.button5.TabIndex = 5;
            this.button5.Text = "Solve";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.EnabledChanged += new System.EventHandler(this.button5_EnabledChanged);
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(848, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number Of Threads";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number Of Static Bricks";
            // 
            // Value_NumberOfThreads
            // 
            this.Value_NumberOfThreads.AutoSize = true;
            this.Value_NumberOfThreads.Location = new System.Drawing.Point(1041, 485);
            this.Value_NumberOfThreads.Name = "Value_NumberOfThreads";
            this.Value_NumberOfThreads.Size = new System.Drawing.Size(16, 17);
            this.Value_NumberOfThreads.TabIndex = 8;
            this.Value_NumberOfThreads.Text = "2";
            this.Value_NumberOfThreads.Click += new System.EventHandler(this.Value_NumberOfThreads_Click);
            // 
            // Value_NumberOfStaticBricks
            // 
            this.Value_NumberOfStaticBricks.AutoSize = true;
            this.Value_NumberOfStaticBricks.Location = new System.Drawing.Point(1041, 522);
            this.Value_NumberOfStaticBricks.Name = "Value_NumberOfStaticBricks";
            this.Value_NumberOfStaticBricks.Size = new System.Drawing.Size(16, 17);
            this.Value_NumberOfStaticBricks.TabIndex = 9;
            this.Value_NumberOfStaticBricks.Text = "3";
            this.Value_NumberOfStaticBricks.Click += new System.EventHandler(this.Value_NumberOfStaticBricks_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(828, 711);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(239, 99);
            this.button6.TabIndex = 10;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(828, 436);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(22, 821);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(788, 44);
            this.progressBar2.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(848, 835);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Current State";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 877);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Value_NumberOfStaticBricks);
            this.Controls.Add(this.Value_NumberOfThreads);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Puzzle2D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        InputPanelManagement panel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Value_NumberOfThreads;
        private System.Windows.Forms.Label Value_NumberOfStaticBricks;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
    }
}

