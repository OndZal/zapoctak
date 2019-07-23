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
    // a form for creating, saving, editing and loading turmites
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            saveFileDialog1.DefaultExt = ".TXT";
        }

        // tables of controls which hold the data of the turmite to be added
        protected NumericUpDown[,] colorTable;
        protected NumericUpDown[,] stateTable;
        protected NumericUpDown[,] stepTable;
        protected ComboBox[,] turnTable;
        protected List<Label> generatedLabels = new List<Label>();

        //the turmite that to be added in the main form
        public Turmite toAdd = null;

        // Generates a table for a turmite according to numbers of colors and states.
        protected void GenerateTableControls()
        {
            //clearing previously generated controls
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
            // for each situation (state-color combination) the turmite can encounter...
            for (int state = 0; state < states; state++)
            {
                for (int color = 0; color < colors; color++)
                {
                    // a set of two labels representing given situation
                    // a label for current state
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

                    // a label for current color
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

                    // a box for the state to be transitioned into
                    stateTable[state, color] = new NumericUpDown
                    {
                        Maximum = states - 1,
                        Location = new System.Drawing.Point(127, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown4",
                        Size = new System.Drawing.Size(72, 21),
                        TabIndex = 15,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(stateTable[state, color]);

                    // a box for the color to paint the tile(pixel)
                    colorTable[state, color] = new NumericUpDown
                    {
                        Maximum = colors - 1,
                        Location = new System.Drawing.Point(198, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown3",
                        Size = new System.Drawing.Size(82, 21),
                        TabIndex = 14,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(colorTable[state, color]);

                    // a box for amount of steps to take
                    stepTable[state, color] = new NumericUpDown
                    {
                        Location = new System.Drawing.Point(280, 99 + (state * colors + color) * 26),
                        Name = "numericUpDown2",
                        Size = new System.Drawing.Size(65, 21),
                        TabIndex = 13,
                        TextAlign = System.Windows.Forms.HorizontalAlignment.Right
                    };
                    Controls.Add(stepTable[state, color]);

                    // a box for the eventual tur to make
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
                    // setting default chosen turn to 'None"
                    turnTable[state, color].SelectedIndex = 1;
                    Controls.Add(turnTable[state, color]);
                }
            }
        }
        
        // Loads a saved turmite from a file
        private void LoadFile_Click(object sender, EventArgs e)
        {
            // asking the user for a file through a standard dialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog1.FileName);
                int colorCount = 0, stateCount = 0;
                // a lot of int parsing, all unsuccessful parses have the same result
                try
                {
                    colorCount = int.Parse(file.ReadLine());
                    stateCount = int.Parse(file.ReadLine());
                    //setting this triggers the ValueChanged event, which generates the proper controls for method to write in
                    stateCounter.Value = stateCount;
                    colorCounter.Value = colorCount;
                    while (!file.EndOfStream)
                    {
                        // expected line format : <current state>,<current color>=<new state>,<new color>,<number of steps>,<turn(0=left,1=none,2=right)>
                        string[] line = file.ReadLine().Split('=');
                        if (line.Length != 2) throw new FormatException();
                        string[] indices = line[0].Split(',');
                        if (indices.Length != 2) throw new FormatException();
                        int state = int.Parse(indices[0]);
                        int color = int.Parse(indices[1]);
                        string[] values = line[1].Split(',');
                        if (values.Length != 4) throw new FormatException();
                        stateTable[state, color].Value = int.Parse(values[0]);
                        colorTable[state, color].Value = int.Parse(values[1]);
                        stepTable[state, color].Value = int.Parse(values[2]);
                        turnTable[state, color].SelectedIndex  = int.Parse(values[3]);
                    }
                }
                // catces invalid, but parsable values - negative numbers and colors and states over their respective totals
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("ERROR - Invalid Value in File");
                    file.Close();
                    toAdd = null;
                    return;
                }
                // Cathes uparsable values and lines without proper delimiters.
                catch (FormatException)
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
        
        // Takes data from generated controls and initializes turmite
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
        
        // Generates a new table without changing its size
        private void GenerateTableButton_Click(object sender, EventArgs e)
        {
            GenerateTableControls();
        }

        // A shared handlet for ValueChanged of both "Counter" controls; Generates a new table and disables creation and saving of nonsensical turmites
        private void Counter_ValueChanged(object sender, EventArgs e)
        {
            GenerateTableControls();
            saveButton.Enabled = stateCounter.Value != 0 && colorCounter.Value != 0;
            OKButton.Enabled = stateCounter.Value != 0 && colorCounter.Value != 0;
        }
        
        // Writes data from controls to a user selected file
        private void SaveButton_Click(object sender, EventArgs e)
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
