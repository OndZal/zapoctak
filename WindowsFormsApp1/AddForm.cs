using System;
using System.IO;
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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public Turmite toAdd = null;

        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog1.FileName);
                int colorCount = 0, stateCount = 0;
                try
                {
                    colorCount = int.Parse(file.ReadLine());
                    stateCount = int.Parse(file.ReadLine());
                    toAdd = new Turmite(stateCount, colorCount);
                    while (!file.EndOfStream)
                    {
                        string[] line = file.ReadLine().Split('='); // line format : <current state>,<current color>=<new state>,<new color>,<number of steps>,<turn(0=left,1=none,2=right)>
                        string[] indices = line[0].Split(',');
                        int state = int.Parse(indices[0]);
                        int color = int.Parse(indices[1]);
                        string[] values = line[1].Split(',');
                        toAdd.stateTable[state, color] = int.Parse(values[0]);
                        toAdd.colorTable[state, color] = int.Parse(values[1]);
                        toAdd.stepTable[state, color] = int.Parse(values[2]);
                        toAdd.turnTable[state, color]  = (Turns)int.Parse(values[3]);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR - Invalid File Format");
                    file.Close();
                    toAdd = null;
                    return;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
