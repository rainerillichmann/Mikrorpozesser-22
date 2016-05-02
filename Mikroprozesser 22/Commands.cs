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
            if ((Befehl.command & 0x3F00) == 0x3000)  MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3100) MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3200) MOVLW(Befehl.command, RAM);
            if ((Befehl.command & 0x3F00) == 0x3300) MOVLW(Befehl.command, RAM);
            //ANDLW
            if ((Befehl.command & 0x3F00) == 0x3900) ANDLW(Befehl.command, RAM);
            //IORLW
            if ((Befehl.command & 0x3F00) == 0x3800) IORLW(Befehl.command, RAM);
            //SUBLW
            if ((Befehl.command & 0x3F00) == 0x3C00) SUBLW(Befehl.command, RAM); 
            if ((Befehl.command & 0x3F00) == 0x3D00) SUBLW(Befehl.command, RAM); 
            //XORLW
            if ((Befehl.command & 0x3F00) == 0x3A00) XORLW(Befehl.command, RAM); 
            //ADDLW
            if ((Befehl.command & 0x3F00) == 0x3E00) ADDLW(Befehl.command, RAM); 
            if ((Befehl.command & 0x3F00) == 0x3F00) ADDLW(Befehl.command, RAM); 
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
        }

        static void MOVLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.LW = (byte)(0xFF & Befehl);
            ++RAM.RAM[0, 2];
        }

        static void ANDLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.LW = (byte)((0xFF & Befehl) & RAM.LW);
            if (RAM.LW == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            ++RAM.RAM[0, 2];
        }

        static void IORLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.LW = (byte)((0xFF & Befehl) | RAM.LW);
            if (RAM.LW == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            ++RAM.RAM[0, 2];
        }

        static void XORLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            RAM.LW = (byte)((0xFF & Befehl) ^ RAM.LW);
            if (RAM.LW == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4);// Z
            ++RAM.RAM[0, 2];
        }

        static void SUBLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            byte tempLW = RAM.LW;

            if ((0xFF & Befehl) > RAM.LW) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1); //C

            RAM.LW = (byte)((0xFF & Befehl) - RAM.LW);


            if (RAM.LW == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); // Z
            if ((RAM.LW & 16) != (tempLW & 16)) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2); //DC

            ++RAM.RAM[0, 2];
        }

        static void ADDLW(UInt16 Befehl, Arbeitsspeicher RAM)
        {
            byte tempLW = RAM.LW;

            if (((0xFF & Befehl) + RAM.LW) > 0xFF) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x1); //C

            RAM.LW = (byte)((255 & Befehl) + RAM.LW);


            if (RAM.LW == 0) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x4); // Z
            if ((RAM.LW & 16) != (tempLW & 16)) RAM.RAM[0, 3] = (byte)(RAM.RAM[0, 3] | 0x2); //DC

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
    }
}
