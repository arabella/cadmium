using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    public class GameField
    {
        private int[,] field;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public GameField(int rows, int cols)
        {
            field = new int[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        public int this[int row, int col]
        {
            get { return field[row,col]; }
            set { field[row,col] = value; }
        }
    }
}
