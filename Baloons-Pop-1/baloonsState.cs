using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class BaloonsState
    {
        int[,] BalloonField;
        public int TurnCount { get; private set; }//the turn counter
        public readonly static int Rows = 6;
        public readonly static int Cols = 10;
        public BaloonsState()
        {
            TurnCount = 0;

            BalloonField = new int[Rows, Cols];
            Random randomInt = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    BalloonField[i, j] = randomInt.Next(1, 5);
                }
            }
            DrawBalloonField();
        }

        char GetBalloon(int color)
        {
            switch (color)
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
            //changes the game state and returns boolean,indicating wheater the game is over
            Console.WriteLine(BalloonField[x, y]);
            if (BalloonField[x, y] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                TurnCount++;
                int state = BalloonField[x, y];
                BalloonField[x, y] = 0;
                //Console.WriteLine(BalloonField[x, y]);
                int top = x - 1;
                int bottom = x + 1;
                int left = y - 1;
                int right = y + 1;

                while (top > 0 && (BalloonField[top, y] == state))
                {
                    BalloonField[top, y] = 0;
                    top--;
                }

                while (bottom < Rows && BalloonField[bottom, y] == state)
                {
                    BalloonField[bottom, y] = 0;
                    bottom++;
                }
                
                // we have to return on the position of the last popped balloon
                // because it's the first available free position /0/
                // x
                // x
                // 1
                bottom--;

                while (left >= 0 && BalloonField[x, left] == state)
                {
                    BalloonField[x, left] = 0;
                    left--;
                }

                // we have to return on the position of the last popped balloon
                // 1 x x x
                left++;

                while (right < Cols && BalloonField[x, right] == state)
                {
                    BalloonField[x, right] = 0;
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
                while (startX >= 1 && BalloonField[startX - 1, left] != 0)
                {

                    BalloonField[startX, left] = BalloonField[startX - 1, left];
                    BalloonField[startX - 1, left] = 0;
                    startX--;
                }
                startX = x;
                left++;
            }
            DrawBalloonField();


            while (right > y)
            {
                while (startX >= 1 && BalloonField[startX - 1, right] != 0)
                {

                    BalloonField[startX, right] = BalloonField[startX - 1, right];
                    BalloonField[startX - 1, right] = 0;
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

                BalloonField[bottom, startY] = BalloonField[top, startY];
                BalloonField[top, startY] = 0;

                //}
                bottom--;
                top--;
            }
            DrawBalloonField();
        }

        bool CheckForEnd()
        {
            foreach (var balloon in BalloonField)
            {
                if (balloon != 0)
                {
                    return false;
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
                    Console.Write(GetBalloon(BalloonField[i, j]) + " ");
                }
                Console.WriteLine("| ");
            }
            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }
    }
}