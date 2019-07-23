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
    // the main form in which the turmites are drawn
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        protected TurmiteController turmites;

        // Itializes board and sets some default values.
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Black);
            turmites = new TurmiteController((Bitmap)pictureBox1.Image);
            turmites.colors.Add(Color.FromArgb(255,0,0,0));
            turmites.colors.Add(Color.FromArgb(255, 255, 255, 255));
        }

        // Gets a turmite from an "Addform", checks whether it uses the same number of colors as is set and whether it is in the bounds of the board.
        private void AddButton_Click(object sender, EventArgs e)
        {
            paused = true;
            AddForm addDialog = new AddForm();
            addDialog.ShowDialog();
            if (addDialog.DialogResult == DialogResult.OK)
            {
                if (addDialog.toAdd.stateTable.GetUpperBound(1) + 1 > turmites.colors.Count)
                {
                    MessageBox.Show("Not enough colors defined for selected turmite.");
                }
                else
                if (addDialog.toAdd.stateTable.GetUpperBound(1) + 1 < turmites.colors.Count)
                {
                    MessageBox.Show("Selected turmite is unable to handle all defined colors.");
                }
                else
                {
                    addDialog.toAdd.controller = turmites;
                    addDialog.toAdd.x = pictureBox1.Image.Width < addDialog.toAdd.x ? pictureBox1.Image.Width : addDialog.toAdd.x;
                    addDialog.toAdd.y = pictureBox1.Image.Height < addDialog.toAdd.y ? pictureBox1.Image.Height : addDialog.toAdd.y;
                    turmites.turmites.Add(addDialog.toAdd);
                }
            }
            addDialog.Dispose();
        }

        private bool paused = true;

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (turmites.turmites.Count != 0)
                paused = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            paused = true;
        }

        // Does 50 steps and 5 board redraws a millisecond, making the drawing reasonably fast.
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!paused)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        turmites.NextStep();
                    }
                    pictureBox1.Refresh();
                }
            }
        }

        // Resets the board to color 0 and removes all turmites.
        protected void ClearBoard()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            turmites.bitmap = (Bitmap)pictureBox1.Image;
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            paused = true;
            g.Clear(turmites.colors[0]);
            turmites.turmites.Clear();
            pictureBox1.Refresh();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }
        
        // Prevents the user from typing non-numbers in the text box for cutom number of steps.
        private void ToolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Makes a custom number of steps (in total, not per turmite).
        private void StepButton_Click(object sender, EventArgs e)
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
                    turmites.NextStep();
                    pictureBox1.Refresh();
                }
            }
        }

        // Shows the setting form, and if any changes have been made clears the board, because any pixel can potentially have an undefined color
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            paused = true;
            var settings = new SettingsForm(turmites.colors);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                ClearBoard();
            }
        }
    }
}
