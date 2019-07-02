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
            Turmites.Colors.Add(Color.FromArgb(255, 255, 0, 0));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            paused = true;
            AddForm addDialog = new AddForm();
            addDialog.ShowDialog();
            if (addDialog.DialogResult == DialogResult.OK)
            {
                if (addDialog.toAdd.stateTable.GetUpperBound(1) + 1 > Turmites.Colors.Count)
                {
                    MessageBox.Show("Not enough colors defined for selected turmite.");
                }
                else
                if (addDialog.toAdd.stateTable.GetUpperBound(1) + 1 < Turmites.Colors.Count)
                {
                    MessageBox.Show("Selected turmite is unable to handle all defined colors.");
                }
                else
                {
                    addDialog.toAdd.controller = Turmites;
                    addDialog.toAdd.x = pictureBox1.Image.Width / 2;
                    addDialog.toAdd.y = pictureBox1.Image.Height / 2;
                    Turmites.Turmites.Add(addDialog.toAdd);
                }
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

        protected void ClearBoard()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Turmites.bitmap = (Bitmap)pictureBox1.Image;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            paused = true;
            g.Clear(Turmites.Colors[0]);
            Turmites.Turmites.Clear();
            pictureBox1.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            int input;
            if (!int.TryParse(toolStripTextBox1.Text, out input))
            {
                MessageBox.Show("NaN, m8");
                toolStripTextBox1.Text = "100";
            }
            else
            {
                for (int i = 0; i < input; i++)
                {
                    Turmites.NextStep();
                    pictureBox1.Refresh();
                }
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            paused = true;
            var settings = new SettingsForm(Turmites.Colors);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                ClearBoard();
            }
        }
    }
}
