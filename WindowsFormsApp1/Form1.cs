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
        public Turmite test;
        public Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Black);
            test = new Turmite(2, 2, (Bitmap)pictureBox1.Image);
            test.colors[0] = Color.Black;
            test.colors[1] = Color.White;
            test.turnTable[0, 0] = Turns.Left;
            test.turnTable[0, 1] = Turns.Left;
            test.turnTable[1, 0] = Turns.Right;
            test.turnTable[1, 1] = Turns.Right;
            test.stepTable[0, 0] = 5;
            test.stepTable[0, 1] = 10;
            test.stepTable[1, 0] = 10;
            test.stepTable[1, 1] = 5;
            test.colorTable[0, 0] = 1;
            test.colorTable[0, 1] = 0;
            test.colorTable[1, 0] = 0;
            test.colorTable[1, 1] = 1;
            test.stateTable[0, 0] = 0;
            test.stateTable[0, 1] = 1;
            test.stateTable[1, 0] = 0;
            test.stateTable[1, 1] = 0;
            test.x = pictureBox1.Width / 2;
            test.y = pictureBox1.Height / 2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                test.Step();
                pictureBox1.Refresh();
            }
        }
    }
}
