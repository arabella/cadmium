namespace PoppingBaloons
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ScoreBoard
    {
        private static string filePath = "ScoreEntries.txt";
<<<<<<< HEAD

        public static void WriteScoresToFile(ScoreEntry currentScore)
=======
        public  static void WriteScoresToFile( ScoreEntry currentScore)
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        {
            using (StreamWriter destination = new StreamWriter(filePath, true))
            {
                destination.WriteLine(currentScore);
            }
        }
<<<<<<< HEAD
/*
       public static ScoreEntry GetPlayerdata()
       {
           string data = string.Empty;
     
           // TODO get name and turns count
     
           ScoreEntry entry = new ScoreEntry(data);
           return entry;
       }
        */
=======

        public static ScoreEntry GetPlayerdata()
        {
            string data = string.Empty;
           
            //TODO get name and turns count

            ScoreEntry entry = new ScoreEntry(data);
            return entry;
        }

>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
        internal static List<ScoreEntry> ReadScoresFromFile()
        {
            var scores = new List<ScoreEntry>();

            using (StreamReader myReader = new StreamReader(filePath))
            {
                string line = string.Empty;
                while (!myReader.EndOfStream)
                {
                    line = myReader.ReadLine();
                    string[] parsedLine = line.Split();
                    try
                    {
<<<<<<< HEAD
                        scores.Add(new ScoreEntry(parsedLine[1] + " " + parsedLine[2]));
=======
                        scores.Add(new ScoreEntry(parsedLine[1]+" "+parsedLine[2]));
>>>>>>> 307fc8727fe8a2d43c046d68ae12fa593515fa1f
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
