using System;
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
                {
                    field[i, j] = randomInt.Next(1, 5);
                }
            }
        }

    }
}
