using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    // both ordered clockwise (this makes the undefined turn of a turmite a turn left)
    public enum Turns { Left, None, Right }
    public enum Directions { Up, Right, Down, Left }
    
    // a class holding the rules of a turmite; colors are overall represented by indices
    public class Turmite
    {
        // constants for eazy movement calculations
        static protected int[] x_movement = { 0, 1, 0, -1 };
        static protected int[] y_movement = { -1, 0, 1, 0 };
        
        // coordinates of the turmite on a bitmap
        public int x = 0, y = 0;
        public int state = 0;
        public Directions orientation;

        // tables representing the rules of the turmite; indexed by state and color's index, respectively
        public int[,] stateTable;
        public int[,] stepTable;
        public int[,] colorTable;
        public Turns[,] turnTable;

        // the contoller holding the colors asociated with their indices, and the bitmap they "live" on, both common to all turmites
        public TurmiteController controller;

        protected void Turn(Turns turnDirection)
        {
            int turnNumber;
            switch (turnDirection)
            {
                case Turns.Left:
                    turnNumber = 3; // v mod 4 se 3 chova, jak by se melo chovat -1, ale spolehliveji
                    break;
                case Turns.None:
                    turnNumber = 0;
                    break;
                case Turns.Right:
                    turnNumber = 1;
                    break;
                default:
                    turnNumber = 0;
                    break;
            }
            orientation = (Directions)(((int)orientation + turnNumber) % 4);
        }

        // Initializes an empty, does not fill in tables nor coordinates.
        public Turmite(int stateCount, int colorCount)
        {
            stateTable = new int[stateCount, colorCount];
            stepTable = new int[stateCount, colorCount];
            colorTable = new int[stateCount, colorCount];
            turnTable = new Turns[stateCount, colorCount];
        }

        // Performs a single step consisting, in order, of turning, repainting of the pixel it's standing on, moving and changing its states.
        public void Step()
        {
            int colorIndex = controller.Colors.IndexOf(controller.bitmap.GetPixel(x, y));
            Turn(turnTable[state, colorIndex]);
            controller.bitmap.SetPixel(x, y, controller.Colors[colorTable[state, colorIndex]]);
            //If the turmite walks off the bitmap, it appears on the other side symmetrically by the axis it has over- or under-flown in.
            for (int i = 0; i < stepTable[state, colorIndex]; i++)
            {
                x += x_movement[(int)orientation];
                if (x < 0)
                {
                    x = controller.bitmap.Width - 1;
                }
                if (x >= controller.bitmap.Width)
                {
                    x = 0;
                }
                y += y_movement[(int)orientation];
                if (y < 0)
                {
                    y = controller.bitmap.Height - 1;
                }
                if (y >= controller.bitmap.Height)
                {
                    y = 0;
                }
            }
            state = stateTable[state, colorIndex];
        }
    }
}
