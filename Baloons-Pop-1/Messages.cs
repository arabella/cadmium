namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class Messages
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        public static void UnknownCommand()
        { 
            Console.WriteLine("Unknown Command!");
        }

        public static void Bye()
        {
            Console.WriteLine("Thanks for playing!!!");
        }

        public static void InsertCommand()
        {
            Console.WriteLine("Insert row and column or other command");
        }

        public static void InvalidMove()
        {
            Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
        }

        public static void Win(int turnCount)
        {
            Console.WriteLine("Congratulations!!You popped all the baloons in {0} moves!", turnCount);
        }

        public static void OutOfRange()
        {
            Console.WriteLine("Indexes are too big for current board");
        }
    }
}
