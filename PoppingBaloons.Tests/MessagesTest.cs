using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PoppingBaloons.Tests
{
    [TestClass]
    public class MessagesTest
    {
        [TestMethod]
        public void PrintMessagesUnknownCommand()
        {
            Messages.UnknownCommand();
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
            Messages.UnknownCommand();
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Messages.Bye();
                string expected = string.Format("Thanks for playing!!!\r\n", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
