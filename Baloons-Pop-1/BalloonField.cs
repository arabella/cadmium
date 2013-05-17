<<<<<<< HEAD
﻿namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class BalloonField : GameField
    {
        public BalloonField(int rows, int cols)
            : base(rows, cols)
        {
           GenerateBalloonField(this);
        }

        private void GenerateBalloonField(BalloonField field) 
        {
            Random randomInt = new Random();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class BalloonField : GameField
    {
        public BalloonField(int rows, int cols)
            :base(rows,cols)
        {
            GenerateBalloonField(this);
        }
        private void GenerateBalloonField(BalloonField field) 
        {
            Random randomInt = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                {
                    field[i, j] = randomInt.Next(1, 5);
                }
            }
        }
<<<<<<< HEAD
=======

>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
    }
}
