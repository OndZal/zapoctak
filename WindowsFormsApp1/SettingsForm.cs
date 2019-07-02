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
    public partial class SettingsForm : Form
    {
        public List<Color> Colors;
        protected List<IndexedButton> colorButtons = new List<IndexedButton>();
        public SettingsForm(List<Color> colors)
        {
            InitializeComponent();
            Colors = colors;
            for (int i = 0; i < Colors.Count; i++)
            {
                var newButton = new IndexedButton(i, Colors[i]);
                colorButtons.Add(newButton);
                Controls.Add(newButton);
                newButton.Click += new EventHandler(this.ColorPick_Click);
            }
        }
        public void ColorPick_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as IndexedButton).BackColor = colorDialog1.Color;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Colors.Clear();
            foreach (var item in colorButtons)
            {
                Colors.Insert(item.index, Color.FromArgb(item.BackColor.ToArgb()));
            }
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var newButton = new IndexedButton(colorButtons.Count, colorDialog1.Color);
                colorButtons.Add(newButton);
                Controls.Add(newButton);
                newButton.Click += new EventHandler(this.ColorPick_Click);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (colorButtons.Count > 2)
            {
                IndexedButton toRemove = colorButtons.Last();
                Controls.Remove(toRemove);
                colorButtons.Remove(toRemove);
                toRemove.Dispose();
            }
            else
                MessageBox.Show("Cannot have less than two colors");
        }
    }
}
