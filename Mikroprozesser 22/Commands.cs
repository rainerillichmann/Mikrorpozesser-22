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
            
            //MOVLW
            if ((Befehl.command & 0x3F00) == 0x3000) MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3100) MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3200) MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3300) MOVLW(Befehl.command, RAM);
            //MOVWF
            if ((Befehl.command & 0x3F80) == 0x0080) MOVWF(Befehl.command, RAM);
            //MOVF
            if ((Befehl.command & 0x3F00) == 0x0800) MOVF(Befehl.command, RAM);
            //ANDLW
            if ((Befehl.command & 0x3F00) == 0x3900) ANDLW(Befehl.command, RAM);
            //ANDWF
            if ((Befehl.command & 0x3F00) == 0x0500) ANDWF(Befehl.command, RAM);
            //IORLW
            if ((Befehl.command & 0x3F00) == 0x3800) IORLW(Befehl.command, RAM);
            //IORWF
            if ((Befehl.command & 0x3F00) == 0x0400) IORWF(Befehl.command, RAM);
            //SUBLW
            if ((Befehl.command & 0x3F00) == 0x3C00) SUBLW(Befehl.command, RAM); 
            if ((Befehl.command & 0x3F00) == 0x3D00) SUBLW(Befehl.command, RAM); 
            //XORLW
            if ((Befehl.command & 0x3F00) == 0x3A00) XORLW(Befehl.command, RAM); 
            //XORWF
            if ((Befehl.command & 0x3F00) == 0x0600) XORWF(Befehl.command, RAM); 
            //ADDLW
            if ((Befehl.command & 0x3F00) == 0x3E00) ADDLW(Befehl.command, RAM); 
            if ((Befehl.command & 0x3F00) == 0x3F00) ADDLW(Befehl.command, RAM); 
            //ADDWF
            if ((Befehl.command & 0x3F00) == 0x0700) ADDWF(Befehl.command, RAM);
            //SUBWF
            if ((Befehl.command & 0x3F00) == 0x0200) SUBWF(Befehl.command, RAM);
            //SWAPF
            if ((Befehl.command & 0x3F00) == 0x0E00) SWAPF(Befehl.command, RAM);
            //GOTO
            if ((Befehl.command & 0x3800) == 0x2800) g0t0(Befehl.command, RAM); 
            //CALL
            if ((Befehl.command & 0x3800) == 0x2000) CALL(Befehl.command, RAM); 
            //NOP
            if ((Befehl.command & 0x3FFF) == 0x0000) ++RAM.RAM[0,2];
            if ((Befehl.command & 0x3FFF) == 0x0020) ++RAM.RAM[0, 2];
            if ((Befehl.command & 0x3FFF) == 0x0040) ++RAM.RAM[0, 2];
            if ((Befehl.command & 0x3FFF) == 0x0060) ++RAM.RAM[0, 2];
            //RETURN
            if ((Befehl.command & 0x3FFF) == 0x0008) RETURN(Befehl.command, RAM);
            //RETLW
            if ((Befehl.command & 0x3F00) == 0x3400) RETLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3500) RETLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3600) RETLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3700) RETLW(Befehl.command, RAM);
            //CLRF
            if ((Befehl.command & 0x3F80) == 0x0180) CLRF(Befehl.command, RAM);
            //CLRW
            if (((Befehl.command & 0x3FFF) >= 0x0100) && ((Befehl.command & 0x3FFF) <= 0x017F)) CLRW(Befehl.command, RAM);
            //RLF
            if ((Befehl.command & 0x3F00) == 0x0D00) RLF(Befehl.command, RAM);
            //RRF
            if ((Befehl.command & 0x3F00) == 0x0C00) RRF(Befehl.command, RAM);
            //COMF
            if ((Befehl.command & 0x3F00) == 0x0900) COMF(Befehl.command, RAM);
            //DECF
            if ((Befehl.command & 0x3F00) == 0x0300) DECF(Befehl.command, RAM);
            //DECFSZ
            if ((Befehl.command & 0x3F00) == 0x0B00) DECFSZ(Befehl.command, RAM);
            //INCF
            if ((Befehl.command & 0x3F00) == 0x0A00) INCF(Befehl.command, RAM);
            //INCFSZ
            if ((Befehl.command & 0x3F00) == 0x0F00) INCFSZ(Befehl.command, RAM);
            //BSF
            if ((Befehl.command & 0x3C00) == 0x1400) BSF(Befehl.command, RAM);
            //BCF
            if ((Befehl.command & 0x3C00) == 0x1000) BCF(Befehl.command, RAM);
            //BTFSC
            if ((Befehl.command & 0x3C00) == 0x1800) BTFSC(Befehl.command, RAM);
            //BTFSS
            if ((Befehl.command & 0x3C00) == 0x1C00) BTFSS(Befehl.command, RAM);
        }

        static void MOVLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = (byte)(0xFF & Befehl);
            ++RAM.RAM[0, 2];
        }

        static void MOVWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.RAM[0,(Befehl & 0x007F)] = RAM.W;
            ++RAM.RAM[0, 2];
        }

        static void MOVF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)]);
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void CLRF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.RAM[0, (Befehl & 0x007F)] = 0;
            RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
            ++RAM.RAM[0, 2];
        }

        static void CLRW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = 0;
            RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
            ++RAM.RAM[0, 2];
        }

        static void ANDLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = (byte)((0xFF & Befehl) & RAM.W);
            if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            ++RAM.RAM[0, 2];
        }

        static void ANDWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W & (RAM.RAM[0, (Befehl & 0x7F)]));
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W & (RAM.RAM[0, (Befehl & 0x7F)]));

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void IORWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W | (RAM.RAM[0, (Befehl & 0x7F)]));
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W | (RAM.RAM[0, (Befehl & 0x7F)]));

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void XORWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W ^ (RAM.RAM[0, (Befehl & 0x7F)]));
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W ^ (RAM.RAM[0, (Befehl & 0x7F)]));

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void COMF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)~(RAM.RAM[0, (Befehl & 0x7F)]);
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)~(RAM.RAM[0, (Befehl & 0x7F)]);

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void DECF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)]-1);
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)]-1);

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void DECFSZ(UInt16 Befehl, Arbeitsspeicher RAM)
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

        static void INCF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);
                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] + 1);

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); //Z
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            }

            ++RAM.RAM[0, 2];
        }

        static void INCFSZ(UInt16 Befehl, Arbeitsspeicher RAM)
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

        static void IORLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = (byte)((0xFF & Befehl) | RAM.W);
            if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            ++RAM.RAM[0, 2];
        }

        static void XORLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = (byte)((0xFF & Befehl) ^ RAM.W);
            if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
            ++RAM.RAM[0, 2];
        }

        static void SUBLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            byte tempLW = RAM.W;

            if ((0xFF & Befehl) > RAM.W) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE);                          //C

            RAM.W = (byte)((0xFF & Befehl) - RAM.W);


            if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);// Z

            if (((RAM.W & 0xF) + ~(Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2); //DC, komplett des Subtrahenten wird addiert
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD);

            ++RAM.RAM[0, 2];
        }

        static void ADDLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
           

            if (((0xFF & Befehl) + RAM.W) > 0xFF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE);                                  //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD);                              //DC, wenn die beiden Low Byte addiert >15 sind

            RAM.W = (byte)((255 & Befehl) + RAM.W);


            if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);              // Z
            

            ++RAM.RAM[0, 2];
        }

        static void ADDWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if (((0xFF & Befehl) + RAM.W) > 0xFF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE); //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD); //DC, wenn die beiden Low Byte addiert >15 sind


            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)(RAM.W + (RAM.RAM[0,(Befehl & 0x7F)]));

                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);              // Z
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.W + (RAM.RAM[0, (Befehl & 0x7F)]));

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);              // Z
            }

                ++RAM.RAM[0, 2];
        }

        static void SUBWF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            if (((0xFF & Befehl) + RAM.W) > 0xFF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE); //C
            if (((RAM.W & 0xF) + (Befehl & 0xF)) > 0xF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2);
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFD); //DC, wenn die beiden Low Byte addiert >15 sind


            if ((Befehl & 0x80) == 0)
            {
                RAM.W = (byte)((RAM.RAM[0, (Befehl & 0x7F)]) -RAM.W);

                if (RAM.W == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);              // Z
            }
            else
            {
                RAM.RAM[0, (Befehl & 0x7F)] = (byte)((RAM.RAM[0, (Befehl & 0x7F)]) - RAM.W);

                if (RAM.RAM[0, (Befehl & 0x7F)] == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);
                else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);              // Z
            }

            ++RAM.RAM[0, 2];
        }

        static void SWAPF(UInt16 Befehl, Arbeitsspeicher RAM)
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

        static void g0t0(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.RAM[0, 2] = (byte)(Befehl & 0x7FF);
        }

        static void CALL(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.addStack(RAM.RAM[0, 2] + 1);
            RAM.RAM[0, 2] = (byte)(Befehl & 0x7FF);
        }

        static void RETURN(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            
            RAM.RAM[0, 2] = (byte)RAM.Stack.Last();
            RAM.Stack.RemoveAt(RAM.Stack.Count -1);
        }

        static void RETLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.W = (byte)(Befehl & 0xFF);
            RAM.RAM[0, 2] = (byte)RAM.Stack.Last();
            RAM.Stack.RemoveAt(RAM.Stack.Count - 1);
        }

        static void RLF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            byte tempState = RAM.RAM[0, 3];
            byte tempNumber = (byte)(RAM.RAM[0,(Befehl & 0x7F)]);

            if ((tempNumber & 0x80) == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE); //wenn das höchste Bit ==0, schreibe 0 in C-Bit
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);

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

        static void RRF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            byte tempState = RAM.RAM[0, 3];
            byte tempNumber = (byte)(RAM.RAM[0, (Befehl & 0x7F)]);

            if ((tempNumber & 0x1) == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] & 0xFE); //wenn das niedrigste Bit == 0, schreibe 0 in C-Bit
            else RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1);                           // ansonsten 1 in C-Bit

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

        static void BSF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            int tempBit =(int) Math.Pow( 2, ((Befehl & 0x0380)>>7));
            RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] | tempBit);
            ++RAM.RAM[0, 2];
        }

        static void BCF(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));
            RAM.RAM[0, (Befehl & 0x7F)] = (byte)(RAM.RAM[0, (Befehl & 0x7F)] & ~tempBit);
            ++RAM.RAM[0, 2];
        }

        static void BTFSC(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((RAM.RAM[0, (Befehl & 0x7F)] & tempBit) == 0) RAM.RAM[0, 2] += 2;
            else ++RAM.RAM[0, 2];
        }

        static void BTFSS(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            int tempBit = (int)Math.Pow(2, ((Befehl & 0x0380) >> 7));

            if ((RAM.RAM[0, (Befehl & 0x7F)] & tempBit) == 0) ++RAM.RAM[0, 2];
            else RAM.RAM[0, 2] += 2;
            
        }
    }
}
