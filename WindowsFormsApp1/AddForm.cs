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
            saveFileDialog1.DefaultExt = ".TXT";
        }
        protected NumericUpDown[,] colorTable;
        protected NumericUpDown[,] stateTable;
        protected NumericUpDown[,] stepTable;
        protected ComboBox[,] turnTable;
        protected List<Label> generatedLabels = new List<Label>();
        public Turmite toAdd = null;

        protected void generateTableControls()
        {
            foreach(var item in generatedLabels)
            {
                Controls.Remove(item);
            }
            generatedLabels.Clear();

            if (stateTable != null)
                foreach (var item in stateTable)
                {
                    Controls.Remove(item);
                }

            if (colorTable != null)
                foreach (var item in colorTable)
                {
                    Controls.Remove(item);
                }

            if (stepTable != null)
                foreach (var item in stepTable)
                {
                    Controls.Remove(item);
                }

            if (turnTable != null)
                foreach (var item in turnTable)
                {
                    Controls.Remove(item);
                }

            int states = (int)stateCounter.Value;
            int colors = (int)colorCounter.Value;
            stateTable = new NumericUpDown[states, colors];
            colorTable = new NumericUpDown[states, colors];
            stepTable = new NumericUpDown[states, colors];
            turnTable = new ComboBox[states, colors];
            for (int state = 0; state < states; state++)
            {
                for (int color = 0; color < colors; color++)
                {
                    Label label = new Label
                    {
                        Location = new Point(25, 94 + (state * colors + color) * 26),
                        Name = "label1",
                        Size = new Size(45, 26),
                        TabIndex = 18,
                        Text = state.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    Controls.Add(label);
                    generatedLabels.Add(label);

                    label = new Label
                    {
                        Location = new Point(73, 94 + (state * colors + color) * 26),
                        Name = "label2",
                        Size = new Size(45, 26),
                        TabIndex = 19,
                        Text = color.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    Controls.Add(label);
                    generatedLabels.Add(label);

                    stateTable[state, color] = new NumericUpDown
                    {
                        Location = new System.Drawing.Point(127, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown4",
                        Size = new System.Drawing.Size(72, 21),
                        TabIndex = 15,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(stateTable[state, color]);

                    colorTable[state, color] = new NumericUpDown
                    {
                        Location = new System.Drawing.Point(198, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown3",
                        Size = new System.Drawing.Size(82, 21),
                        TabIndex = 14,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(colorTable[state, color]);

                    stepTable[state, color] = new NumericUpDown
                    {
                        Location = new System.Drawing.Point(280, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown2",
                        Size = new System.Drawing.Size(65, 21),
                        TabIndex = 13,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(stepTable[state, color]);

                    turnTable[state, color] = new ComboBox
                    {
                        DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                        Location = new System.Drawing.Point(345, 98 + (state * colors + color) * 26),
                        Name = "comboBox1",
                        Size = new System.Drawing.Size(62, 21),
                        TabIndex = 17
                    };
                    turnTable[state, color].Items.AddRange(new object[] { "Left", "None", "Right" });
                    turnTable[state, color].SelectedIndex = 1;
                    Controls.Add(turnTable[state, color]);
                }
            }
        }

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
                    stateCounter.Value = stateCount;
                    colorCounter.Value = colorCount;
                    while (!file.EndOfStream)
                    {
                        string[] line = file.ReadLine().Split('='); // line format : <current state>,<current color>=<new state>,<new color>,<number of steps>,<turn(0=left,1=none,2=right)>
                        string[] indices = line[0].Split(',');
                        int state = int.Parse(indices[0]);
                        int color = int.Parse(indices[1]);
                        string[] values = line[1].Split(',');
                        stateTable[state, color].Value = int.Parse(values[0]);
                        colorTable[state, color].Value = int.Parse(values[1]);
                        stepTable[state, color].Value = int.Parse(values[2]);
                        turnTable[state, color].SelectedIndex  = int.Parse(values[3]);
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
            toAdd = new Turmite((int)stateCounter.Value, (int)colorCounter.Value);
            for (int state = 0; state < (int)stateCounter.Value; state++)
            {
                for (int color = 0; color < (int)colorCounter.Value; color++)
                {
                    toAdd.stateTable[state, color] = (int)stateTable[state, color].Value;
                    toAdd.colorTable[state, color] = (int)colorTable[state, color].Value;
                    toAdd.stepTable[state, color] = (int)stepTable[state, color].Value;
                    toAdd.turnTable[state, color] =  (Turns)(int)turnTable[state, color].SelectedIndex;
                }
            }
            toAdd.x = (int)xSetter.Value;
            toAdd.y = (int)ySetter.Value;
            Close();
        }

        private void generateTableButton_Click(object sender, EventArgs e)
        {
            generateTableControls();
        }

        private void Counter_ValueChanged(object sender, EventArgs e)
        {
            generateTableControls();
            saveButton.Enabled = stateCounter.Value != 0 && colorCounter.Value != 0;
            OKButton.Enabled = stateCounter.Value != 0 && colorCounter.Value != 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int colors = (int)colorCounter.Value;
                int states = (int)stateCounter.Value;
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.WriteLine(colors.ToString());
                writer.WriteLine(states.ToString());
                for (int state = 0; state < states; state++)
                {
                    for (int color = 0; color < colors; color++)
                    {
                        writer.WriteLine("{0},{1}={2},{3},{4},{5}", state, color, stateTable[state,color].Value, colorTable[state, color].Value, stepTable[state, color].Value, turnTable[state, color].SelectedIndex);
                    }
                }
                writer.Close();
            }
        }
    }
}
