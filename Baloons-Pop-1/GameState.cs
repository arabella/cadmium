using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{
    class GameState
    {
        BalloonState currentBalloonState;

        public GameState()
        {
            currentBalloonState = new BalloonState(2,2);

        }

        void DisplayScoreboard()
        {
            var scores = ScoreBoard.ReadScoresFromFile();
            scores.ForEach(s => Console.WriteLine(s));
            //Console.ReadKey();
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
                command = command.Trim();
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
            if (row > BalloonState.Rows || col > BalloonState.Cols)
            {
                Messages.OutOfRange();
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
        }

        private void UpdateScoreboard()
        {
            
                Console.Write("Enter Nickname: ");
                string nickname = Console.ReadLine();
                ScoreEntry currentScore = new ScoreEntry(nickname+" "+currentBalloonState.TurnCount);
                ScoreBoard.WriteScoresToFile(currentScore);
                
            
            currentBalloonState = new BalloonState(2,2);
        }

        private void Restart()
        {
            currentBalloonState = new BalloonState(2,2);
        }
    }
}