using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class GameState
    {
        baloonsState currentBalloonState;
        List<Tuple<string, int>> scoreboard;

        public GameState()
        {
            currentBalloonState = new baloonsState();

            scoreboard = new List<Tuple<string, int>>();
        }

        ~GameState()
        {
        }

        void displayScoreboard()
        {
            if (scoreboard.Count == 0)
                Console.WriteLine("The scoreboard is empty");
            else
            {
                Console.WriteLine("Top performers:");
                Action<Tuple<string, int>> print = elem => { Console.WriteLine(elem.Item1 + "  " + elem.Item2.ToString() + " turns "); };
                scoreboard.ForEach(print);
            }
        }

        public void executeCommand(string command)
        {
            if (command == string.Empty || command == null)
            {
                throw new ArgumentNullException("No command entered!");
            }
            else if (command == "exit")
            {
                Console.WriteLine("Thanks for playing!!");
                Environment.Exit(0);
            }
            else if (command == "restart")
            {
                restart();
            }
            else if (command == "top")
            {
                displayScoreboard();
            }
            else
            {
                //check input validation
                int row, col;

                string[] coordinates = command.Split(' ');

                bool first = int.TryParse(coordinates[0], out row);
                bool second = int.TryParse(coordinates[1], out col);

                if (first && second)
                {
                    sendCommand(row, col);//sends command to the baloonsState game holder
                }
                else
                {
                    Console.WriteLine("Unknown Command");
                }
            }
        }

        private void sendCommand(int row, int col)
        {
            bool end = false;
            if (row > baloonsState.Rows || col > baloonsState.Cols)
            {
                Console.WriteLine("Indexes too big");
            }
            else
            {
                end = currentBalloonState.popBaloon(row + 1, col + 1);//if this turn ends the game, try to update the scoreboard
            }

            if (end)
            {
                Console.WriteLine("Congratulations!!You popped all the baloons in" + currentBalloonState.turnCount + "moves!");
            }
            
            updateScoreboard();
            
            restart();
        }

        private void updateScoreboard()
        {
            Action<int> add = count => //function to get the player name and add a tuple to the scoreboard
            {
                Console.WriteLine("Enter Name:");
                string s = Console.ReadLine();
                Tuple<string, int> a = Tuple.Create<string, int>(s, count);
                scoreboard.Add(a);
            };
            if (scoreboard.Count < 5)
            {
                add(currentBalloonState.turnCount);
                return;
            }
            else
            {
                if (scoreboard.ElementAt<Tuple<string, int>>(4).Item2 >= currentBalloonState.turnCount)
                {
                    add(currentBalloonState.turnCount);
                    scoreboard.RemoveRange(4, 1);//if the new name replaces one of the old ones, remove the old one
                }
            }
            scoreboard.Sort(delegate(Tuple<string, int> p1, Tuple<string, int> p2)//re-sort the list
            {
                return p1.Item2.CompareTo(p2.Item2);
            });
            currentBalloonState = new baloonsState();
        }

        private void restart()
        {
            currentBalloonState = new baloonsState();
        }
    }
}