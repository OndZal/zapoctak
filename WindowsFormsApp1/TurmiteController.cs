using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    // a class for handling mutiple turmites; holds a common bitmap and list of colors
    public class TurmiteController
    {
        public List<Color> Colors;
        public List<Turmite> Turmites;
        public Bitmap bitmap;

        //index of the next turmite in line to make a step
        public int iterator = 0;
        public TurmiteController(Bitmap map)
        {
            bitmap = map;
            Colors = new List<Color>();
            Turmites = new List<Turmite>();
        }
        public void NextStep()
        {
            if (Turmites.Count > 0)
            {
                Turmites[iterator].Step();
                iterator = (iterator + 1) % Turmites.Count;
            }
        }
    }
}
