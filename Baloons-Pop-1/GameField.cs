namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class GameField
    {
        private int[,] field;

        public GameField(int rows, int cols)
        {
            this.field = new int[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public int this[int row, int col]
        {
            get { return this.field[row, col]; }
            set { this.field[row, col] = value; }
        }
    }
}
