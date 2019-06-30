using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class TurmiteController
    {
        public List<Color> Colors;
        public List<Turmite> Turmites;
        public Bitmap bitmap;
        public int iterator = 0;
        public TurmiteController(Bitmap map)
        {
            bitmap = map;
            Colors = new List<Color>();
            Turmites = new List<Turmite>();
        }
        public void NextStep()
        {
            Turmites[iterator].Step();
            iterator = (iterator + 1) % Turmites.Count;
        }
    }
}
