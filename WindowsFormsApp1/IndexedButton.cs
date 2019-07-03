using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // a button for dynamically generating and editing a list of colors; Holds an index that its associated color will be at in the list.
    public class IndexedButton :  System.Windows.Forms.Button
    {
        public int index;
        public IndexedButton(int index, System.Drawing.Color color) : base()
        {
            this.index = index;
            BackColor = color;
            Location = new System.Drawing.Point(34 + 36*index, 58);
            Name = "button" + index.ToString();
            Size = new System.Drawing.Size(30, 30);
            TabIndex = 1;
            UseVisualStyleBackColor = false;
        }
    }
}
