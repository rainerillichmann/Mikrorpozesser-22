using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mikroprozesser_22
{
    public partial class Form1 : Form
    {
        
        string line;
        CommandLine Speicherding = new CommandLine();
        List<CommandLine> LineList = new List<CommandLine>();
        Arbeitsspeicher Speicher = new Arbeitsspeicher();
        
        

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e) //RB0
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit0.Checked == true) && ((Speicher.RAM[1, 6] & 0x01) == 0x01)) //TRISB Bit 0 muss gesetzt sein
            {
                Speicher.RAM[bank, 6] |= 0x01;
                if ((Speicher.RAM[0, 0x0B] & 0x10) == 0x10) Speicher.RAM[0,0xB] |= 0x02;
            }
            if ((RBBit0.Checked == false) && ((Speicher.RAM[1, 6] & 0x01) == 0x01))
            {
                Speicher.RAM[bank, 6] &= 0xFE;
                if ((Speicher.RAM[0, 0x0B] & 0x10) == 0x10) Speicher.RAM[0, 0xB] |= 0x02;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e) //RB1
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit1.Checked == true) && ((Speicher.RAM[1, 6] & 0x02) == 0x02)) //TRISB Bit 1 muss gesetzt sein
            {
                Speicher.RAM[bank, 6] |= 0x02;
            }
            if ((RBBit1.Checked == false) && ((Speicher.RAM[1, 6] & 0x02) == 0x02))
            {
                Speicher.RAM[bank, 6] &= 0xFD;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e) //RB2
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit2.Checked == true) && ((Speicher.RAM[1, 6] & 0x04) == 0x04)) //TRISB Bit 2 muss gesetzt sein
            {
                Speicher.RAM[bank, 6] |= 0x04;
            }
            if ((RBBit2.Checked == false) && ((Speicher.RAM[1, 6] & 0x04) == 0x04))
            {
                Speicher.RAM[bank, 6] &= 0xFB;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e) //RB3
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit3.Checked == true) && ((Speicher.RAM[1, 6] & 0x08) == 0x08)) //TRISB Bit 3 muss gesetzt sein
            {
                Speicher.RAM[bank, 6] |= 0x08;
            }
            if ((RBBit3.Checked == false) && ((Speicher.RAM[1, 6] & 0x04) == 0x04))
            {
                Speicher.RAM[bank, 6] &= 0xF7;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e) //RB4
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit4.Checked == true) && ((Speicher.RAM[1, 6] & 0x10) == 0x10)) //TRISB Bit 4 muss gesetzt sein
            {
                Speicher.RAM[bank, 6] |= 0x10;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0,0x0B] |= 0x01;
            }
            if ((RBBit4.Checked == false) && ((Speicher.RAM[1, 6] & 0x10) == 0x10)) 
            {
                Speicher.RAM[bank, 6] &= 0xEF;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e) //RB5
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit5.Checked == true) && ((Speicher.RAM[1, 6] & 0x20) == 0x20))
            {
                Speicher.RAM[bank, 6] |= 0x20;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
            if ((RBBit5.Checked == false) && ((Speicher.RAM[1, 6] & 0x20) == 0x20))
            {
                Speicher.RAM[bank, 6] &= 0xDF;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e) //RB6
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit6.Checked == true) && ((Speicher.RAM[1, 6] & 0x40) == 0x40))
            {
                Speicher.RAM[bank, 6] |= 0x40;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
            if ((RBBit6.Checked == false) && ((Speicher.RAM[1, 6] & 0x40) == 0x40))
            {
                Speicher.RAM[bank, 6] &= 0xBF;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e) //RB7
        {
            int bank = (Speicher.RAM[0, 3] & 0x20) >> 5;
            if ((RBBit7.Checked == true) && ((Speicher.RAM[1, 6] & 0x80) == 0x80))
            {
                Speicher.RAM[bank, 6] |= 0x80;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01; ;
            }
            if ((RBBit7.Checked == false) && ((Speicher.RAM[1, 6] & 0x80) == 0x80))
            {
                Speicher.RAM[bank, 6] &= 0x7F;
                if ((Speicher.RAM[0, 0x0B] & 0x08) == 0x08) Speicher.RAM[0, 0x0B] |= 0x01;
            }
        }

        private void dateiÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)  //Einlesen der Datei
            {
                //Einlesen der Datei über den File Explorer
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);

                //Dateiname wird in Titel des Forms geschrieben
                this.Text = "PIC16F84A - " + openFileDialog1.FileName;
               
                //Speicher wird resettet, Programmvisualisierung wird gelöscht, und Kommandoliste wird gecleart
                LineList.Clear();
                OutputDing.Clear();
                Speicher.Reset();

                //Zeilenweises Einlesen der Datei
                while ((line = sr.ReadLine()) != null)
                {
                    //temporäre Variable zum Speicher der jeweils 4 Zeichen großen Hex-Zahlen
                    char[] TempChar = new char[4];
                    
                    
                    //hier wird überprüft, ob die Zeile mit einer Zahl beginnt
                    if (((int)line[0] >= 48) && ((int)line[0] <= 57))
                    {   //Auslesen des Befehlscounters, also der ersten 4 Zeichen der Zeile
                        for (int i = 0; i < 4; i++)
                        {
                            TempChar[i] = line[i];
                        }
                        //Speichern der Chars in einem String um Convert Funktion zu benutzen
                        string TempCounter = new string(TempChar);
                        Speicherding.counter = Convert.ToUInt16(TempCounter, 16);

                        //Auslesen des Befehls, Zeichen 4 ist ein Leerzeichen, also bei Zeichen 5 der Zeile anfangen
                        for (int i = 5; i < 9; i++) 
                        {
                            TempChar[i - 5] = line[i];
                        }
                        string TempCommand = new string(TempChar);
                        Speicherding.command = Convert.ToUInt16(TempCommand, 16);

                        //Die so gespeicherten Daten werden einem Listenelement hinzugefügt, das später zur Ausgabe und Ausführung der Befehle
                        //verwendet wird
                        LineList.Add(new CommandLine (Speicherding.counter, Speicherding.command));
                    }
                }
                
                for (int i = 0; i < LineList.Count; i++) //Ausgabe der Befehlsliste
                {
                    OutputDing.Text += Convert.ToString(LineList[i].counter, 16) + "\t" + Convert.ToString(LineList[i].command, 16) + "\t" + CMDVisualise.Befehlsstring(LineList[i]) + "\t"; 
                    //falls ein BreakPoint gesetzt ist, füge ein 'X' ans Ende der Zeile hinzu
                    if (LineList[i].breakPoint == true) OutputDing.Text +="X" + System.Environment.NewLine;
                    else OutputDing.Text += System.Environment.NewLine;
                }
                sr.Close();

                //Markieren der Ersten Zeile als Programmstart
                OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
                OutputDing.SelectionBackColor = Color.Blue;
                OutputDing.SelectionColor = Color.White;

                //Aktivieren der Buttons und erste Visualisierung des RAM
                StartButton.Enabled = true;
                Einzelschritt.Enabled = true;
                StopButton.Enabled = true;
                Reset.Enabled = true;
                RAMVisualisierung();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OutputDing_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void Programmablauf(BackgroundWorker bw)
        {
            while (!bw.CancellationPending)
            {
                /* Hier werden nacheinander die Kommandos abgearbeitet, je nach Einstellung des Programmcounters.
                 * Zuerst wird die aktuelle Line der Texbox wieder ähnlich zu den restlichen Lines eingefärbt,
                 * danach der Befehl behandelt, welcher den PC verändert, und danach die entsprechende Zeile, auf die
                 * der neue PC zeigt, markiert.
                 * Anhand der If-Abfrage wird weiterhin gecheckt, ob diese Zeile einen Breakpoint enthält. Falls ja, wird der Background Worker gestoppt
                 * dabei ist eine Verzögerung eingebaut, um eine komplette Visualisierung des RAM noch zu ermöglichen.
                 * Nach einem Breakpoint muss ein Einzelschritt folgen, um den Breakpoint zu überwinden
                 * */
                if (LineList[Speicher.PC].breakPoint == false)
                {
                    OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
                    OutputDing.SelectionBackColor = Color.White;
                    OutputDing.SelectionColor = Color.Black;


                    Commands.Befehlsanalyse(LineList[Speicher.PC], Speicher);

                    OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
                    OutputDing.SelectionBackColor = Color.Blue;
                    OutputDing.SelectionColor = Color.White;
                }
                else
                {
                    this.backgroundWorker1.CancelAsync();
                    this.backgroundWorker2.CancelAsync();
                    System.Threading.Thread.Sleep(250);     //kurze Pause
                    RAMVisualisierung();                    //noch einmal vollständig Visualisieren
                    StartButton.Enabled = false;
                    Einzelschritt.Enabled = true;
                    Reset.Enabled = true;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;


            // Extract the argument.
            int arg = (int)e.Argument;

            // Start the time-consuming operation.
            Programmablauf(bw);

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }

           
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        private void Start_Click(object sender, EventArgs e)
        {
            /* Start startet die beiden Background Worker zum Programmablauf und der Visualisierung des RAM.
             * Einzelschritt und Reset werden dabei disabled um evtl. Probleme im Programmablauf zu vermeiden
             * */
            this.backgroundWorker1.RunWorkerAsync(2000);
            this.backgroundWorker2.RunWorkerAsync(2000);
            StartButton.Enabled = false;
            Einzelschritt.Enabled = false;
            Reset.Enabled = false;
            
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            /* Stop beendet die Backgroundworker und ermöglicht ein erneutes Starten, Einzelschritt, oder Resets vorzunehmen */
            this.backgroundWorker1.CancelAsync();
            this.backgroundWorker2.CancelAsync();
            StartButton.Enabled = true;
            Einzelschritt.Enabled = true;
            Reset.Enabled = true;
        }

        private void LWBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            /* Wird RA Bit4 verändert, wird noch einmal TRISA überprüft, und dann der Wert im RAM PortA gespeichert.
             * außerdem wird, falls T0CS auf 1 gesetzt ist, zur jeweiligen Flanke der Externe Counter des RAM erhöht,
             * welcher wiederrum über die Prescaler-Funktion geleitet wird, und so TIM0 entsprechend erhöht
             * */
            int bank = (Speicher.RAM[0, 3] & 0x20)>>5;
            if ((RABit4.Checked == true) && ((Speicher.RAM[1,5] & 0x10) == 0x10)) //TRISA Bit 4 = 1
            {
                Speicher.RAM[bank, 5] |= 0x10;
                if ((Speicher.RAM[1, 1] & 0x30) == 0x20) Speicher.incExternalTimer();
            }
            if ((RABit4.Checked == false) && ((Speicher.RAM[1, 5] & 0x10) == 0x10)) //TRISA Bit 4 = 1
            {
                Speicher.RAM[bank, 5] &= 0xEF;
                if ((Speicher.RAM[1, 1] & 0x30) == 0x30) Speicher.incExternalTimer();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;


            // Extract the argument.
            int arg = (int)e.Argument;

            // Start the time-consuming operation.
            VisualisierungBW(bw);

            // If the operation was canceled by the user, 
            // set the DoWorkEventArgs.Cancel property to true.
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void VisualisierungBW(BackgroundWorker bw)
        {
            /* Die Visualisierung wird in einem eigenen Backgroundworker aufgerugen, um ihn unabhängig vom 
             * Programmablauf zu machen, und diesen so nicht zu verlangsamen 
             * */
            while (!bw.CancellationPending)
            {

                RAMVisualisierung();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /** Dieser Button dazu einen Einzelschritt auszuführen
             * der Button ist nur aktiv, wenn kein Backgroundworker läuft
             * genauso werden die Zeilen auch hier wieder entsprechend markiert
             * */
            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
            OutputDing.SelectionBackColor = Color.White;
            OutputDing.SelectionColor = Color.Black;


            Commands.Befehlsanalyse(LineList[Speicher.PC], Speicher);

            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
            OutputDing.SelectionBackColor = Color.Blue;
            OutputDing.SelectionColor = Color.White;

            RAMVisualisierung();
            StartButton.Enabled = true;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            /** Der Reset Button hält das laufende Programm an, 
             *  der Start Button wird wieder enabled und der Prozessor erfährt 
             *  einen Power-On Reset, und die Anzeige der Befehle wird so umgestellt,
             *  dass Befehl 0 wieder markiert ist, und der RAM erneut visualisiert. 
             * */
            this.backgroundWorker1.CancelAsync();
            this.backgroundWorker2.CancelAsync();
            StartButton.Enabled = true;

            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
            OutputDing.SelectionBackColor = Color.White;
            OutputDing.SelectionColor = Color.Black;

            Speicher.Reset();

            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
            OutputDing.SelectionBackColor = Color.Blue;
            OutputDing.SelectionColor = Color.White;

            RAMVisualisierung();
        }

        private void RAMVisualisierung()
        {
            /** Der RAM wird visualisiert, 
             * */
            LWBox.Text = Convert.ToString(Speicher.W, 16);

            speicher1.Clear();
            speicher1.Text = "Bank0 \tValue\t|  Bank1\tValue\n";
            for (int i = 0x00; i < 64; i++)
            {
                speicher1.Text += Convert.ToString(i, 16) + "\t" + Convert.ToString(Speicher.RAM[0, i], 16) + "\t|  " + Convert.ToString(i, 16) + "\t" + Convert.ToString(Speicher.RAM[1, i], 16) + System.Environment.NewLine;
            }

            //Überprüfung und Ausgabe des Stacks
            try {Stack0.Text = Convert.ToString(Speicher.Stack[0], 16);}            
            catch {Stack0.Text = "";}

            try {Stack1.Text = Convert.ToString(Speicher.Stack[1], 16);}
            catch { Stack1.Text = "";}

            try { Stack2.Text = Convert.ToString(Speicher.Stack[2], 16);}
            catch {Stack2.Text = "";}

            try { Stack3.Text = Convert.ToString(Speicher.Stack[3], 16);}
            catch { Stack3.Text = "";}

            try { Stack4.Text = Convert.ToString(Speicher.Stack[4], 16);}
            catch { Stack4.Text = "";}

            try { Stack5.Text = Convert.ToString(Speicher.Stack[5], 16);}
            catch { Stack5.Text = "";}

            try { Stack6.Text = Convert.ToString(Speicher.Stack[6], 16);}
            catch{ Stack6.Text = "";}

            try{ Stack7.Text = Convert.ToString(Speicher.Stack[7], 16); }
            catch { Stack7.Text = "";}


            //Überprüfung auf TRISA und evtl setzen der Checkboxen
            if ((Speicher.RAM[1, 5] & 0x01) == 0x00)
            {
                RABit0.Enabled = false;
                if ((Speicher.RAM[0, 5] & 1) == 1) this.RABit0.Checked = true; else this.RABit0.Checked = false;
            }
            else RABit0.Enabled = true;
            if ((Speicher.RAM[1, 5] & 0x02) == 0x00)
            {
                RABit1.Enabled = false;
                if ((Speicher.RAM[0, 5] & 2) == 2) RABit1.Checked = true; else RABit1.Checked = false;
            }
            else RABit1.Enabled = true;
            if ((Speicher.RAM[1, 5] & 0x04) == 0x00)
            {
                RABit2.Enabled = false;
                if ((Speicher.RAM[0, 5] & 4) == 4) RABit2.Checked = true; else RABit2.Checked = false;
            }
            else RABit2.Enabled = true;
            if ((Speicher.RAM[1, 5] & 0x08) == 0x00)
            {
                RABit3.Enabled = false;
                if ((Speicher.RAM[0, 5] & 8) == 8) RABit3.Checked = true; else RABit3.Checked = false;
            }
            else RABit3.Enabled = true;
            if ((Speicher.RAM[1, 5] & 0x10) == 0x00)
            {
                RABit4.Enabled = false;
                if ((Speicher.RAM[0, 5] & 16) == 16) RABit4.Checked = true; else RABit4.Checked = false;
            }
            else RABit4.Enabled = true;

            //Überprüfung auf TRISB und evtl setzen der Checkboxen
            if ((Speicher.RAM[1, 6] & 0x01) == 0x00)
            {
                RBBit0.Enabled = false;
                if ((Speicher.RAM[0, 6] & 1) == 1) this.RBBit0.Checked = true; else this.RBBit0.Checked = false;
            }
            else RBBit0.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x02) == 0x00)
            {
                RBBit1.Enabled = false;
                if ((Speicher.RAM[0,6] & 2) == 2) RBBit1.Checked = true; else RBBit1.Checked = false;
            }
            else RBBit1.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x04) == 0x00)
            {
                RBBit2.Enabled = false;
                if ((Speicher.RAM[0, 6] & 4) == 4) RBBit2.Checked = true; else RBBit2.Checked = false;
            }
            else RBBit2.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x08) == 0x00)
            {
                RBBit3.Enabled = false;
                if ((Speicher.RAM[0, 6] & 8) == 8) RBBit3.Checked = true; else RBBit3.Checked = false;
            }
            else RBBit3.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x10) == 0x00)
            {
                RBBit4.Enabled = false;
                if ((Speicher.RAM[0, 6] & 16) == 16) RBBit4.Checked = true; else RBBit4.Checked = false;
            }
            else RBBit4.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x20) == 0x00)
            {
                RBBit5.Enabled = false;
                if ((Speicher.RAM[0, 6] & 0x20) == 0x20) RBBit5.Checked = true; else RBBit5.Checked = false;
            }
            else RBBit5.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x40) == 0x00)
            {
                RBBit6.Enabled = false;
                if ((Speicher.RAM[0, 6] & 0x40) == 0x40) RBBit6.Checked = true; else RBBit6.Checked = false;
            }
            else RBBit6.Enabled = true;
            if ((Speicher.RAM[1, 6] & 0x80) == 0x00)
            {
                RBBit7.Enabled = false;
                if ((Speicher.RAM[0, 6] & 0x80) == 0x80) RBBit7.Checked = true; else RBBit7.Checked = false;
            }
            else RBBit7.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuarzFrequenz_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void OutputDing_TextChanged_1(object sender, EventArgs e)
        {

        }

        

        private void OutputDing_DoubleClick(object sender, EventArgs e)
        {
            /*Bei einem Doppelklick auf eine Zeile wird die jeweilige Zeile gesucht 
             *und dem Befehl in dieser Zeile ein Breakpoint hinzugefügt.
             *Um dies anzuzeigen wird die Befehlsausgabe gecleart, und neu erzeugt
             */
            int firstcharindex = OutputDing.GetFirstCharIndexOfCurrentLine();
            int currentline = OutputDing.GetLineFromCharIndex(firstcharindex);
            if (LineList[currentline].breakPoint == true) LineList[currentline].breakPoint = false;
            else LineList[currentline].breakPoint = true;

            //Neu Erzeugen des Befehlsausgabe
            OutputDing.Clear();
            for (int i = 0; i < LineList.Count; i++) //Ausgabe der Befehlsliste
            {
                OutputDing.Text += Convert.ToString(LineList[i].counter, 16) + "\t" + Convert.ToString(LineList[i].command, 16) + "\t" + CMDVisualise.Befehlsstring(LineList[i]) + "\t";
                if (LineList[i].breakPoint == true) OutputDing.Text += "X" + System.Environment.NewLine;
                else OutputDing.Text += System.Environment.NewLine;
            }

            //Aktuelle Zeile des PC erneut markieren
            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.PC), OutputDing.Lines[Speicher.PC].Length);
            OutputDing.SelectionBackColor = Color.Blue;
            OutputDing.SelectionColor = Color.White;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Beendet das Programm
            System.Windows.Forms.Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
