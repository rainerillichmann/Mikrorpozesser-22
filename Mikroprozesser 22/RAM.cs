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
        public int internalTimerCounter = 0;
        public int externalTimerCounter = 0;
        public bool interruptRB5_7 = false;
        public bool interruptRB0 = false;

        public void addStack(int pc)
        {
            Stack.Add(pc);
        }

        public Arbeitsspeicher()
        {
            this.RAM[0, 0] = 0x00; //INDF
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
            this.internalTimerCounter = 0;
            this.externalTimerCounter = 0;

            this.RAM[0, 0] = 0x00; //INDF
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

        public void updateReg(byte bank)
        {
            if (bank == 0) for (int i = 2; i < 5; i++) this.RAM[1, i] = this.RAM[0, i]; //Schreibe Register 2-4 in Bank0/1
            else for (int i = 2; i < 5; i++) this.RAM[0, i] = this.RAM[1, i];

            if (bank == 0) for (int i = 0x0A; i < 0x0C; i++) this.RAM[1, i] = this.RAM[0, i]; //Schreibe Register 2-4 in Bank0/1
            else for (int i = 0x0A; i < 0x0C; i++) this.RAM[0, i] = this.RAM[1, i];
        }

        public void incInternalTimer(byte takt)
        {
            for (int i = takt; i> 0; i--)
            {
                ++this.internalTimerCounter;
                if ((this.RAM[1, 1] & 0x20) == 0)  //Internal Clock is used
                {
                    
                   internalTimerCounter = this.TimerPrescaler(internalTimerCounter);
                }
            }
        }

        public void incExternalTimer(byte takt)
        {
            for (int i = takt; i > 0; i--)
            {
                    ++this.externalTimerCounter;
                    externalTimerCounter = this.TimerPrescaler(externalTimerCounter);
                
            }
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
            byte newValue = this.getRegisterValue(bank, register);
            this.W = newValue;
        }

        public void ChangeW(byte newValue)  //Changes W
        {
            this.W = newValue;
        }

        public byte getRegisterValue(int bank, byte register)
        {
            if (register == 0)      //überprüfe ob INDF angesprochen wird
            {
                byte indAdress = this.RAM[bank, 4];
                if ((byte)(indAdress & 0x7F) == 0) return 0;  //falls indf addressiert wird, return 0x00;
                else
                {
                    if ((byte)(indAdress & 0x80) == 0) return this.RAM[0, (byte)(indAdress & 0x7F)];  //überprüfe Bit 7, welche Bank angesprochen wird
                    else return this.RAM[1, (byte)(indAdress & 0x7F)];
                }
            }
            else return this.RAM[bank, register];
        }

        public void ChangeRegister(int bank, byte register, byte newValue)  //Changes Registers
        {
            if (register == 0)      //überprüfe ob INDF angesprochen wird
            {
                byte indAdress = this.RAM[bank, 4];
                if ((byte)(indAdress & 0x7F) == 0);  //falls indf addressiert wird, return 0x00;
                else
                {
                    if ((byte)(indAdress & 0x80) == 0) this.RAM[0, (byte)(indAdress & 0x7F)] = newValue;  //überprüfe Bit 7, welche Bank angesprochen wird
                    else this.RAM[0, (byte)(indAdress & 0x7F)] = newValue; 
                }
            }
            else this.RAM[bank, register] = newValue;
        }

        public void interrupt()
        {
            if ((this.RAM[0, 0x0B] & 0x80) == 0x80)         //GIE = 1 -> alle interrupts enabled
            {
                if ((this.RAM[0, 0x0B] & 0x20) == 0x20)     //T0IE = 1 -> Timer Overflow interrupt enabled
                {
                    if ((this.RAM[0, 0x0B] & 0x04) == 0x04) // Timer Overflow ist passiert
                    {
                        this.addStack(this.RAM[0, 2]);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;           //GIE Disablen
                        return;
                    }                   
                }

                if ((this.RAM[0, 0x0B] & 0x08) == 0x08)     //RB5-7 interrupt enabled
                {
                    if ((this.RAM[0,0x0B] & 0x01)  == 0x01) //RBChange Flag enabled
                    {
                        this.addStack(this.RAM[0, 2]);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;          //GIE Disablen                      
                        return;
                    }                  
                }

                if ((this.RAM[0, 0x0B] & 0x10) == 0x10)     //RB0 interrupt enabled
                {
                    if ((this.RAM[0,0x0B] &0x02) == 0x02)
                    {
                        this.addStack(this.RAM[0, 2]);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;          //GIE Disablen
                        return;
                    }
                   
                }
            }
        }

        public int TimerPrescaler(int counter)
        {
            if ((this.RAM[1, 1] & 0x08) == 0)   //wenn PSA = 0 ist der Timer-Prescaler aktiv
            {
                // 1:2
                if ((this.RAM[1, 1] & 0x07) == 0)
                {
                    if (counter % 2 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                        return 0;
                    }
                    return counter;
                }

                // 1:4
                if ((this.RAM[1, 1] & 0x07) == 1)
                {
                    if (counter % 4 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                 
                        return 0;
                    }
                    return counter;

                }

                // 1:8
                if ((this.RAM[1, 1] & 0x07) == 2)
                {
                    if (counter % 8 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                  ;
                        return 0;
                    }
                    return counter;

                }

                // 1:16
                if ((this.RAM[1, 1] & 0x07) == 3)
                {
                    if (this.internalTimerCounter % 16 == 0)
                    {
                        this.internalTimerCounter = 0;
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                      
                        return 0;
                    }
                    return counter;

                }

                // 1:32
                if ((this.RAM[1, 1] & 0x07) == 4)
                {
                    if (counter % 32 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                      
                        return 0;
                    }
                    return counter;

                }

                // 1:64
                if ((this.RAM[1, 1] & 0x07) == 5)
                {
                    if (counter % 64 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                       
                        return 0;
                    }
                    return counter;

                }

                // 1:128
                if ((this.RAM[1, 1] & 0x07) == 6)
                {
                    if (counter % 128 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                       
                        return 0;
                    }
                    return counter;

                }

                // 1:256
                if ((this.RAM[1, 1] & 0x07) == 7)
                {
                    if (counter % 256 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                        
                        return 0;
                    }
                    return counter;

                }
                
            }
            else
            {
                ++this.RAM[0, 1]; // wenn kein prescaler aktiv ist, wird der Timer nach jedem Cycle erhöht
                if (this.RAM[0, 1] == 0)
                {
                    RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                    RAM[0, 0xB] |= 0x04;
                }
                
                return 0;
                
            }
            return 0;
        }

    }
}
