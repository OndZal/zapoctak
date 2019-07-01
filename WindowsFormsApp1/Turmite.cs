using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public enum Turns { Left, None, Right }
    public enum Directions { Up, Right, Down, Left }
    public class Turmite
    {
        static protected int[] x_movement = { 0, 1, 0, -1 };
        static protected int[] y_movement = { -1, 0, 1, 0 };
        public int x = 0, y = 0;
        public int state = 0;
        public int[,] stateTable;
        public int[,] stepTable;
        public int[,] colorTable;
        public Directions orientation;
        public Turns[,] turnTable;
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
        public Turmite(int stateCount, int colorCount)
        {
            stateTable = new int[stateCount, colorCount];
            stepTable = new int[stateCount, colorCount];
            colorTable = new int[stateCount, colorCount];
            turnTable = new Turns[stateCount, colorCount];
        }
        public void Step()
        {
            int colorIndex = controller.Colors.IndexOf(controller.bitmap.GetPixel(x, y));
            Turn(turnTable[state, colorIndex]);
            controller.bitmap.SetPixel(x, y, controller.Colors[colorTable[state, colorIndex]]);
            for (int i = 0; i < stepTable[state, colorIndex]; i++)
            {
                x += x_movement[(int)orientation];
                if (x == -1)
                {
                    x = controller.bitmap.Width - 1;
                }
                if (x == controller.bitmap.Width)
                {
                    x = 0;
                }
                y += y_movement[(int)orientation];
                if (y == -1)
                {
                    y = controller.bitmap.Height - 1;
                }
                if (y == controller.bitmap.Height)
                {
                    y = 0;
                }
            }
            state = stateTable[state, colorIndex];
        }
    }
}
