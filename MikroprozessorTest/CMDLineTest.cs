using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikroprozesser_22;

namespace MikroprozessorTest
{
    [TestClass]
    public class CMDLineTest
    {
        [TestMethod]
        public void CMDLineConstructorTest()
        {
            int expected = 1;
            CommandLine CL = new CommandLine(1, 2);
            int actual = CL.counter;
            Assert.AreEqual(expected, actual, "expected and equal differ"); 
        }

        [TestMethod]
        public void CMDLineConstructorTest2()
        {
            int expected = 2;
            CommandLine CL = new CommandLine(1, 2);
            int actual = CL.command;
            Assert.AreEqual(expected, actual, "expected and equal differ");
        }
    }
}
