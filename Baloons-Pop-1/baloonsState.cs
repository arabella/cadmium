namespace PoppingBaloons
{
<<<<<<< HEAD
    using System;
    using System.Linq;

    public class BalloonState
    { 
        public BalloonState(int rows, int cols)
        {
            this.TurnCount = 0;
            this.currentBalloonField = new BalloonField(rows, cols);
            Rows = rows;
            Cols = cols;
            this.DrawBalloonField();
=======
    public class BalloonState
    {
        //int[,] currentBalloonField;
        BalloonField currentBalloonField;
        public int TurnCount { get; private set; }//the turn counter
        public static int Rows;
        public  static int Cols;
        public BalloonState(int rows, int cols)
        {
            TurnCount = 0;
            currentBalloonField = new BalloonField(rows,cols);
            Rows = rows;
            Cols = cols;
            DrawBalloonField();
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }

        public int TurnCount { get; private set; }// the turn counter

        public static int Rows;

        public static int Cols;

        // int[,] currentBalloonField;
        BalloonField currentBalloonField;

        char GetBalloon(int balloon)
        {
            switch (balloon)
            {
                case 1:
                    return '1';

                case 2:
                    return '2';

                case 3:
                    return '3';

                case 4:
                    return '4';

                default:
                    return '-';
            }
        }

        public bool PopBaloon(int x, int y)
        {
<<<<<<< HEAD
            Console.WriteLine(this.currentBalloonField[x, y]);
            if (this.currentBalloonField[x, y] == 0)
=======
            Console.WriteLine(currentBalloonField[x, y]);
            if (currentBalloonField[x, y] == 0)
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
            {
                Messages.InvalidMove();
                return false;
            }
            else
            {
                TurnCount++;
<<<<<<< HEAD
                int state = this.currentBalloonField[x, y];
                this.currentBalloonField[x, y] = 0;
                // Console.WriteLine(BalloonField[x, y]);
=======
                int state = currentBalloonField[x, y];
                currentBalloonField[x, y] = 0;
                //Console.WriteLine(BalloonField[x, y]);
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                int top = x - 1;
                int bottom = x + 1;
                int left = y - 1;
                int right = y + 1;

<<<<<<< HEAD
                while (top >= 0 && (this.currentBalloonField[top, y] == state))
                {
                    this.currentBalloonField[top, y] = 0;
                    top--;
                }

                while (bottom < Rows && this.currentBalloonField[bottom, y] == state)
                {
                    this.currentBalloonField[bottom, y] = 0;
=======
                while (top >= 0 && (currentBalloonField[top, y] == state))
                {
                    currentBalloonField[top, y] = 0;
                    top--;
                }

                while (bottom < Rows && currentBalloonField[bottom, y] == state)
                {
                    currentBalloonField[bottom, y] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                    bottom++;
                }
                
                // we have to return on the position of the last popped balloon
                // because it's the first available free position /0/
                // x
                // x
                // 1
                bottom--;

<<<<<<< HEAD
                while (left >= 0 && this.currentBalloonField[x, left] == state)
                {
                    this.currentBalloonField[x, left] = 0;
=======
                while (left >= 0 && currentBalloonField[x, left] == state)
                {
                    currentBalloonField[x, left] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                    left--;
                }

                // we have to return on the position of the last popped balloon
                // 1 x x x
                left++;

<<<<<<< HEAD
                while (right < Cols && this.currentBalloonField[x, right] == state)
                {
                    this.currentBalloonField[x, right] = 0;
=======
                while (right < Cols && currentBalloonField[x, right] == state)
                {
                    currentBalloonField[x, right] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                    right++;
                }
                
                // we have to return on the position of the last popped balloon
                // x x x 1
                right--;

                this.MoveDownBalloons(x, y, left, right, top, bottom);
                Console.WriteLine();
                this.DrawBalloonField();
                Console.WriteLine();
                return this.CheckForEnd();
            }
        }

        public bool CheckForEnd()
        {
            for (int i = 0; i < this.currentBalloonField.Rows; i++)
            {
                for (int j = 0; j < this.currentBalloonField.Cols; j++)
                {
                    if (this.currentBalloonField[i, j] != 0)
                    {
                        return false;
                    }     
                }
            }

            return true;
        }

        public void DrawBalloonField()
        {
            Console.Write("    ");
            for (int i = 0; i < Cols; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("    --------------------");
            for (int i = 0; i < Rows; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(GetBalloon(this.currentBalloonField[i, j]) + " ");
                }
                Console.WriteLine("| ");
            }
            Console.WriteLine("    --------------------");
            Messages.InsertCommand();
        }
        private void MoveDownBalloons(int x, int y, int left, int right, int top, int bottom)
        {
            int startX = x;
            int startY = y;

            while (left < y)
            {
<<<<<<< HEAD
                while (startX >= 1 && this.currentBalloonField[startX - 1, left] != 0)
                {

                    this.currentBalloonField[startX, left] = this.currentBalloonField[startX - 1, left];
                    this.currentBalloonField[startX - 1, left] = 0;
=======
                while (startX >= 1 && currentBalloonField[startX - 1, left] != 0)
                {

                    currentBalloonField[startX, left] = currentBalloonField[startX - 1, left];
                    currentBalloonField[startX - 1, left] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                    startX--;
                }
                startX = x;
                left++;
            }
            // DrawBalloonField();


            while (right > y)
            {
<<<<<<< HEAD
                while (startX >= 1 && this.currentBalloonField[startX - 1, right] != 0)
                {

                    this.currentBalloonField[startX, right] = this.currentBalloonField[startX - 1, right];
                    this.currentBalloonField[startX - 1, right] = 0;
=======
                while (startX >= 1 && currentBalloonField[startX - 1, right] != 0)
                {

                    currentBalloonField[startX, right] = currentBalloonField[startX - 1, right];
                    currentBalloonField[startX - 1, right] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
                    startX--;
                }
                startX = x;
                right--;
            }
            // DrawBalloonField();

            while (top >= 0)
            {
                // while (startX >= 1 && BalloonField[startX - 1, right] != 0)
                // {

<<<<<<< HEAD
                this.currentBalloonField[bottom, startY] = this.currentBalloonField[top, startY];
                this.currentBalloonField[top, startY] = 0;
=======
                currentBalloonField[bottom, startY] = currentBalloonField[top, startY];
                currentBalloonField[top, startY] = 0;
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f

                // }
                bottom--;
                top--;
            }
<<<<<<< HEAD
            // DrawBalloonField();
=======
            //DrawBalloonField();
        }

        public bool CheckForEnd()
        {
            for (int i = 0; i < currentBalloonField.Rows; i++)
            {
                for (int j = 0; j < currentBalloonField.Cols; j++)
                {
                    if (currentBalloonField[i,j] != 0)
                    {
                        return false;
                    }     
                }
            }

            return true;
        }

        public void DrawBalloonField()
        {
            Console.Write("    ");
            for (int i = 0; i < Cols; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("    --------------------");
            for (int i = 0; i < Rows; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(GetBalloon(currentBalloonField[i, j]) + " ");
                }
                Console.WriteLine("| ");
            }
            Console.WriteLine("    --------------------");
            Messages.InsertCommand();
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }
    }
}