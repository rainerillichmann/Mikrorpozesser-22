using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22
{
    class StatusChange
    {
        public static void ZeroBitW(Arbeitsspeicher RAM, int bank)
        {
            if (RAM.W == 0) RAM.RAM[bank, 3] = (byte)(RAM.RAM[bank, 3] | 0x4);// Z
            else RAM.RAM[bank, 3] = (byte)(RAM.RAM[0, 3] & 0xFB);
        }

        public static void ZeroBitF(Arbeitsspeicher RAM, int bank, UInt16 Befehl)
        {
            if (RAM.RAM[bank, (Befehl & 0x7F)] == 0) RAM.RAM[bank, 3] = (byte)(RAM.RAM[bank, 3] | 0x4); //Z
            else RAM.RAM[bank, 3] = (byte)(RAM.RAM[bank, 3] & 0xFB);
        }

        public static void SetCarry(Arbeitsspeicher RAM, int bank)
        {
            RAM.RAM[bank, 3] = (byte)(RAM.RAM[bank, 3] | 0x1);
        }

        public static void ClearCarry(Arbeitsspeicher RAM, int bank)
        {
            RAM.RAM[bank, 3] = (byte)(RAM.RAM[bank, 3] & 0xFE);
        }
    }
}
