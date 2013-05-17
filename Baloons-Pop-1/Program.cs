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
            //BalloonField myField = new BalloonField(6, 6);
            //Console.WriteLine(myField[4,4]);
        }
    }
}
