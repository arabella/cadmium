<<<<<<< HEAD
﻿namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class GameField
    {
        private int[,] field;

        public GameField(int rows, int cols)
        {
            this.field = new int[rows, cols];
=======
﻿using System;
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
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
            this.Rows = rows;
            this.Cols = cols;
        }

<<<<<<< HEAD
        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public int this[int row, int col]
        {
            get { return this.field[row, col]; }
            set { this.field[row, col] = value; }
=======
        public int this[int row, int col]
        {
            get { return field[row,col]; }
            set { field[row,col] = value; }
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }
    }
}
