using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class GameState
    {
        BaloonsState currentBalloonState;
        List<Tuple<string, int>> scoreboard;

        public GameState()
        {
            currentBalloonState = new BaloonsState();

            scoreboard = new List<Tuple<string, int>>();
        }

        void DisplayScoreboard()
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

        public void ExecuteCommand(string command)
        {
            if (command == string.Empty || command == null)
            {
                Messages.UnknownCommand();
            }
            else if (command == "exit")
            {
                Messages.Bye();   
                Environment.Exit(0);
            }
            else if (command == "restart")
            {
                Restart();
            }
            else if (command == "top")
            {
                DisplayScoreboard();
            }
            else
            {
                //check input validation
                int row, col;

                string[] coordinates = command.Split(' ');

                if (coordinates.Length == 2)
                {

                    bool isRowNumber = int.TryParse(coordinates[0], out row);
                    bool isColNumber = int.TryParse(coordinates[1], out col);

                    if (isRowNumber && isColNumber)
                    {
                        SendCommand(row, col);//sends command to the baloonsState game holder
                    }
                }
                else
                {
                    Messages.UnknownCommand();
                }
            }
        }

        private void SendCommand(int row, int col)
        {
            bool end = false;
            if (row > BaloonsState.Rows || col > BaloonsState.Cols)
            {
                Console.WriteLine("Indexes too big");
                DisplayScoreboard();
            }
            else
            {
                end = currentBalloonState.PopBaloon(row, col);//if this turn ends the game, try to update the scoreboard
            }

            if (end)
            {
                Messages.Win(currentBalloonState.TurnCount);
                UpdateScoreboard();
            }
            
            
            
            //Restart();
        }

        private void UpdateScoreboard()
        {
            Action<int> add = count => //function to get the player name and add a tuple to the scoreboard
            {
                Console.Write("Enter Nickname: ");
                string nickname = Console.ReadLine();
                Tuple<string, int> a = Tuple.Create<string, int>(nickname, count);
                scoreboard.Add(a);
            };
            if (scoreboard.Count < 5)
            {
                add(currentBalloonState.TurnCount);
            }
            else
            {
                if (scoreboard.ElementAt<Tuple<string, int>>(4).Item2 >= currentBalloonState.TurnCount)
                {
                    add(currentBalloonState.TurnCount);
                    scoreboard.RemoveRange(4, 1);//if the new name replaces one of the old ones, remove the old one
                }
            }
            scoreboard.Sort(delegate(Tuple<string, int> playerOne, Tuple<string, int> playerTwo)//re-sort the list
            {
                return playerOne.Item2.CompareTo(playerTwo.Item2);
            });
            currentBalloonState = new BaloonsState();
        }

        private void Restart()
        {
            currentBalloonState = new BaloonsState();
        }
    }
}