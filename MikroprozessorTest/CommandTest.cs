using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikroprozesser_22;

namespace MikroprozessorTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void MOVELWTest()
        {
            
            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x11;

            Commands.MOVLW(0x3011, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void MOVEWFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x11;
            int expected = 0x11;

            Commands.MOVWF(0x008C, RamTest, 0);     //RamTest.W in RamTest.RAM[0,0xC] schreiben

            int actual = RamTest.RAM[0,0xC];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void MOVFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.RAM[0,0xC] = 0x11;
            int expected = 0x11;

            Commands.MOVF(0x008C, RamTest, 0);     //RamTest.RAM[0,0xC] in Ramtest.W schreiben

            int actual = RamTest.RAM[0, 0xC];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");          
        }

        [TestMethod]
        public void CLRFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.RAM[0, 0xC] = 0x11;
            int expected = 0x0;

            Commands.CLRF(0x000C, RamTest, 0);     //RamTest.RAM[0,0xC] in Ramtest.W schreiben

            int actual = RamTest.RAM[0, 0xC];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void CLRWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x11;
            int expected = 0x0;

            Commands.CLRW(0x000C, RamTest, 0);     //RamTest.RAM[0,0xC] in Ramtest.W schreiben

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ANDLWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x11;
            int expected = 0x10;

            Commands.ANDLW(0x3930, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void ANDWFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x25;
            RamTest.RAM[0, 0xC] = 0x36;
            int expected = 0x24;

            Commands.ANDWF(0x050C, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");
        }

        [TestMethod]
        public void IORLWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x10;
            int expected = 0x1D;

            Commands.IORLW(0x380D, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void XORLWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x20;
            int expected = 0x00;

            Commands.XORLW(0x3A20, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void ADDLWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x11;

            Commands.ADDLW(0x3011, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void ADDWFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x14;
            RamTest.RAM[0, 0xc] = 0x11;
            int expected = 0x25;

            Commands.ADDWF(0x070C, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void SUBLWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x11;
            int expected = 0x0;

            Commands.SUBLW(0x3011, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void g0t0Test()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.W = 0x11;
            int expected = 0x06;

            Commands.g0t0(0x2806, RamTest, 0);

            int actual = RamTest.RAM[0,2];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void CALLTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x06;

            Commands.CALL(0x2006, RamTest, 0);

            int actual = RamTest.RAM[0, 2];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void RETURNTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x01;

            Commands.CALL(0x2006, RamTest, 0);
            Commands.RETURN(0x0008, RamTest, 0);

            int actual = RamTest.RAM[0, 2];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void RETLWPCTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x01;

            Commands.CALL(0x2006, RamTest, 0);
            Commands.RETLW(0x3477, RamTest, 0);

            int actual = RamTest.RAM[0, 2];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void RETLWWTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0x77;

            Commands.CALL(0x2006, RamTest, 0);
            Commands.RETLW(0x3477, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void COMFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.RAM[0, 0xD] = 0x24;
            int expected = 0xDB;

            Commands.COMF(0x090D, RamTest, 0);
            

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void DECFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            int expected = 0xFF;

            Commands.DECF(0x030C, RamTest, 0);

            int actual = RamTest.W;

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void INCFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            RamTest.RAM[0,0xD] = 0x24;
            int expected = 0x25;

            Commands.INCF(0x0A8D, RamTest, 0);

            int actual = RamTest.RAM[0,0xD];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }

        [TestMethod]
        public void IORWFTest()
        {

            Arbeitsspeicher RamTest = new Arbeitsspeicher();
            CommandLine CL = new CommandLine(0, 0x048C);
            RamTest.W = 0xFF;
            int expected = 0xFF;

            Commands.Befehlsanalyse(CL, RamTest);

            int actual = RamTest.RAM[0, 0xC];

            Assert.AreEqual(expected, actual, "Expected did not Match actual");

        }
    }
}
