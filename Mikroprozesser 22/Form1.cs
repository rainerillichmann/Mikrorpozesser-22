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
        int counter = 0;
        

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateiÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)  //Einlesen der Datei
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                LineList.Clear();
                OutputDing.Clear();
                Speicher.Reset();
                while ((line = sr.ReadLine()) != null)
                {
                    char[] TempChar = new char[4];
                    
                    
                    
                    if (((int)line[0] >= 48) && ((int)line[0] <= 57))
                    {   //Auslesen des Befehlscounters
                        for (int i = 0; i < 4; i++)
                        {
                            TempChar[i] = line[i];
                        }
                        string TempCounter = new string(TempChar);
                        Speicherding.counter = Convert.ToUInt16(TempCounter, 16);
                        
                        for (int i = 5; i < 9; i++) //Auslesen des Befehls
                        {
                            TempChar[i - 5] = line[i];
                        }
                        string TempCommand = new string(TempChar);
                        Speicherding.command = Convert.ToUInt16(TempCommand, 16);
                        LineList.Add(new CommandLine (Speicherding.counter, Speicherding.command));
                    }
                }
                for (int i = 0; i < LineList.Count; i++) //Ausgabe der Befehlsliste
                {
                    OutputDing.Text +=  LineList[i].counter + " " + Convert.ToString(LineList[i].command, 16) + System.Environment.NewLine;
                }
                sr.Close();
                OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.RAM[0, 2]), OutputDing.Lines[Speicher.RAM[0, 2]].Length);
                OutputDing.SelectionBackColor = Color.Blue;
                OutputDing.SelectionColor = Color.White;
                button1.Enabled = true;
                
                
         

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
                

                LWBox.Text = Speicher.W.ToString();
                if ((Speicher.RAM[0, 5] & 1) == 1) this.checkBox8.Checked = true; else this.checkBox8.Checked = false;
                if ((Speicher.RAM[0, 5] & 2) == 2) checkBox7.Checked = true; else checkBox7.Checked = false;
                if ((Speicher.RAM[0, 5] & 4) == 4) checkBox6.Checked = true; else checkBox6.Checked = false;
                if ((Speicher.RAM[0, 5] & 8) == 8) checkBox5.Checked = true; else checkBox5.Checked = false;
                if ((Speicher.RAM[0, 5] & 16) == 16) checkBox4.Checked = true; else checkBox4.Checked = false;
                if ((Speicher.RAM[0, 5] & 32) == 32) checkBox3.Checked = true; else checkBox3.Checked = false;
                if ((Speicher.RAM[0, 5] & 64) == 64) checkBox2.Checked = true; else checkBox2.Checked = false;
                if ((Speicher.RAM[0, 5] & 128) == 128) checkBox1.Checked = true; else checkBox1.Checked = false;
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
            //this.backgroundWorker1.RunWorkerAsync(2000);
            
            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.RAM[0, 2]), OutputDing.Lines[Speicher.RAM[0, 2]].Length);
            OutputDing.SelectionBackColor = Color.White;
            OutputDing.SelectionColor = Color.Black;   
            
            
            Commands.Befehlsanalyse(LineList[Speicher.RAM[0, 2]], Speicher);

            OutputDing.Select(OutputDing.GetFirstCharIndexFromLine(Speicher.RAM[0, 2]), OutputDing.Lines[Speicher.RAM[0, 2]].Length);
            OutputDing.SelectionBackColor = Color.Blue;
            OutputDing.SelectionColor = Color.White;
            LWBox.Text = Convert.ToString(Speicher.W, 16);
            Box0Ch.Text = Convert.ToString(Speicher.RAM[0,12], 16);
            Box0Dh.Text = Convert.ToString(Speicher.RAM[0,13], 16);
            Box0Eh.Text = Convert.ToString(Speicher.RAM[0, 14], 16);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
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

        
    }
}
