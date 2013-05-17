using System;
using System.Linq;

namespace PoppingBaloons
{
    public class ScoreEntry
    {
        public string PlayerName { get; set; }
        public int Position { get; set; }
        public int Score { get; set; }

        public ScoreEntry(string data)
        {
            var entryData = data.Split(' ');

            if (string.IsNullOrWhiteSpace(data) || entryData.Length < 2)
            {
                throw new ArgumentException("Invalid score entry", "data");
            }

            this.PlayerName = entryData[0];

            int turns;
            if (int.TryParse(entryData[1], out turns))
            {
                this.Score = turns;
            }
            else
            {
                throw new ArgumentException("Invalid score enrty", "data");
            }
        }

        public override string ToString()
        {
            return string.Format("{0}. {1} {2}", this.Position, this.PlayerName, this.Score);
        }
    }
}
