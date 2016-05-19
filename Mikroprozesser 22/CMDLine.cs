using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22
{
    public class CommandLine
    {
        /*Eine Klasse zum Speichern einer Befehlszeile. Dabei werden die Programmzeile
         * und das Kommando der Zeile gespeichert, sowie ob in der jeweiligen Zeile 
         * ein Breakpoint vorhanden ist
         */
        public UInt16 counter;
        public UInt16 command;
        public bool breakPoint;

        public CommandLine(UInt16 cou, UInt16 com)
        {
            //Konstruktor 
            this.counter = cou;
            this.command = com;
            this.breakPoint = false;
        }
        public CommandLine() : base() { }
    }
}
