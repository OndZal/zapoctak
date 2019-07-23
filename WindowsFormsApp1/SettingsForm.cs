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
    // a form for choosing colors the turmites will operate on
    public partial class SettingsForm : Form
    {
        // the colors the user has defined
        public List<Color> colors;
        
        // the buttons that visually represent the colors and their indices in the list
        protected List<IndexedButton> colorButtons = new List<IndexedButton>();
        
        // The form initializes itself according to xisting settings.
        public SettingsForm(List<Color> colors)
        {
            InitializeComponent();
            this.colors = colors;
            for (int i = 0; i < this.colors.Count; i++)
            {
                var newButton = new IndexedButton(i, this.colors[i]);
                colorButtons.Add(newButton);
                Controls.Add(newButton);
                newButton.Click += new EventHandler(this.ColorPick_Click);
            }
        }

        // handler for "Click" event of a dynamically generated indexedButton; Shows a color picking dialog and updates its' color to the color picked.
        public void ColorPick_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as IndexedButton).BackColor = colorDialog1.Color;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        // Saves the setting and signals for the board to be cleared because it potentially contains colors that are no longer valid.
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            colors.Clear();
            foreach (var item in colorButtons)
            {
                // This standardizes colors, so that it matches the format that the bitmap returns
                colors.Insert(item.index, Color.FromArgb(item.BackColor.ToArgb()));
            }
            Close();
        }

        // Lets user pick a color and adds an indexedButton to hold the color.
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var newButton = new IndexedButton(colorButtons.Count, colorDialog1.Color);
                colorButtons.Add(newButton);
                Controls.Add(newButton);
                newButton.Click += new EventHandler(this.ColorPick_Click);
            }
        }

        // Removes the last button and thus its' assigned color
        private void RemoveButton_Click(object sender, EventArgs e)
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
