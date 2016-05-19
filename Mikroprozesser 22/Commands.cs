using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Mikroprozesser_22
{
    using Mikroprozesser_22;
    class Commands
    {
        public static void Befehlsanalyse(CommandLine Befehl, Arbeitsspeicher RAM)
        {
            byte tempBank = (byte)(RAM.RAM[0, 3]>>5);
            
            /* In dieser Klasse werden die einzelnen Befehlscodes analysiert und die passenden Funktionen aufgerufen
             * nach Befehlen die Register verändern, werden mit updateReg die Register, die auf beiden Bänken gleich sind
             * kopiert. Nach jedem Befehl wird außerdem die interrupt funktion aufgerufen, die überprüft, ob nach dem Ausführen
             * eines Befehls ein Interrupt aufgetreten ist.
             */
            
            //MOVLW
            if ((Befehl.command & 0x3F00) == 0x3000) { MOVLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3100) { MOVLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3200) { MOVLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3300) { MOVLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //MOVWF
            if ((Befehl.command & 0x3F80) == 0x0080) { MOVWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //MOVF
            if ((Befehl.command & 0x3F00) == 0x0800) { MOVF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //ANDLW
            if ((Befehl.command & 0x3F00) == 0x3900) { ANDLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //ANDWF
            if ((Befehl.command & 0x3F00) == 0x0500) { ANDWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //IORLW
            if ((Befehl.command & 0x3F00) == 0x3800) { IORLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //IORWF
            if ((Befehl.command & 0x3F00) == 0x0400) { IORWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //SUBLW
            if ((Befehl.command & 0x3F00) == 0x3C00) { SUBLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3D00) { SUBLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //XORLW
            if ((Befehl.command & 0x3F00) == 0x3A00) { XORLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //XORWF
            if ((Befehl.command & 0x3F00) == 0x0600) { XORWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //ADDLW
            if ((Befehl.command & 0x3F00) == 0x3E00) { ADDLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3F00) { ADDLW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //ADDWF
            if ((Befehl.command & 0x3F00) == 0x0700) { ADDWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //SUBWF
            if ((Befehl.command & 0x3F00) == 0x0200) { SUBWF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //SWAPF
            if ((Befehl.command & 0x3F00) == 0x0E00) { SWAPF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //GOTO
            if ((Befehl.command & 0x3800) == 0x2800) { g0t0(Befehl.command, RAM, tempBank);  RAM.interrupt(); return; }
            //CALL
            if ((Befehl.command & 0x3800) == 0x2000) { CALL(Befehl.command, RAM, tempBank);  RAM.interrupt(); return; }
            //NOP
            if ((Befehl.command & 0x3FFF) == 0x0000) { NOP(RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3FFF) == 0x0020) { NOP(RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3FFF) == 0x0040) { NOP(RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3FFF) == 0x0060) { NOP(RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //RETURN
            if ((Befehl.command & 0x3FFF) == 0x0008) { RETURN(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            //RETLW
            if ((Befehl.command & 0x3F00) == 0x3400) { RETLW(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3500) { RETLW(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3600) { RETLW(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            if ((Befehl.command & 0x3F00) == 0x3700) { RETLW(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            //CLRF
            if ((Befehl.command & 0x3F80) == 0x0180) { CLRF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //CLRW
            if (((Befehl.command & 0x3FFF) >= 0x0100) && ((Befehl.command & 0x3FFF) <= 0x017F)) { CLRW(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //RLF
            if ((Befehl.command & 0x3F00) == 0x0D00) { RLF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //RRF
            if ((Befehl.command & 0x3F00) == 0x0C00) { RRF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //COMF
            if ((Befehl.command & 0x3F00) == 0x0900) { COMF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //DECF
            if ((Befehl.command & 0x3F00) == 0x0300) { DECF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank);RAM.interrupt(); return; }
            //DECFSZ
            if ((Befehl.command & 0x3F00) == 0x0B00) { DECFSZ(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //INCF
            if ((Befehl.command & 0x3F00) == 0x0A00) { INCF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //INCFSZ
            if ((Befehl.command & 0x3F00) == 0x0F00) { INCFSZ(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //BSF
            if ((Befehl.command & 0x3C00) == 0x1400) { BSF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //BCF
            if ((Befehl.command & 0x3C00) == 0x1000) { BCF(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //BTFSC
            if ((Befehl.command & 0x3C00) == 0x1800) { BTFSC(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //BTFSS
            if ((Befehl.command & 0x3C00) == 0x1C00) { BTFSS(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
            //RETFIE
            if ((Befehl.command & 0x3FFF) == 0x0009) { RETFIE(Befehl.command, RAM, tempBank); RAM.interrupt(); return; }
            //SLEEP
            if ((Befehl.command & 0x3FFF) == 0x0063) { RETFIE(Befehl.command, RAM, tempBank); RAM.updateReg(tempBank); RAM.interrupt(); return; }
        }

        static void NOP(Arbeitsspeicher RAM, byte bank)
        {
            RAM.incInternalTimer(1);
            ++RAM.RAM[bank, 2];
        }


        static void MOVLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            RAM.incInternalTimer(1);
            ++RAM.RAM[bank, 2];
            RAM.ChangeW( (byte)(0xFF & Befehl));
            
        }

        static void MOVWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            RAM.incInternalTimer(1); 
            ++RAM.RAM[bank, 2];
       
            RAM.ChangeRegister(bank, (byte)(Befehl & 0x007F), RAM.W);
            
        }

        static void MOVF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {           
            if ((Befehl & 0x80) == 0)
            {               
                RAM.ChangeW(bank, (byte)(Befehl & 0x7F));
                RAM.ZeroBit(bank);
            }
            else RAM.ZeroBit(bank, Befehl);                     //lediglich Test auf Zero Bit    

            RAM.incInternalTimer(1);
            ++RAM.RAM[bank, 2];
        }

        static void CLRF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {

            RAM.ChangeRegister(bank, (byte)(Befehl & 0x007F), 0);
            RAM.ZeroBit(bank, Befehl);
            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void CLRW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
           
            RAM.ChangeW (0);
            RAM.ZeroBit(bank, 0);

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void ANDLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            
            RAM.ChangeW ((byte)((0xFF & Befehl) & RAM.W));
            RAM.ZeroBit(bank);

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void ANDWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));
            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW ((byte)(RAM.W & regValue));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(RAM.W & regValue));
                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void IORWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            RAM.incInternalTimer(1);
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));
            if ((Befehl & 0x80) == 0)
            {                
                RAM.ChangeW((byte)(RAM.W | regValue));

                RAM.ZeroBit(bank);               
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(RAM.W | regValue));
                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
        }

        static void XORWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            if ((Befehl & 0x80) == 0)
            {             
                RAM.ChangeW((byte)(RAM.W ^ regValue));

                RAM.ZeroBit(bank);
            }
            else
            {                
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(RAM.W ^ regValue));

                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void COMF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            RAM.incInternalTimer(1);
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            if ((Befehl & 0x80) == 0)
            {               
                RAM.ChangeW((byte)(~regValue));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(~regValue));

                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
        }

        static void DECF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)(regValue-1));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(regValue-1));

                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void DECFSZ(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            bool zeroFlag = false;
            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)(regValue - 1));
                if (RAM.W == 0) zeroFlag = true;
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(regValue - 1));
                if ((byte)(regValue-1) == 0) zeroFlag = true;
            }

            if (zeroFlag == false)  //Wenn das Zero Flag nicht gesetzt ist, führe nächsten Befehl aus
            {
                ++RAM.RAM[bank, 2];
                RAM.incInternalTimer(1);
            }
            else //ansonsten überspringe den nächsten
            {
                RAM.RAM[bank, 2] += 2;
                RAM.incInternalTimer(2);
            }
        }

        static void INCF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)(regValue + 1));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(regValue + 1));

                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void INCFSZ(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            bool zeroFlag = false;
            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)(regValue + 1));
                if (RAM.W == 0) zeroFlag = true;
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(regValue + 1));
                if ((byte)(regValue+1) == 0) zeroFlag = true;
            }

            if (zeroFlag == false)     //Wenn das Zero Flag nicht gesetzt ist, führe nächsten Befehl aus
            {
                ++RAM.RAM[bank, 2];
                RAM.incInternalTimer(1);
            }
            else                        //ansonsten überspringe den nächsten
            {
                RAM.RAM[bank, 2] += 2;
                RAM.incInternalTimer(2);
            }
        }

        static void IORLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.ChangeW((byte)((0xFF & Befehl) | RAM.W));
            RAM.ZeroBit(bank);
            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void XORLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {

            RAM.ChangeW((byte)((0xFF & Befehl) ^ RAM.W));
            RAM.ZeroBit( bank);
            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void SUBLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempW = RAM.W;

            if ((0xFF & Befehl) > RAM.W) RAM.CarryBit(bank,1);
            else RAM.CarryBit(bank,0);                          //C
            if (((RAM.W & 0xF) + ((~Befehl & 0xF) + 1)) > 0xF) RAM.DigitCarryBit(bank, 1); //DC, Komplement des Subtrahenten wird addiert
            else RAM.DigitCarryBit(bank, 0);

            RAM.ChangeW((byte)((0xFF & Befehl) - RAM.W));

            RAM.ZeroBit(bank);

            

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void ADDLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if (((0xFF & Befehl) + RAM.W) > 0xFF) RAM.CarryBit(bank,1);
            else RAM.CarryBit(bank,0);                                 //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.DigitCarryBit(bank,1);
            else RAM.DigitCarryBit(bank,0);                              //DC, wenn die beiden Low Byte addiert >15 sind

            RAM.ChangeW((byte)((0xFF & Befehl) + RAM.W));

            RAM.ZeroBit(bank);
            

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void ADDWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 

            if ((regValue + RAM.W) > 0xFF) RAM.CarryBit(bank,1);
            else RAM.CarryBit(bank,0); //C
            if (((RAM.W & 0xF) + (regValue & 0xF)) > 0xF) RAM.DigitCarryBit(bank,1);
            else RAM.DigitCarryBit(bank,0); //DC, wenn die beiden Low Byte addiert >15 sind


            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)(RAM.W + regValue));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)(RAM.W + regValue));
                RAM.ZeroBit(bank, Befehl);
            }

                ++RAM.RAM[bank, 2];
                RAM.incInternalTimer(1);
        }

        static void SUBWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 

            if ((regValue + RAM.W) > 0xFF) RAM.CarryBit(bank,1);
            else RAM.CarryBit(bank,0); //C
            if (((RAM.W & 0xF) + ((~regValue & 0xF)+1)) > 0xF) RAM.DigitCarryBit(bank,1);
            else RAM.DigitCarryBit(bank,0); //DC, wenn Low Byte von W


            if ((Befehl & 0x80) == 0)
            {
                RAM.ChangeW((byte)( regValue - RAM.W ));
                RAM.ZeroBit(bank);
            }
            else
            {
                RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), (byte)( regValue - RAM.W));
                RAM.ZeroBit(bank, Befehl);
            }

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void SWAPF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));
  
            byte temp = (byte)(((regValue & 0x0F)*16)+((regValue & 0xF0) / 16));

            if ((Befehl & 0x80) == 0) RAM.ChangeW(temp);
            else RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), temp);

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void g0t0(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            UInt16 newPC = (UInt16)((Befehl & 0x7FF) + ((RAM.RAM[0, 0xA] & 0x18) << 8)); //Berechnung des neuen PC
            RAM.PC = newPC;                                                              //PC wird in den RAM geschrieben

            RAM.RAM[0, 2] = (byte)(Befehl & 0xFF);
            RAM.RAM[1, 2] = (byte)(Befehl & 0xFF);                                      //der PCL wird anhand des PC beschrieben

            RAM.incInternalTimer(2);
        }

        static void CALL(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            
            RAM.addStack(RAM.PC + 1);

            UInt16 newPC = (UInt16)((Befehl & 0x7FF) + ((RAM.RAM[0, 0xA] & 0x18) << 8)); //Berechnung des neuen PC
            RAM.PC = newPC;                                                              //PC wird in den RAM geschrieben

            RAM.RAM[0, 2] = (byte)(Befehl & 0xFF);
            RAM.RAM[1, 2] = (byte)(Befehl & 0xFF);                                      //der PCL wird anhand des PC beschrieben

            RAM.incInternalTimer(2);
        }

        static void RETURN(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.PC = (byte)RAM.Stack.Last();
            RAM.RAM[0, 2] = (byte)(RAM.PC & 0xFF);
            RAM.RAM[1, 2] = (byte)(RAM.PC & 0xFF);
            RAM.removeStack();
            RAM.incInternalTimer(2);
        }

        static void RETLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            RAM.ChangeW((byte)(Befehl & 0xFF));
            RAM.PC = (byte)RAM.Stack.Last();
            RAM.RAM[0, 2] = (byte)(RAM.PC & 0xFF);
            RAM.RAM[1, 2] = (byte)(RAM.PC & 0xFF);
            RAM.removeStack();
            RAM.incInternalTimer(2);
        }

        static void RLF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempState = RAM.RAM[bank, 3];
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));

            if ((regValue & 0x80) == 0) RAM.CarryBit(bank,0); //wenn das höchste Bit ==0, schreibe 0 in C-Bit
            else RAM.CarryBit(bank,1);

            regValue = (byte)(regValue *2);

            if ((tempState & 0x1) == 0) regValue = (byte)(regValue & 0xFE);         // wenn C-Bit == 0, dann wird 0 an das niedrigste Bit geschrieben
            else regValue = (byte)(regValue | 0x1);                                 // ansonsten 1       

            if ((Befehl & 0x80) == 0) RAM.ChangeW(regValue);
            else RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), regValue);

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void RRF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempState = RAM.RAM[0, 3];
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));

            if ((regValue & 0x1) == 0) RAM.CarryBit(bank,0); //wenn das niedrigste Bit == 0, schreibe 0 in C-Bit
            else RAM.CarryBit(bank,1);                          // ansonsten 1 in C-Bit

            regValue = (byte)(regValue / 2);

            if ((tempState & 0x1) == 0) regValue = (byte)(regValue & 0x7F);         // wenn C-Bit == 0, dann wird 0 an das höchste Bit geschrieben
            else regValue = (byte)(regValue | 0x80);                                 // ansonsten 1

            if ((Befehl & 0x80) == 0) RAM.ChangeW(regValue);
            else RAM.ChangeRegister(bank, (byte)(Befehl & 0x7F), regValue);

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void BSF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            int tempBit =(int) Math.Pow( 2, ((Befehl & 0x0380)>>7));

            RAM.ChangeRegister(bank,(byte)(Befehl & 0x7F), (byte)(regValue | tempBit)); 

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void BCF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));  
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            RAM.ChangeRegister(bank,(byte)(Befehl & 0x7F), (byte)(regValue & ~tempBit)); 

            ++RAM.RAM[bank, 2];
            RAM.incInternalTimer(1);
        }

        static void BTFSC(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F));
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((regValue & tempBit) == 0)
            {
                RAM.RAM[bank, 2] += 2;
                RAM.incInternalTimer(2);
            }
            else
            {
                ++RAM.RAM[bank, 2];
                RAM.incInternalTimer(1);
            }
        }

        static void BTFSS(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
            byte regValue = RAM.getRegisterValue(bank, (byte)(Befehl & 0x7F)); 
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((regValue & tempBit) == 0)
            {
                ++RAM.RAM[bank, 2];
                RAM.incInternalTimer(1);
            }
            else
            {
                RAM.RAM[bank, 2] += 2;
                RAM.incInternalTimer(2);
            }
            
        }

        static void RETFIE(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {

            RAM.PC = (byte)RAM.Stack.Last();
            RAM.RAM[0, 2] = (byte)(RAM.PC & 0xFF);
            RAM.RAM[1, 2] = (byte)(RAM.PC & 0xFF);
            RAM.removeStack();
            RAM.RAM[0, 0x0b] |= 0x80;
            RAM.RAM[1, 0x0b] |= 0x80;
            RAM.incInternalTimer(2);
        }

        static void SLEEP(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {

            RAM.RAM[bank, 3] |= 0x10; //TO = 1
            RAM.RAM[bank, 3] &= 0xF7; //PD = 0
            
        }
    }
}
