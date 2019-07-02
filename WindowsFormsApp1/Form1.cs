using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected TurmiteController Turmites;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Black);
            Turmites = new TurmiteController((Bitmap)pictureBox1.Image);
            Turmites.Colors.Add(Color.FromArgb(255,0,0,0));
            Turmites.Colors.Add(Color.FromArgb(255, 255, 255, 255));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addDialog = new AddForm();
            addDialog.ShowDialog();
            if (addDialog.DialogResult == DialogResult.OK)
            {
                addDialog.toAdd.controller = Turmites;
                addDialog.toAdd.x = pictureBox1.Image.Width / 2;
                addDialog.toAdd.y = pictureBox1.Image.Height / 2;
                Turmites.Turmites.Add(addDialog.toAdd);
            }
            addDialog.Dispose();
        }
        bool paused = true;
        private void playButton_Click(object sender, EventArgs e)
        {
            if (Turmites.Turmites.Count != 0)
                paused = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            paused = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!paused)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Turmites.NextStep();
                    }
                    pictureBox1.Refresh();
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            paused = true;
            g.Clear(Turmites.Colors[0]);
            Turmites.Turmites.Clear();
            pictureBox1.Refresh();
        }
    }
}
