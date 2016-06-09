using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mikroprozesser_22;

namespace MikroprozessorTest
{
    [TestClass]
    public class CMDVisualiseTest
    {
        [TestMethod]
        public void VisualNOPTest()
        {
            CommandLine CL = new CommandLine(0, 0);
            string expected = "NOP\t";
            string actual = CMDVisualise.Befehlsstring(CL);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void MOVWFVisualTest()
        {
            string expected = "MOVWF ch";
            string actual = CMDVisualise.MOVWF(0x008C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void MOVLWVisualTest()
        {
            string expected = "MOVLW 11h";
            string actual = CMDVisualise.MOVLW(0x3011);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void MOVFVisualTest()
        {
            string expected = "MOVF ch\t";
            string actual = CMDVisualise.MOVF(0x088C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void CLRFVisualTest()
        {
            string expected = "CLRF ch\t";
            string actual = CMDVisualise.CLRF(0x018C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void CLRWVisualTest()
        {
            string expected = "CLRW\t";
            string actual = CMDVisualise.CLRW(0x0100);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void ANDLWVisualTest()
        {
            string expected = "ANDLW 30h";
            string actual = CMDVisualise.ANDLW(0x3930);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void ANDWFVisualTest()
        {
            string expected = "ANDWF ch, w";
            string actual = CMDVisualise.ANDWF(0x050C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void IORWFVisualTest()
        {
            string expected = "IORWF ch";
            string actual = CMDVisualise.IORWF(0x048C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void XORWFVisualTest()
        {
            string expected = "XORWF ch";
            string actual = CMDVisualise.XORWF(0x068C);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }

        [TestMethod]
        public void COMFVisualTest()
        {
            string expected = "COMF dh, w";
            string actual = CMDVisualise.COMF(0x090D);

            Assert.AreEqual(expected, actual, "expected does not mach actual");
        }
    }
}
