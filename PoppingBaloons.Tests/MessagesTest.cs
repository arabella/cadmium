using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PoppingBaloons.Tests
{
    [TestClass]
    public class MessagesTest
    {
        [TestMethod]
        public void PrintMessagesWelcome()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.Welcome();
                string expected = string.Format("Welcome to “Balloons Pops” game. Please try to pop the balloons.\r\n Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
        
        [TestMethod]
        public void PrintMessagesUnknownCommand()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.UnknownCommand();
                string expected = string.Format("Unknown Command!\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintMessagesBye()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.Bye();
                string expected = string.Format("Thanks for playing!!!\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintMessagesInsertCommand()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.InsertCommand();
                string expected = string.Format("Insert row and column or other command\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintMessagesInvalidMove()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.InvalidMove();
                string expected = string.Format("Invalid Move! Can not pop a baloon at that place!!\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintMessagesOutOfRange()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.OutOfRange();
                string expected = string.Format("Indexes are too big for current board\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintMessagesWin()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.Win(3);
                string expected = string.Format("Congratulations!!You popped all the baloons in 3 moves!\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
