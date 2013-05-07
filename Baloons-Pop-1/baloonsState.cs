using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class BaloonsState
    {
        int[,] balloon;
        public int turnCount;//the turn counter
        public readonly static int Rows = 6;
        public readonly static int Cols = 10;
        public BaloonsState()
        {
            turnCount = 0;
            //int rows = 6;
            //int cols = 10;
            balloon = new int[Rows, Cols];
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    balloon[i, j] = rnd.Next(1, 5);
                }
            }
            printArray();
        }

        char pr(int a)
        {
            switch (a)
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

        public bool popBaloon(int x, int y)
        {
            //changes the game state and returns boolean,indicating wheater the game is over
            if (balloon[x - 1, y - 1] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                turnCount++;
                int state = balloon[x - 1, y - 1];
                int top = x - 1;
                int bottom = x - 1;
                int left = y - 1;
                int right = y - 1;
                while (top > 0 && (balloon[top - 1, y - 1] == state))
                {
                    top--;
                }

                while (bottom < 5 && balloon[bottom + 1, y - 1] == state)
                {
                    bottom++;
                }
                while (left > 0 && balloon[x - 1, left - 1] == state)
                {
                    left--;
                }
                while (right < 9 && balloon[x - 1, right + 1] == state)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {
                    //first remove the elements on the same row and float the elemnts above down
                    if (x == 1)
                        balloon[x - 1, i] = 0;

                    else
                    {
                        for (int j = x - 1; j > 0; j--)
                        {
                            balloon[j, i] = balloon[j - 1, i];
                            balloon[j - 1, i] = 0;
                        }
                    }
                }

                //if that's enough,just stop
                if (top == bottom)
                {
                    Console.WriteLine();
                    this.printArray();
                    Console.WriteLine();
                    return kraj();
                }
                else
                { //otherwise fix the problematic column as well
                    for (int i = top; i > 0; --i)
                    { //first float the elements above down and replace them
                        balloon[i + bottom - top, y - 1] = balloon[i, y - 1];
                        balloon[i, y - 1] = 0;
                    }
                    if (bottom - top > top - 1)
                    { //is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (balloon[i, y - 1] == state)
                                balloon[i, y - 1] = 0;
                        }
                    }
                }
                Console.WriteLine();
                this.printArray();
                Console.WriteLine();
                return kraj();
            }
        }

        bool kraj()
        {
            foreach (var s in balloon)
            {
                if (s != 0)
                    return false;
            }
            return true;
        }

        public void printArray()
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < 10; j++)
                    Console.Write(pr(balloon[i, j]) + " ");
                Console.WriteLine("| ");
            }
            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }
    }
}