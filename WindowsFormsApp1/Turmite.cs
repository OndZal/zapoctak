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
        public Color[] colors;
        protected Bitmap map;
        protected void Turn(Turns turnDirection)
        {
            int turnNumber;
            switch (turnDirection)
            {
                case Turns.Left:
                    turnNumber = 3;
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
        public Turmite(int stateCount, int colorCount, Bitmap bitmap)
        {
            stateTable = new int[stateCount, colorCount];
            stepTable = new int[stateCount, colorCount];
            colorTable = new int[stateCount, colorCount];
            turnTable = new Turns[stateCount, colorCount];
            colors = new Color[colorCount];
            map = bitmap;
        }
        public void Step()
        {
            Color currentColor = map.GetPixel(x, y);
            int colorIndex = colors.Length;
            for (int i = 0; i < colors.Length; i++)
            {
                if (currentColor.ToArgb() == colors[i].ToArgb())
                {
                    colorIndex = i;
                    break;
                }
            }
            if (colorIndex == colors.Length)
                throw new Exception();
            Turn(turnTable[state, colorIndex]);
            map.SetPixel(x, y, colors[colorTable[state, colorIndex]]);
            for (int i = 0; i < stepTable[state, colorIndex]; i++)
            {
                x += x_movement[(int)orientation];
                if (x == -1)
                {
                    x = map.Width - 1;
                }
                if (x == map.Width)
                {
                    x = 0;
                }
                y += y_movement[(int)orientation];
                if (y == -1)
                {
                    y = map.Height - 1;
                }
                if (y == map.Height)
                {
                    y = 0;
                }
            }
            state = stateTable[state, colorIndex];
        }
    }
}
