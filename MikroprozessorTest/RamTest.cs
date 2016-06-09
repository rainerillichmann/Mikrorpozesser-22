using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikroprozesser_22;

namespace MikroprozessorTest
{
    [TestClass]
    public class RamTest
    {
        [TestMethod]
        public void ZeroBitWTrueTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();
            int expected = 4;

            ramTest.ZeroBit(0);
            int actual = ramTest.RAM[0, 3] & 0x04;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ZeroBitWFalseTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();
            ramTest.W = 1;
            int expected = 0;

            ramTest.ZeroBit(0);
            int actual = ramTest.RAM[0, 3] & 0x04;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void CarryBitTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();
            
            int expected = 1;

            ramTest.CarryBit(0,1);
            int actual = ramTest.RAM[0, 3] & 0x01;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void DigitCarryBitTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 2;

            ramTest.DigitCarryBit(0, 1);
            int actual = ramTest.RAM[0, 3] & 0x02;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ChangeWTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 0x11;

            ramTest.ChangeW(0x11);
            int actual = ramTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ChangeWRegTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 0xFF;  //Nach init sollte in RAM[1,1] FF stehen

            ramTest.ChangeW(1,1);
            int actual = ramTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void getRegValueTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 0xFF; //Nach init sollte in RAM[1,1] FF stehen

            ramTest.getRegisterValue(1, 1);
            int actual = ramTest.getRegisterValue(1, 1);

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ChangeRegisterTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 0xFF;

            ramTest.ChangeRegister(0, 0xC, 0xFF);
            int actual = ramTest.RAM[0,0xC];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void WatchdogPresclaerTest()
        {
            Arbeitsspeicher ramTest = new Arbeitsspeicher();

            int expected = 2304;

            double actual = ramTest.WatchdogPrescaler();

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }
    }
}
