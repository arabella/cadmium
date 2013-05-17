namespace PoppingBaloons
{
    using System;
    using System.Linq;

    public class GameState
    {
        BalloonState currentBalloonState;

        public GameState()
        {
<<<<<<< HEAD
            this.currentBalloonState = new BalloonState(2, 2);
=======
            currentBalloonState = new BalloonState(2,2);

        }

        void DisplayScoreboard()
        {
            var scores = ScoreBoard.ReadScoresFromFile();
            scores.ForEach(s => Console.WriteLine(s));
            //Console.ReadKey();
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
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
                this.Restart();
            }
            else if (command == "top")
            {
                this.DisplayScoreboard();
            }
            else
            {
                // check input validation
                int row, col;
                command = command.Trim();
                string[] coordinates = command.Split(' ');

                if (coordinates.Length == 2)
                {
                    bool isRowNumber = int.TryParse(coordinates[0], out row);
                    bool isColNumber = int.TryParse(coordinates[1], out col);

                    if (isRowNumber && isColNumber)
                    {
                        this.SendCommand(row, col); // sends command to the baloonsState game holder
                    }
                }
                else
                {
                    Messages.UnknownCommand();
                }
            }
        }

        public void DisplayScoreboard()
        {
            var scores = ScoreBoard.ReadScoresFromFile();
            scores.ForEach(s => Console.WriteLine(s));
            // Console.ReadKey();
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
                end = this.currentBalloonState.PopBaloon(row, col); // if this turn ends the game, try to update the scoreboard
            }

            if (end)
            {
                Messages.Win(this.currentBalloonState.TurnCount);
                this.UpdateScoreboard();
            }
        }

        private void UpdateScoreboard()
<<<<<<< HEAD
        {         
                Console.Write("Enter Nickname: ");
                string nickname = Console.ReadLine();
                ScoreEntry currentScore = new ScoreEntry(nickname + " " + this.currentBalloonState.TurnCount);
                ScoreBoard.WriteScoresToFile(currentScore);
                
            this.currentBalloonState = new BalloonState(2, 2);
=======
        {
            
                Console.Write("Enter Nickname: ");
                string nickname = Console.ReadLine();
                ScoreEntry currentScore = new ScoreEntry(nickname+" "+currentBalloonState.TurnCount);
                ScoreBoard.WriteScoresToFile(currentScore);
                
            
            currentBalloonState = new BalloonState(2,2);
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }

        private void Restart()
        {
<<<<<<< HEAD
            this.currentBalloonState = new BalloonState(2, 2);
=======
            currentBalloonState = new BalloonState(2,2);
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        }
    }
}