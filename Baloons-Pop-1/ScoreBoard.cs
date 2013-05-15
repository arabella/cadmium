using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PoppingBaloons
{
    public class ScoreBoard
    {
        public  static void WriteScoresToFile(string filePath)
        {
            bool gameOver = true;
            if (gameOver)
            {
                GetPlayerdata(); 

                // TODO write to txt file
            }
        }

        public  static ScoreEntry GetPlayerdata()
        {
            string data = string.Empty;
           
            //TODO get name and turns count

            ScoreEntry entry = new ScoreEntry(data);
            return entry;
        }

        internal static List<ScoreEntry> ReadScoresFromFile(string filePath)
        {
            var scores = new List<ScoreEntry>();

            using (StreamReader myReader = new StreamReader(filePath))
            {
                string line = string.Empty;
                while (!myReader.EndOfStream)
                {
                    line = myReader.ReadLine();

                    try
                    {
                        scores.Add(new ScoreEntry(line));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Invalid score entry at line \"{0}\": {1}", line, ex);
                    }
                }
            }
            return SortScoresDescending(scores);
        }

        private static List<ScoreEntry> SortScoresDescending(List<ScoreEntry> scores)
        {
            scores = scores.OrderByDescending(s => s.Score).ToList();
            int position = 1;
            scores.ForEach(s => s.Position = position++);

            return scores.ToList();
        }
    }
}
