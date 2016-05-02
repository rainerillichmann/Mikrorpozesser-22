using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22
{
    public class CommandLine
    {
        public byte counter;
        public UInt16 command;

        public CommandLine(byte cou, UInt16 com)
        {
            this.counter = cou;
            this.command = com;

        }
        public CommandLine() : base() { }
    }
}
