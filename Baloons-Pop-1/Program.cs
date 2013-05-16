using System;
using System.Linq;

namespace PoppingBaloons
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages.Welcome();
            GameState game = new GameState();
            while (true)
            {
                game.ExecuteCommand(Console.ReadLine());
            }
        }
    }
}
