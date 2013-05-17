using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
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
        }

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
            Console.WriteLine(currentBalloonField[x, y]);
            if (currentBalloonField[x, y] == 0)
            {
                Messages.InvalidMove();
                return false;
            }
            else
            {
                TurnCount++;
                int state = currentBalloonField[x, y];
                currentBalloonField[x, y] = 0;
                //Console.WriteLine(BalloonField[x, y]);
                int top = x - 1;
                int bottom = x + 1;
                int left = y - 1;
                int right = y + 1;

                while (top >= 0 && (currentBalloonField[top, y] == state))
                {
                    currentBalloonField[top, y] = 0;
                    top--;
                }

                while (bottom < Rows && currentBalloonField[bottom, y] == state)
                {
                    currentBalloonField[bottom, y] = 0;
                    bottom++;
                }
                
                // we have to return on the position of the last popped balloon
                // because it's the first available free position /0/
                // x
                // x
                // 1
                bottom--;

                while (left >= 0 && currentBalloonField[x, left] == state)
                {
                    currentBalloonField[x, left] = 0;
                    left--;
                }

                // we have to return on the position of the last popped balloon
                // 1 x x x
                left++;

                while (right < Cols && currentBalloonField[x, right] == state)
                {
                    currentBalloonField[x, right] = 0;
                    right++;
                }
                
                // we have to return on the position of the last popped balloon
                // x x x 1
                right--;

                MoveDownBalloons(x, y, left, right, top, bottom);
                Console.WriteLine();
                this.DrawBalloonField();
                Console.WriteLine();
                return CheckForEnd();
            }
        }

        private void MoveDownBalloons(int x, int y, int left, int right, int top, int bottom)
        {
            int startX = x;
            int startY = y;

            while (left < y)
            {
                while (startX >= 1 && currentBalloonField[startX - 1, left] != 0)
                {

                    currentBalloonField[startX, left] = currentBalloonField[startX - 1, left];
                    currentBalloonField[startX - 1, left] = 0;
                    startX--;
                }
                startX = x;
                left++;
            }
            //DrawBalloonField();


            while (right > y)
            {
                while (startX >= 1 && currentBalloonField[startX - 1, right] != 0)
                {

                    currentBalloonField[startX, right] = currentBalloonField[startX - 1, right];
                    currentBalloonField[startX - 1, right] = 0;
                    startX--;
                }
                startX = x;
                right--;
            }
            //DrawBalloonField();

            while (top >= 0)
            {
                //while (startX >= 1 && BalloonField[startX - 1, right] != 0)
                //{

                currentBalloonField[bottom, startY] = currentBalloonField[top, startY];
                currentBalloonField[top, startY] = 0;

                //}
                bottom--;
                top--;
            }
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
        }
    }
}