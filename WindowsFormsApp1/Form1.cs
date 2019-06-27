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
            test.stepTable[0, 0] = 1;
            test.stepTable[0, 1] = 2;
            test.stepTable[1, 0] = 2;
            test.stepTable[1, 1] = 1;
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
    public enum Turns { Left = -1, None, Right }
    public enum Directions { Up, Right, Down, Left }
    public class Turmite
    {
        static protected int[] x_movement = { 0, 1, 0, -1 };
        static protected int[] y_movement = { -1, 0, 1, 0 };
        public int x = 0, y = 0;
        public int state = 0;
        public int[,] stateTable;
        public int[,] stepTable;
        public int[,] colorTable;
        public Directions orientation;
        public Turns[,] turnTable;
        public Color[] colors;
        protected Bitmap map;
        public Turmite(int stateCount, int colorCount, Bitmap bitmap)
        {
            stateTable = new int[stateCount, colorCount];
            stepTable = new int[stateCount, colorCount];
            colorTable = new int[stateCount, colorCount];
            turnTable = new Turns[stateCount, colorCount];
            colors = new Color[colorCount];
            map = bitmap;
        }
        public void Step()
        {
            Color currentColor = map.GetPixel(x, y);
            int colorIndex = colors.Length;
            for (int i = 0; i < colors.Length; i++)
            {
                if (currentColor.ToArgb() == colors[i].ToArgb())
                {
                    colorIndex = i;
                    break;
                }
            }
            if (colorIndex == colors.Length)
                throw new Exception();
            orientation = (Directions)(((int)orientation + (int)turnTable[state, colorIndex]) % 4); // tenhle vypocet potrebuje zkraslit
            if ((int)orientation == -1) 
            {
                orientation = Directions.Left;
            }
            map.SetPixel(x, y, colors[colorTable[state, colorIndex]]);
            for (int i = 0; i < stepTable[state, colorIndex]; i++)
            {
                x += x_movement[(int)orientation];
                if (x == -1)
                {
                    x = map.Width - 1;
                }
                if (x == map.Width)
                {
                    x = 0;
                }
                y += y_movement[(int)orientation];
                if (y == -1)
                {
                    y = map.Height - 1;
                }
                if (y == map.Height)
                {
                    y = 0;
                }
            }
            state = stateTable[state, colorIndex];
        }
    }
}
