using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22
{
    public class Arbeitsspeicher
    {
        public byte[,] RAM = new byte [2,64];
        public byte W = 0;
        public List<int> Stack = new List<int>();

        public void addStack(int pc)
        {
            Stack.Add(pc);
        }

        public Arbeitsspeicher()
        {
            this.RAM[0, 1] = 0x00; //TIMR0
            this.RAM[0, 2] = 0x00; //PCL
            this.RAM[0, 3] = 0x18; //STATUS
            this.RAM[0, 4] = 0x00; //FSR
            this.RAM[0, 5] = 0x00; //PORTA
            this.RAM[0, 6] = 0x00; //PORTB
            this.RAM[0, 8] = 0x00; //EEDATA
            this.RAM[0, 9] = 0x00; //EEADR
            this.RAM[0, 10] = 0x00; //PCLATH
            this.RAM[0, 11] = 0x00; //INTCON
            for (int i = 12; i < 64; i++) this.RAM[0, i] = 0x00; //Variabler shizzle

            this.RAM[1, 1] = 0xFF; //OPTION
            this.RAM[1, 2] = 0x00; //PCL
            this.RAM[1, 3] = 0x18; //STATUS
            this.RAM[1, 4] = 0x00; //FSR
            this.RAM[1, 5] = 0x1F; //TRIS A
            this.RAM[1, 6] = 0xFF; //TRIS B
            this.RAM[1, 8] = 0x00; //EECON
            this.RAM[1, 10] = 0x00; //PCLATH
            this.RAM[1, 11] = 0x00; //INTCON
            
        }

        public void Reset()
        {
            this.W = 0;
            this.Stack.Clear();

            this.RAM[0, 1] = 0x00; //TIMR0
            this.RAM[0, 2] = 0x00; //PCL
            this.RAM[0, 3] = 0x18; //STATUS
            this.RAM[0, 4] = 0x00; //FSR
            this.RAM[0, 5] = 0x00; //PORTA
            this.RAM[0, 6] = 0x00; //PORTB
            this.RAM[0, 8] = 0x00; //EEDATA
            this.RAM[0, 9] = 0x00; //EEADR
            this.RAM[0, 10] = 0x00; //PCLATH
            this.RAM[0, 11] = 0x00; //INTCON
            for (int i = 12; i < 64; i++) this.RAM[0, i] = 0x00; //Variabler shizzle

            this.RAM[1, 1] = 0xFF; //OPTION
            this.RAM[1, 2] = 0x00; //PCL
            this.RAM[1, 3] = 0x18; //STATUS
            this.RAM[1, 4] = 0x00; //FSR
            this.RAM[1, 5] = 0x1F; //TRIS A
            this.RAM[1, 6] = 0xFF; //TRIS B
            this.RAM[1, 8] = 0x00; //EECON
            this.RAM[1, 10] = 0x00; //PCLATH
            this.RAM[1, 11] = 0x00; //INTCON
        }

        public void ZeroBit( int bank)              //changes ZeroBit if W == 0
        {
            if (this.W == 0) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x4);// Z
            else this.RAM[bank, 3] = (byte)(this.RAM[0, 3] & 0xFB);
        }

        public void ZeroBit(int bank, UInt16 Befehl)  //changes ZeroBit if Register == 0
        {
            if (this.RAM[bank, (Befehl & 0x7F)] == 0) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x4); //Z
            else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFB);
        }

        public void CarryBit(int bank, int value)
        {
           if (value == 1) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x1);
           else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFE);
        }

        public void DigitCarryBit(int bank, int value)
        {
            if (value == 1) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x2);
            else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFD);
        }

        public void ChangeW(int bank, byte register)  //Changes W
        {
            if (register == 0) ;
            else this.W = this.RAM[bank, register];
        }

        public void ChangeW(byte newValue)  //Changes W
        {
            this.W = newValue;
        }

        public byte getRegisterValue(int bank, byte register)
        {
            if (register == 0) return 0;
            else return this.RAM[bank, register];
        }

        public void ChangeRegister(int bank, byte register, byte newValue)  //Changes Registers
        {

             this.RAM[bank, register] = newValue;
        }

    }
}
