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
        public List<Color> colors;
        public List<Turmite> turmites;
        public Bitmap bitmap;

        //index of the next turmite in line to make a step
        protected int iterator = 0;
        public TurmiteController(Bitmap map)
        {
            bitmap = map;
            colors = new List<Color>();
            turmites = new List<Turmite>();
        }
        public void NextStep()
        {
            if (turmites.Count > 0)
            {
                turmites[iterator].Step();
                iterator = (iterator + 1) % turmites.Count;
            }
        }
    }
}
