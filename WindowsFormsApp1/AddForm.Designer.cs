namespace WindowsFormsApp1
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileLoadButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.stateColumn = new System.Windows.Forms.Label();
            this.colorColumn = new System.Windows.Forms.Label();
            this.nextStateColumn = new System.Windows.Forms.Label();
            this.stepColumn = new System.Windows.Forms.Label();
            this.nextColorColumn = new System.Windows.Forms.Label();
            this.turnColumn = new System.Windows.Forms.Label();
            this.stateCounter = new System.Windows.Forms.NumericUpDown();
            this.colorCounter = new System.Windows.Forms.NumericUpDown();
            this.generateTableButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xSetter = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ySetter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.stateCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySetter)).BeginInit();
            this.SuspendLayout();
            // 
            // fileLoadButton
            // 
            this.fileLoadButton.Location = new System.Drawing.Point(343, 34);
            this.fileLoadButton.Name = "fileLoadButton";
            this.fileLoadButton.Size = new System.Drawing.Size(75, 23);
            this.fileLoadButton.TabIndex = 0;
            this.fileLoadButton.Text = "Load File";
            this.fileLoadButton.UseVisualStyleBackColor = true;
            this.fileLoadButton.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Location = new System.Drawing.Point(505, 34);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(424, 34);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // stateColumn
            // 
            this.stateColumn.AutoSize = true;
            this.stateColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stateColumn.Location = new System.Drawing.Point(22, 79);
            this.stateColumn.Name = "stateColumn";
            this.stateColumn.Size = new System.Drawing.Size(45, 17);
            this.stateColumn.TabIndex = 6;
            this.stateColumn.Text = "State:";
            // 
            // colorColumn
            // 
            this.colorColumn.AutoSize = true;
            this.colorColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.colorColumn.Location = new System.Drawing.Point(73, 79);
            this.colorColumn.Name = "colorColumn";
            this.colorColumn.Size = new System.Drawing.Size(45, 17);
            this.colorColumn.TabIndex = 7;
            this.colorColumn.Text = "Color:";
            // 
            // nextStateColumn
            // 
            this.nextStateColumn.AutoSize = true;
            this.nextStateColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextStateColumn.Location = new System.Drawing.Point(124, 79);
            this.nextStateColumn.Name = "nextStateColumn";
            this.nextStateColumn.Size = new System.Drawing.Size(75, 17);
            this.nextStateColumn.TabIndex = 8;
            this.nextStateColumn.Text = "Next state:";
            // 
            // stepColumn
            // 
            this.stepColumn.AutoSize = true;
            this.stepColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stepColumn.Location = new System.Drawing.Point(286, 79);
            this.stepColumn.Name = "stepColumn";
            this.stepColumn.Size = new System.Drawing.Size(48, 17);
            this.stepColumn.TabIndex = 9;
            this.stepColumn.Text = "Steps:";
            // 
            // nextColorColumn
            // 
            this.nextColorColumn.AutoSize = true;
            this.nextColorColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nextColorColumn.Location = new System.Drawing.Point(205, 79);
            this.nextColorColumn.Name = "nextColorColumn";
            this.nextColorColumn.Size = new System.Drawing.Size(75, 17);
            this.nextColorColumn.TabIndex = 10;
            this.nextColorColumn.Text = "Next color:";
            // 
            // turnColumn
            // 
            this.turnColumn.AutoSize = true;
            this.turnColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.turnColumn.Location = new System.Drawing.Point(340, 79);
            this.turnColumn.Name = "turnColumn";
            this.turnColumn.Size = new System.Drawing.Size(42, 17);
            this.turnColumn.TabIndex = 11;
            this.turnColumn.Text = "Turn:";
            // 
            // stateCounter
            // 
            this.stateCounter.Location = new System.Drawing.Point(25, 37);
            this.stateCounter.Name = "stateCounter";
            this.stateCounter.Size = new System.Drawing.Size(63, 20);
            this.stateCounter.TabIndex = 20;
            this.stateCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stateCounter.ValueChanged += new System.EventHandler(this.Counter_ValueChanged);
            // 
            // colorCounter
            // 
            this.colorCounter.Location = new System.Drawing.Point(94, 37);
            this.colorCounter.Name = "colorCounter";
            this.colorCounter.Size = new System.Drawing.Size(63, 20);
            this.colorCounter.TabIndex = 21;
            this.colorCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colorCounter.ValueChanged += new System.EventHandler(this.Counter_ValueChanged);
            // 
            // generateTableButton
            // 
            this.generateTableButton.Location = new System.Drawing.Point(163, 34);
            this.generateTableButton.Name = "generateTableButton";
            this.generateTableButton.Size = new System.Drawing.Size(52, 23);
            this.generateTableButton.TabIndex = 22;
            this.generateTableButton.Text = "Reset";
            this.generateTableButton.UseVisualStyleBackColor = true;
            this.generateTableButton.Click += new System.EventHandler(this.GenerateTableButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Number of";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "states";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Number of";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "colors";
            // 
            // xSetter
            // 
            this.xSetter.Location = new System.Drawing.Point(494, 96);
            this.xSetter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.xSetter.Name = "xSetter";
            this.xSetter.Size = new System.Drawing.Size(58, 20);
            this.xSetter.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "X coordinate";
            // 
            // ySetter
            // 
            this.ySetter.Location = new System.Drawing.Point(494, 163);
            this.ySetter.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ySetter.Name = "ySetter";
            this.ySetter.Size = new System.Drawing.Size(58, 20);
            this.ySetter.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Y coordinate";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(267, 35);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 31;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(621, 331);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ySetter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xSetter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.generateTableButton);
            this.Controls.Add(this.colorCounter);
            this.Controls.Add(this.stateCounter);
            this.Controls.Add(this.turnColumn);
            this.Controls.Add(this.nextColorColumn);
            this.Controls.Add(this.stepColumn);
            this.Controls.Add(this.nextStateColumn);
            this.Controls.Add(this.colorColumn);
            this.Controls.Add(this.stateColumn);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.fileLoadButton);
            this.Name = "AddForm";
            this.Text = "Adding stuff";
            ((System.ComponentModel.ISupportInitialize)(this.stateCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySetter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileLoadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label stateColumn;
        private System.Windows.Forms.Label colorColumn;
        private System.Windows.Forms.Label nextStateColumn;
        private System.Windows.Forms.Label stepColumn;
        private System.Windows.Forms.Label nextColorColumn;
        private System.Windows.Forms.Label turnColumn;
        private System.Windows.Forms.NumericUpDown stateCounter;
        private System.Windows.Forms.NumericUpDown colorCounter;
        private System.Windows.Forms.Button generateTableButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown xSetter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ySetter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}