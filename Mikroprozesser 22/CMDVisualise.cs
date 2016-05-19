using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22
{
    class CMDVisualise
    {
        public static string Befehlsstring(CommandLine Befehl)
        {

            //MOVLW
            if ((Befehl.command & 0x3F00) == 0x3000) return MOVLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3100) return MOVLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3200) return MOVLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3300) return MOVLW(Befehl.command);
            //MOVWF
            if ((Befehl.command & 0x3F80) == 0x0080) return MOVWF(Befehl.command);
            //MOVF
            if ((Befehl.command & 0x3F00) == 0x0800) return MOVF(Befehl.command);
            //ANDLW
            if ((Befehl.command & 0x3F00) == 0x3900) return ANDLW(Befehl.command);
            //ANDWF
            if ((Befehl.command & 0x3F00) == 0x0500) return ANDWF(Befehl.command);
            //IORLW
            if ((Befehl.command & 0x3F00) == 0x3800) return IORLW(Befehl.command);
            //IORWF
            if ((Befehl.command & 0x3F00) == 0x0400) return IORWF(Befehl.command);
            //SUBLW
            if ((Befehl.command & 0x3F00) == 0x3C00) return SUBLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3D00) return SUBLW(Befehl.command);
            //XORLW
            if ((Befehl.command & 0x3F00) == 0x3A00) return XORLW(Befehl.command);
            //XORWF
            if ((Befehl.command & 0x3F00) == 0x0600) return XORWF(Befehl.command);
            //ADDLW
            if ((Befehl.command & 0x3F00) == 0x3E00) return ADDLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3F00) return ADDLW(Befehl.command);
            //ADDWF
            if ((Befehl.command & 0x3F00) == 0x0700) return ADDWF(Befehl.command);
            //SUBWF
            if ((Befehl.command & 0x3F00) == 0x0200) return SUBWF(Befehl.command);
            //SWAPF
            if ((Befehl.command & 0x3F00) == 0x0E00) return SWAPF(Befehl.command);
            //GOTO
            if ((Befehl.command & 0x3800) == 0x2800) return g0t0(Befehl.command); 
            //CALL
            if ((Befehl.command & 0x3800) == 0x2000) return CALL(Befehl.command); 
            //NOP
            if ((Befehl.command & 0x3FFF) == 0x0000) return NOP(Befehl.command);
            if ((Befehl.command & 0x3FFF) == 0x0020) return NOP(Befehl.command);
            if ((Befehl.command & 0x3FFF) == 0x0040) return NOP(Befehl.command);
            if ((Befehl.command & 0x3FFF) == 0x0060) return NOP(Befehl.command);
            //RETURN
            if ((Befehl.command & 0x3FFF) == 0x0008) return RETURN(Befehl.command);
            //RETLW
            if ((Befehl.command & 0x3F00) == 0x3400) return RETLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3500) return RETLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3600) return RETLW(Befehl.command);
            if ((Befehl.command & 0x3F00) == 0x3700) return RETLW(Befehl.command); 
            //CLRF
            if ((Befehl.command & 0x3F80) == 0x0180) return CLRF(Befehl.command);
            //CLRW
            if (((Befehl.command & 0x3FFF) >= 0x0100) && ((Befehl.command & 0x3FFF) <= 0x017F)) return CLRW(Befehl.command);
            //RLF
            if ((Befehl.command & 0x3F00) == 0x0D00) return RLF(Befehl.command);
            //RRF
            if ((Befehl.command & 0x3F00) == 0x0C00) return RRF(Befehl.command);
            //COMF
            if ((Befehl.command & 0x3F00) == 0x0900) return COMF(Befehl.command);
            //DECF
            if ((Befehl.command & 0x3F00) == 0x0300) return DECF(Befehl.command);
            //DECFSZ
            if ((Befehl.command & 0x3F00) == 0x0B00) return DECFSZ(Befehl.command);
            //INCF
            if ((Befehl.command & 0x3F00) == 0x0A00) return INCF(Befehl.command);
            //INCFSZ
            if ((Befehl.command & 0x3F00) == 0x0F00) return INCFSZ(Befehl.command);
            //BSF
            if ((Befehl.command & 0x3C00) == 0x1400) return BSF(Befehl.command);
            //BCF
            if ((Befehl.command & 0x3C00) == 0x1000) return BCF(Befehl.command);
            //BTFSC
            if ((Befehl.command & 0x3C00) == 0x1800) return BTFSC(Befehl.command);
            //BTFSS
            if ((Befehl.command & 0x3C00) == 0x1C00) return BTFSS(Befehl.command);
            //RETFIE
            if ((Befehl.command & 0x3FFF) == 0x0009) return RETFIE(Befehl.command); 
            //SLEEP
            if ((Befehl.command & 0x3FFF) == 0x0063) return RETFIE(Befehl.command);
            return "";
        }

        static string NOP(int command)
        {
            return "NOP\t";
        }


        static string MOVLW(int command)
        {            
            return "MOVLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string MOVWF(int command)
        {
            return "MOVWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
        }

        static string MOVF(int command)
        {

            return "MOVF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string CLRF(int command)
        {

            return "CLRF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string CLRW(int command)
        {

            return "CLRW " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string ANDLW(int command)
        {

            return "ANDLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string ANDWF(int command)
        {

            if ((command & 0x80) == 0)
            {
                return "ANDWF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "ANDWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string IORWF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "IORWF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "IORWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string XORWF(int command)
        {

            if ((command & 0x80) == 0)
            {
                return "XORWF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "XORWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string COMF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "COMF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "COMF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string DECF(int command)
        {

            if ((command & 0x80) == 0)
            {
                return "DECF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w\t";
            }
            else
            {
                return "DECF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
            }
        }

        static string DECFSZ(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "DECFSZ " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "DECFSZ " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string INCF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "INCF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w\t";
            }
            else
            {
                return "INCF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
            }
        }

        static string INCFSZ(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "INCFSZ " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "INCFSZ " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string IORLW(int command)
        {

            return "IORLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string XORLW(int command)
        {

            return "XORLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string SUBLW(int command)
        {

            return "SUBLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string ADDLW(int command)
        {

            return "ADDLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string ADDWF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "ADDWF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "ADDWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string SUBWF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "SUBWF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "SUBWF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string SWAPF(int command)
        {
            if ((command & 0x80) == 0)
            {
                return "SWAPF " + Convert.ToString((int)(command & 0x7F), 16) + "h, w";
            }
            else
            {
                return "SWAPF " + Convert.ToString((int)(command & 0x7F), 16) + "h";
            }
        }

        static string g0t0(int command)
        {

            return "GOTO " + Convert.ToString((int)(command & 0x7F), 16) + "h ";
        }

        static string CALL(int command)
        {

            return "CALL " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string RETURN(int command)
        {
            return "RETURN\t";
        }

        static string RETLW(int command)
        {
            return "RETLW " + Convert.ToString((int)(command & 0xFF), 16) + "h";
        }

        static string RLF(int command)
        {

            return "RLF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string RRF(int command)
        {

            return "RRF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string BSF(int command)
        {
            return "BSF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string BCF(int command)
        {
            return "BCF " + Convert.ToString((int)(command & 0x7F), 16) + "h\t";
        }

        static string BTFSC(int command)
        {
            return "BTFSC " + Convert.ToString((int)(command & 0x7F), 16) + "h";
        }

        static string BTFSS(int command)
        {
            return "BTFSC " + Convert.ToString((int)(command & 0x7F), 16) + "h";
        }

        static string RETFIE(int command)
        {

            return "RETFIE \t";
        }

        static string SLEEP(int command)
        {
            return "SLEEP \t" ;

        }
    }
}
