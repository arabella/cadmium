namespace PoppingBaloons
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
                {
                    field[i, j] = randomInt.Next(1, 5);
                }
            }
        }
    }
}
