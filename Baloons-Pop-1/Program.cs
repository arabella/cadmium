namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Messages.Welcome();
            GameState game = new GameState();
            while (true)
            {
                game.ExecuteCommand(Console.ReadLine());
            }
<<<<<<< HEAD
            // BalloonField myField = new BalloonField(6, 6);
            // Console.WriteLine(myField[4,4]);
=======
            //BalloonField myField = new BalloonField(6, 6);
            //Console.WriteLine(myField[4,4]);
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }
    }
}
