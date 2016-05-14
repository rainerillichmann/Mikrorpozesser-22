using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mikroprozesser_22
{
    class Commands
    {
        public static void Befehlsanalyse(CommandLine Befehl, Arbeitsspeicher RAM)
        {
            byte tempBank = (byte)(RAM.RAM[0, 3]>>5);
            
            //MOVLW
            if ((Befehl.command & 0x3F00) == 0x3000) MOVLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3100) MOVLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3200) MOVLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3300) MOVLW(Befehl.command, RAM, tempBank);
            //MOVWF
            if ((Befehl.command & 0x3F80) == 0x0080) MOVWF(Befehl.command, RAM, tempBank);
            //MOVF
            if ((Befehl.command & 0x3F00) == 0x0800) MOVF(Befehl.command, RAM, tempBank);
            //ANDLW
            if ((Befehl.command & 0x3F00) == 0x3900) ANDLW(Befehl.command, RAM, tempBank);
            //ANDWF
            if ((Befehl.command & 0x3F00) == 0x0500) ANDWF(Befehl.command, RAM, tempBank);
            //IORLW
            if ((Befehl.command & 0x3F00) == 0x3800) IORLW(Befehl.command, RAM, tempBank);
            //IORWF
            if ((Befehl.command & 0x3F00) == 0x0400) IORWF(Befehl.command, RAM, tempBank);
            //SUBLW
            if ((Befehl.command & 0x3F00) == 0x3C00) SUBLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3D00) SUBLW(Befehl.command, RAM, tempBank); 
            //XORLW
            if ((Befehl.command & 0x3F00) == 0x3A00) XORLW(Befehl.command, RAM, tempBank); 
            //XORWF
            if ((Befehl.command & 0x3F00) == 0x0600) XORWF(Befehl.command, RAM, tempBank); 
            //ADDLW
            if ((Befehl.command & 0x3F00) == 0x3E00) ADDLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3F00) ADDLW(Befehl.command, RAM, tempBank); 
            //ADDWF
            if ((Befehl.command & 0x3F00) == 0x0700) ADDWF(Befehl.command, RAM, tempBank);
            //SUBWF
            if ((Befehl.command & 0x3F00) == 0x0200) SUBWF(Befehl.command, RAM, tempBank);
            //SWAPF
            if ((Befehl.command & 0x3F00) == 0x0E00) SWAPF(Befehl.command, RAM, tempBank);
            //GOTO
            if ((Befehl.command & 0x3800) == 0x2800) g0t0(Befehl.command, RAM, tempBank); 
            //CALL
            if ((Befehl.command & 0x3800) == 0x2000) CALL(Befehl.command, RAM, tempBank); 
            //NOP
            if ((Befehl.command & 0x3FFF) == 0x0000) ++RAM.RAM[tempBank, 2];
            if ((Befehl.command & 0x3FFF) == 0x0020) ++RAM.RAM[tempBank, 2];
            if ((Befehl.command & 0x3FFF) == 0x0040) ++RAM.RAM[tempBank, 2];
            if ((Befehl.command & 0x3FFF) == 0x0060) ++RAM.RAM[tempBank, 2];
            //RETURN
            if ((Befehl.command & 0x3FFF) == 0x0008) RETURN(Befehl.command, RAM, tempBank);
            //RETLW
            if ((Befehl.command & 0x3F00) == 0x3400) RETLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3500) RETLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3600) RETLW(Befehl.command, RAM, tempBank);
            if ((Befehl.command & 0x3F00) == 0x3700) RETLW(Befehl.command, RAM, tempBank);
            //CLRF
            if ((Befehl.command & 0x3F80) == 0x0180) CLRF(Befehl.command, RAM, tempBank);
            //CLRW
            if (((Befehl.command & 0x3FFF) >= 0x0100) && ((Befehl.command & 0x3FFF) <= 0x017F)) CLRW(Befehl.command, RAM, tempBank);
            //RLF
            if ((Befehl.command & 0x3F00) == 0x0D00) RLF(Befehl.command, RAM, tempBank);
            //RRF
            if ((Befehl.command & 0x3F00) == 0x0C00) RRF(Befehl.command, RAM, tempBank);
            //COMF
            if ((Befehl.command & 0x3F00) == 0x0900) COMF(Befehl.command, RAM, tempBank);
            //DECF
            if ((Befehl.command & 0x3F00) == 0x0300) DECF(Befehl.command, RAM, tempBank);
            //DECFSZ
            if ((Befehl.command & 0x3F00) == 0x0B00) DECFSZ(Befehl.command, RAM, tempBank);
            //INCF
            if ((Befehl.command & 0x3F00) == 0x0A00) INCF(Befehl.command, RAM, tempBank);
            //INCFSZ
            if ((Befehl.command & 0x3F00) == 0x0F00) INCFSZ(Befehl.command, RAM, tempBank);
            //BSF
            if ((Befehl.command & 0x3C00) == 0x1400) BSF(Befehl.command, RAM, tempBank);
            //BCF
            if ((Befehl.command & 0x3C00) == 0x1000) BCF(Befehl.command, RAM, tempBank);
            //BTFSC
            if ((Befehl.command & 0x3C00) == 0x1800) BTFSC(Befehl.command, RAM, tempBank);
            //BTFSS
            if ((Befehl.command & 0x3C00) == 0x1C00) BTFSS(Befehl.command, RAM, tempBank);

            if (tempBank == 0) for (int i = 2; i < 5; i++) RAM.RAM[1, i] = RAM.RAM[0, i];
            else for (int i = 2; i < 5; i++) RAM.RAM[0, i] = RAM.RAM[1, i];
        }

        static void MOVLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            ++RAM.RAM[bank, 2];
            RAM.W = (byte)(0xFF & Befehl);
            
        }

        static void MOVWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            ++RAM.RAM[bank, 2];
            RAM.RAM[bank,(Befehl & 0x007F)] = RAM.W;
            
        }

        static void MOVF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            ++RAM.RAM[bank, 2];

            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[bank, (Befehl & 0x7F)]);
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }      
        }

        static void CLRF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             

            RAM.RAM[bank, (Befehl & 0x007F)] = 0;
            StatusChange.ZeroBitF(RAM, bank, Befehl);
            ++RAM.RAM[bank, 2];
        }

        static void CLRW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             

            RAM.W = 0;
            StatusChange.ZeroBitW(RAM, bank);
            ++RAM.RAM[bank, 2];
        }

        static void ANDLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             

            RAM.W = (byte)((0xFF & Befehl) & RAM.W);

            StatusChange.ZeroBitW(RAM, bank);
            ++RAM.RAM[0, 2];
        }

        static void ANDWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W & (RAM.RAM[0, (Befehl & 0x7F)]));
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W & (RAM.RAM[0, (Befehl & 0x7F)]));

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void IORWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W | (RAM.RAM[0, (Befehl & 0x7F)]));
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W | (RAM.RAM[0, (Befehl & 0x7F)]));

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void XORWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W ^ (RAM.RAM[0, (Befehl & 0x7F)]));
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W ^ (RAM.RAM[0, (Befehl & 0x7F)]));

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void COMF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)~(RAM.RAM[0, (Befehl & 0x7F)]);
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)~(RAM.RAM[0, (Befehl & 0x7F)]);

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void DECF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)]-1);
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)]-1);

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void DECFSZ(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            bool zeroFlag = false;
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)] - 1);
                if (RAM.W == 0) zeroFlag = true;
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] - 1);
                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) zeroFlag = true;
            }

            if (zeroFlag == false) ++RAM.RAM[0, 2];                              //Wenn das Zero Flag nicht gesetzt ist, führe nächsten Befehl aus
            else RAM.RAM[0, 2] += 2;                                             //ansonsten überspringe den nächsten
        }

        static void INCF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);
                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void INCFSZ(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            bool zeroFlag = false;
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);
                if (RAM.W == 0) zeroFlag = true;
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);
                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) zeroFlag = true;
            }

            if (zeroFlag == false) ++RAM.RAM[0, 2];                              //Wenn das Zero Flag nicht gesetzt ist, führe nächsten Befehl aus
            else RAM.RAM[0, 2] += 2;                                             //ansonsten überspringe den nächsten
        }

        static void IORLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.W = (byte)((0xFF & Befehl) | RAM.W);
            StatusChange.ZeroBitW(RAM, bank);
            ++RAM.RAM[0, 2];
        }

        static void XORLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.W = (byte)((0xFF & Befehl) ^ RAM.W);
            StatusChange.ZeroBitW(RAM, bank);
            ++RAM.RAM[0, 2];
        }

        static void SUBLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempLW = RAM.W;

            if ((0xFF & Befehl) > RAM.W) StatusChange.SetCarry(RAM,bank);
            else StatusChange.ClearCarry(RAM, bank);                          //C

            RAM.W = (byte)((0xFF & Befehl) - RAM.W);


            StatusChange.ZeroBitW(RAM, bank);

            if (((RAM.W & 0xF) + ~(Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2); //DC, komplett des Subtrahenten wird addiert
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD);

            ++RAM.RAM[0, 2];
        }

        static void ADDLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             

            if (((0xFF & Befehl) + RAM.W) > 0xFF) StatusChange.SetCarry(RAM, bank);
            else StatusChange.ClearCarry(RAM, bank);                                 //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD);                              //DC, wenn die beiden Low Byte addiert >15 sind

            RAM.W = (byte)((255 & Befehl) + RAM.W);


            StatusChange.ZeroBitW(RAM, bank);
            

            ++RAM.RAM[0, 2];
        }

        static void ADDWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            if (((0xFF & Befehl) + RAM.W) > 0xFF) StatusChange.SetCarry(RAM, bank);
            else StatusChange.ClearCarry(RAM, bank); //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD); //DC, wenn die beiden Low Byte addiert >15 sind


            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W + (RAM.RAM[0,(Befehl & 0x7F)]));

                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W + (RAM.RAM[0, (Befehl & 0x7F)]));

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

                ++RAM.RAM[0, 2];
        }

        static void SUBWF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             

            if (((0xFF & Befehl) + RAM.W) > 0xFF) StatusChange.SetCarry(RAM, bank);
            else StatusChange.ClearCarry(RAM, bank); //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD); //DC, wenn die beiden Low Byte addiert >15 sind


            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)((RAM.RAM[0, (Befehl & 0x7F)]) -RAM.W);

                StatusChange.ZeroBitW(RAM, bank);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)((RAM.RAM[0, (Befehl & 0x7F)]) - RAM.W);

                StatusChange.ZeroBitF(RAM, bank, Befehl);
            }

            ++RAM.RAM[0, 2];
        }

        static void SWAPF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte temp = (byte)(((RAM.RAM[0, (Befehl & 0x7F)] & 0x0F)*16)+((RAM.RAM[0, (Befehl & 0x7F)] & 0xF0) / 16));
            if ((Befehl & 0x80) == 0)
            {
                
                RAM.W = temp;

            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = temp;

            }

            ++RAM.RAM[0, 2];
        }

        static void g0t0(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.RAM[0, 2] = (byte)(Befehl & 0x7FF);
        }

        static void CALL(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.addStack(RAM.RAM[0, 2] + 1);
            RAM.RAM[0, 2] = (byte)(Befehl & 0x7FF);
        }

        static void RETURN(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.RAM[0, 2] = (byte)RAM.Stack.Last();
            RAM.Stack.RemoveAt(RAM.Stack.Count -1);
        }

        static void RETLW(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            RAM.W = (byte)(Befehl & 0xFF);
            RAM.RAM[0, 2] = (byte)RAM.Stack.Last();
            RAM.Stack.RemoveAt(RAM.Stack.Count - 1);
        }

        static void RLF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempState = RAM.RAM[0, 3];
            byte tempNumber = (byte)(RAM.RAM[0,(Befehl & 0x7F)]);

            if ((tempNumber & 0x80) == 0) StatusChange.ClearCarry(RAM, bank); //wenn das höchste Bit ==0, schreibe 0 in C-Bit
            else StatusChange.SetCarry(RAM, bank);

            tempNumber = (byte)(tempNumber *2);

            if ((tempState & 0x1) == 0) tempNumber = (byte)(tempNumber & 0xFE);         // wenn C-Bit == 0, dann wird 0 an das niedrigste Bit geschrieben
            else tempNumber = (byte)(tempNumber | 0x1);                                 // ansonsten 1

            
               

            if ((Befehl & 0x80) == 0)
            {
                RAM.W = tempNumber;
                
            }
            else
            {

                RAM.RAM[0, (Befehl & 0x7F)] = tempNumber;
            }

            ++RAM.RAM[0, 2];
        }

        static void RRF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            byte tempState = RAM.RAM[0, 3];
            byte tempNumber = (byte)(RAM.RAM[0, (Befehl & 0x7F)]);

            if ((tempNumber & 0x1) == 0) StatusChange.ClearCarry(RAM, bank); //wenn das niedrigste Bit == 0, schreibe 0 in C-Bit
            else StatusChange.SetCarry(RAM, bank);                          // ansonsten 1 in C-Bit

            tempNumber = (byte)(tempNumber / 2);

            if ((tempState & 0x1) == 0) tempNumber = (byte)(tempNumber & 0x7F);         // wenn C-Bit == 0, dann wird 0 an das höchste Bit geschrieben
            else tempNumber = (byte)(tempNumber | 0x80);                                 // ansonsten 1

            if ((Befehl & 0x80) == 0)
            {
                RAM.W = tempNumber;

            }
            else
            {

                RAM.RAM[0, (Befehl & 0x7F)] = tempNumber;
            }

            ++RAM.RAM[0, 2];
        }

        static void BSF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            int tempBit =(int) Math.Pow( 2, ((Befehl & 0x0380)>>7));
            RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] | tempBit);
            ++RAM.RAM[0, 2];
        }

        static void BCF(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));
            RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] & ~tempBit);
            ++RAM.RAM[0, 2];
        }

        static void BTFSC(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((RAM.RAM[0, (Befehl & 0x7F)] & tempBit) == 0) RAM.RAM[0, 2] += 2;
            else ++RAM.RAM[0, 2];
        }

        static void BTFSS(UInt16 Befehl, Arbeitsspeicher RAM, byte bank)
        {
             
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((RAM.RAM[0, (Befehl & 0x7F)] & tempBit) == 0) ++RAM.RAM[0, 2];
            else RAM.RAM[0, 2] += 2;
            
        }
    }
}
