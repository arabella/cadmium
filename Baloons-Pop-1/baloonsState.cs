using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class BaloonsState
    {
        int[,] BalloonField;
        public int turnCount;//the turn counter
        public readonly static int Rows = 6;
        public readonly static int Cols = 10;
        public BaloonsState()
        {
            turnCount = 0;

            BalloonField = new int[Rows, Cols];
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    BalloonField[i, j] = rnd.Next(1, 5);
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
                turnCount++;
                int state = BalloonField[x, y];
                BalloonField[x, y] = 0;
                Console.WriteLine(BalloonField[x, y]);
                int top = x - 1;
                int bottom = x + 1;
                int left = y - 1;
                int right = y +1;
                while (top > 0 && (BalloonField[top, y ] == state))
                {
                    BalloonField[top, y] = 0;
                    top--;
                }

                while (bottom < Rows && BalloonField[bottom, y] == state)
                {
                    BalloonField[bottom, y] = 0;
                    bottom++;
                }
                while (left > 0 && BalloonField[x, left] == state)
                {
                    BalloonField[x, left] = 0;
                    left--;
                }
                while (right < Cols && BalloonField[x, right] == state)
                {
                    BalloonField[x, right] = 0;
                }

                Console.WriteLine();
                this.DrawBalloonField();
                Console.WriteLine();
                return CheckForEnd();
            }
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