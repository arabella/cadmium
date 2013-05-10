using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{

	// veche minah ot C++ na c# i mi lipsva DEFINE i makrosite. abe hora kak pishete bez makrosi?

    class Program
    {
        static void Main(string[] args)
        {

            Messages.Welcome();
            GameState game=new GameState();
            while(true)
            {
                game.ExecuteCommand(Console.ReadLine());
            }
            
            
        }
    }
}
