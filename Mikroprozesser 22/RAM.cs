using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroprozesser_22

{
    public class Arbeitsspeicher
    {
        public byte[,] RAM = new byte [2,64];
        public UInt16 ConfigurationWord = 0;
        public byte W = 0;
        public UInt16 PC = 0;
        public List<int> Stack = new List<int>();
        
        int stackCounter = 0;
       
        public uint internalTimerCounter = 0;
        public uint runTimeCounter = 0;
        public uint externalTimerCounter = 0;

        public byte frequenzy = 4;
        public double runTime = 0;
        public double watchdogTimeout = 0;
        public double watchdogStartTime = 0;

        public void addStack(int pc)
        {
            /* Der Stack des RAM wird beschrieben, und der stackCounter erhöht.

              * Wird nun versucht mehr als acht mal in den Stack zu schreiben, werden 
              * wieder die ersten Elemente des Stack überschrieben, mit Hilfe des stackCounter
              */

            if (this.Stack.Count() < 8) this.Stack.Add(pc);
            else this.Stack[stackCounter % 8] = pc;
            this.stackCounter++;
        }

        public void removeStack()
        {
            // Letzes Element des Stack wird gelöscht, und stackCounter um 1 verringert
            this.Stack.RemoveAt(this.Stack.Count - 1);
            this.stackCounter--;
        }

        public Arbeitsspeicher()
        {
            //Konstruktor
            this.RAM[0, 0] = 0x00; //INDF
            this.RAM[0, 1] = 0x00; //TIMR0
            this.RAM[0, 2] = 0x00; //PCL
            this.RAM[0, 3] = 0x18; //STATUS
            this.RAM[0, 4] = 0x00; //FSR
            this.RAM[0, 5] = 0x00; //PORTA
            this.RAM[0, 6] = 0x00; //PORTB
            this.RAM[0, 8] = 0x00; //EEDATA
            this.RAM[0, 9] = 0x00; //EEADR
            this.RAM[0, 10] = 0x00; //PCLATH
            this.RAM[0, 11] = 0x00; //INTCON
            for (int i = 12; i < 64; i++) this.RAM[0, i] = 0x00; //Variabler shizzle

            this.RAM[1, 1] = 0xFF; //OPTION
            this.RAM[1, 2] = 0x00; //PCL
            this.RAM[1, 3] = 0x18; //STATUS
            this.RAM[1, 4] = 0x00; //FSR
            this.RAM[1, 5] = 0x1F; //TRIS A
            this.RAM[1, 6] = 0xFF; //TRIS B
            this.RAM[1, 8] = 0x00; //EECON
            this.RAM[1, 10] = 0x00; //PCLATH
            this.RAM[1, 11] = 0x00; //INTCON
            
        }

        public void PowerOnReset()
        {
            // Power On Reset des Prozessors
            this.W = 0;
            this.PC = 0;
            this.Stack.Clear();
            this.stackCounter = 0;
            this.internalTimerCounter = 0;
            this.externalTimerCounter = 0;
            this.runTimeCounter = 0;
            this.runTime = 0;
            this.ConfigurationWord = 0;
            this.watchdogTimeout = 0;
            this.watchdogStartTime = 0;

            this.RAM[0, 0] = 0x00; //INDF
            this.RAM[0, 1] = 0x00; //TIMR0
            this.RAM[0, 2] = 0x00; //PCL
            this.RAM[0, 3] = 0x18; //STATUS
            this.RAM[0, 4] = 0x00; //FSR
            this.RAM[0, 5] = 0x00; //PORTA
            this.RAM[0, 6] = 0x00; //PORTB
            this.RAM[0, 8] = 0x00; //EEDATA
            this.RAM[0, 9] = 0x00; //EEADR
            this.RAM[0, 10] = 0x00; //PCLATH
            this.RAM[0, 11] = 0x00; //INTCON
            for (int i = 12; i < 64; i++) this.RAM[0, i] = 0x00; //Variabler shizzle

            this.RAM[1, 1] = 0xFF; //OPTION
            this.RAM[1, 2] = 0x00; //PCL
            this.RAM[1, 3] = 0x18; //STATUS
            this.RAM[1, 4] = 0x00; //FSR
            this.RAM[1, 5] = 0x1F; //TRIS A
            this.RAM[1, 6] = 0xFF; //TRIS B
            this.RAM[1, 8] = 0x00; //EECON
            this.RAM[1, 10] = 0x00; //PCLATH
            this.RAM[1, 11] = 0x00; //INTCON
        }

        public void watchdogReset()
        {
            // Power On Reset des Prozessors
            
            this.PC = 0;
            this.Stack.Clear();
            this.stackCounter = 0;
            this.watchdogTimeout = 0;

            this.RAM[0, 0] = 0x00; //INDF
            
            this.RAM[0, 2] = 0x00; //PCL
            this.RAM[0, 3] = (byte) (0x08 + (this.RAM[0, 3] & 0x07)); //STATUS
            
            this.RAM[0, 10] = 0x00; //PCLATH
            this.RAM[0, 11] = (byte)(this.RAM[0,11] & 0x01); //INTCON
            

            this.RAM[1, 1] = 0xFF; //OPTION
            this.RAM[1, 2] = 0x00; //PCL
            this.RAM[1, 3] = (byte)(0x08 + (this.RAM[1, 3] & 0x07)); //STATUS
            
            this.RAM[1, 5] = 0x1F; //TRIS A
            this.RAM[1, 6] = 0xFF; //TRIS B
            this.RAM[1, 8] = 0x00; //EECON
            this.RAM[1, 10] = 0x00; //PCLATH
            this.RAM[1, 11] = (byte)(this.RAM[1, 11] & 0x01); //INTCON
        }

        public bool watchdog()
        {
            if ((this.ConfigurationWord & 0x0004) == 0x0004) //Watchdogtimer enabled
            {
                if (this.watchdogTimeout == 0) 
                {
                    this.watchdogTimeout = this.runTime + WatchdogPrescaler(); //Falls timeout 0 ist, neuen Timeout setzen;
                    this.watchdogStartTime = this.runTime;                     //Die Startzeit des Watchdog wird gespeichert, falls nachträglich der Prescaler verändert wird
                }

                if (this.runTime >= this.watchdogTimeout)
                {
                    if ((this.RAM[0, 3] & 0x08) == 0x00)    //falls PD gesetzt ist, wird ein Wake up ausgeführt
                    {
                       
                        this.RAM[0, 3] |= 0x08; //PD = 1
                        
                        this.RAM[1, 3] |= 0x08; //PD = 1
                        this.RAM[0, 2]++;
                        this.RAM[1, 2]++;
                        this.PC++;

                        this.watchdogTimeout = 0;
                    }
                    else                                    //Programm Reset
                    {
                        watchdogReset();
                    }
                    return true;
                }
            }
            return false;
        }

        public void newWatchdogTimeOut()
        {
            this.watchdogTimeout = this.watchdogStartTime + WatchdogPrescaler(); //Neue Berechnung des timeout, falls Prescaler aktiviert wird
        }

        public void updateBank(byte bank)
        {
            /* Die Register 2:4 und 0xA:0xB des RAM ist auf beiden Seiten gleich, je nach verwendeter Bank werden die Werte in die jeweils
             * andere Bank des RAM übertragen.
             * zusätlich wird der PC geupdatet.
             */
            if (bank == 0) for (int i = 2; i < 5; i++) this.RAM[1, i] = this.RAM[0, i]; //Schreibe Register 2-4 in Bank0/1
            else { for (int i = 2; i < 5; i++) this.RAM[0, i] = this.RAM[1, i]; }

            if (bank == 0) for (int i = 0x0A; i < 0x0C; i++) this.RAM[1, i] = this.RAM[0, i]; //Schreibe Register 2-4 in Bank0/1
            else { for (int i = 0x0A; i < 0x0C; i++) this.RAM[0, i] = this.RAM[1, i]; }

            //die ersten 5 Bit des PC werden nur über PCLATH geändert, die unteren 8 Bit werden dem PCL entnommen
            this.PC =(UInt16)( (this.PC & 0xFF00) + (this.RAM[0, 2]));
        }

        public void incInternalTimer(byte cycle)
        {
            /* dieser Counter wird nach jedem Befehl aufgerufen. Je nach angegebenem Cyclus wird hier der Counter 
             * entsprechend erhöht.
             * Bei jedem einzelnen erhöhehn des Counters, muss über den Prescaler gelaufen werden, um evtl ein 
             * erhöhen des TIM0 auszulösen, deswegen die for-Schleife
             * Desweiteren wird hier auch die Runtime erhöht, da die Funktion nach jedem Befehl (außer SLEEP) aufgerufen wird.
             */
            for (int i = cycle; i> 0; i--)
            {
                ++this.internalTimerCounter;
                ++this.runTimeCounter;
                if ((this.RAM[1, 1] & 0x20) == 0)  //Internal Clock is used
                {
                    
                   this.TimerPrescaler(internalTimerCounter);
                }
            }

            
            double cycleTime = 1.0 / (this.frequenzy * 1000); //Ausgabe in ms, deswegen *1000
            this.runTime = cycleTime * this.runTimeCounter;
            
        }

        public void incExternalTimer()

        {

            /* Diese Funktion wird aufgerufen, wenn RA4 also Clock Input benutzt wird.
             * der externTimerCoutner wird erhöht und an die Prescaler Funktion übergeben,
             * um evtl TIM0 zu erhöhen
             */
            ++this.externalTimerCounter;
            this.TimerPrescaler(externalTimerCounter);
        }

        public void ZeroBit( int bank)              //changes ZeroBit if W == 0
        {
            /* Wird aufgerufen, wenn ein Befehl W verändert und dabei das Z Bit betroffen ist */
            if (this.W == 0) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x4);// Z
            else this.RAM[bank, 3] = (byte)(this.RAM[0, 3] & 0xFB);
        }

        public void ZeroBit(int bank, UInt16 Befehl)  //changes ZeroBit if Register == 0
        {
            /* Wird aufgerufen, wenn ein Befehl ein Register verändert und dabei das Z Bit betroffen ist */
            if (this.RAM[bank, (Befehl & 0x7F)] == 0) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x4); //Z
            else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFB);
        }

        public void CarryBit(int bank, int value)
        {
            //Wird aufgerufen, wenn das Carry-Bit verändert werden muss
           if (value == 1) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x1);
           else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFE);
        }

        public void DigitCarryBit(int bank, int value)
        {
            //Wird aufgerufen, wenn das DigitCarry-Bit verändert werden muss
            if (value == 1) this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] | 0x2);
            else this.RAM[bank, 3] = (byte)(this.RAM[bank, 3] & 0xFD);
        }

        public void ChangeW(int bank, byte register)  //Changes W
        {
            // Wird aufgerufen, wenn ein Register in W geladen werden soll, dabei wird getRegisterValue verwendet, um FSR zu berücksichtigen
            byte newValue = this.getRegisterValue(bank, register);
            this.W = newValue;
        }

        public void ChangeW(byte newValue)  //Changes W
        {
            // Wird aufgerufen, wenn Literale in W geladen werden
            this.W = newValue;
        }

        public byte getRegisterValue(int bank, byte register)
        {
            /* getRegisterValue gibt den Wert eines Registers zurück. Dabei wird zuerst geprüft, ob das angesprochene Register 
             * das Indirect Adress Register ist oder nicht. Falls ja, wird das auszulesende Register aus dem FSR Register abgefragt.
             * Dabei wird noch einmal überprüft ob im FSR das Indirect Register angesprochen wird, um evtl 00h dabei zurück zu geben
             */
            if (register == 0)      //überprüfe ob INDF angesprochen wird
            {
                byte indAdress = this.RAM[bank, 4];
                if ((byte)(indAdress & 0x7F) == 0) return 0;  //falls indf addressiert wird, return 0x00;
                else
                {
                    if ((byte)(indAdress & 0x80) == 0) return this.RAM[0, (byte)(indAdress & 0x7F)];  //überprüfe Bit 7, welche Bank angesprochen wird
                    else return this.RAM[1, (byte)(indAdress & 0x7F)];
                }
            }
            else return this.RAM[bank, register];
        }

        public void ChangeRegister(int bank, byte register, byte newValue)  //Changes Registers
        {
            // Wird aufgerufen, wenn ein Register verändert werden muss, mit Berücksichtigung auf FSR
            if (register == 0)      //überprüfe ob INDF angesprochen wird
            {
                byte FSRAddress = this.RAM[bank, 4];

                if ((byte)(FSRAddress & 0x7F) == 0) ;  //falls indf addressiert wird, passiert nichts;

                else
                {
                    if ((byte)(FSRAddress & 0x80) == 0) this.RAM[0, (byte)(FSRAddress & 0x7F)] = newValue;  //überprüfe Bit 7, welche Bank angesprochen wird
                    else
                    {
                        if (FSRAddress == 2)            //Abfrage ob PCL verändert wird, falls ja, PC neu zusammensetzen aus PCL und PCLATH
                        {
                            this.RAM[0, 2] = newValue;
                            this.RAM[1, 2] = newValue;
                            this.PC = (UInt16)(newValue + (this.RAM[0, 0xA] << 8));
                        }                       
                        else this.RAM[0, (byte)(FSRAddress & 0x7F)] = newValue;
                        if (((FSRAddress & 0x80) == 0x80) && ((FSRAddress & 0x7F) == 1)) newWatchdogTimeOut(); // falls OPtiON Register verändert wird, wird überprüft, ob ein neue watchdog Time Out gesetzt werden muss
                    }
                }
            }
            else
            {
                if (register == 2)                      //Abfrage ob PCL verändert wird, falls ja, PC neu zusammensetzen aus PCL und PCLATH
                {
                    this.RAM[0, 2] = newValue;
                    this.RAM[1, 2] = newValue;
                    this.PC =(UInt16) (newValue + (this.RAM[0, 0xA] << 8));
                }
                this.RAM[bank, register] = newValue;
                if ((bank == 1) && (register == 1)) newWatchdogTimeOut(); // falls OPtiON Register verändert wird, wird überprüft, ob ein neue watchdog Time Out gesetzt werden muss
            }
        }

        public void interrupt()
        {
            /* Interrupt wird nach jedem Befehl aufgerufen, und überprüft auf verschiedene Interrupts
             * Falls einer der Interrupts ausgelöst wurde, springt der PC auf Adresse 4
             */
            if ((this.RAM[0, 0x0B] & 0x80) == 0x80)         //GIE = 1 -> alle interrupts enabled
            {
                if ((this.RAM[0, 0x0B] & 0x20) == 0x20)     //T0IE = 1 -> Timer Overflow interrupt enabled
                {
                    if ((this.RAM[0, 0x0B] & 0x04) == 0x04) // Timer Overflow ist passiert
                    {
                        this.addStack(this.PC);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.PC = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;           //GIE Disablen
                        return;
                    }                   
                }

                if ((this.RAM[0, 0x0B] & 0x08) == 0x08)     //RB5-7 interrupt enabled
                {
                    if ((this.RAM[0,0x0B] & 0x01)  == 0x01) //RBChange Flag enabled
                    {
                        this.addStack(this.PC);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.PC = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;          //GIE Disablen                      
                        return;
                    }                  
                }

                if ((this.RAM[0, 0x0B] & 0x10) == 0x10)     //RB0 interrupt enabled
                {
                    if ((this.RAM[0,0x0B] &0x02) == 0x02)
                    {
                        this.addStack(this.PC);
                        this.RAM[0, 2] = 0x04;
                        this.RAM[1, 2] = 0x04;
                        this.PC = 0x04;
                        this.RAM[0, 0x0B] &= 0x7F;          //GIE Disablen
                        return;
                    }
                   
                }
            }
        }

        public void TimerPrescaler(uint counter)
        {
            //Bei jedem erhöhen der Counter wird diese Funktion aufgerufen, und es wird überprüft, ob und welcher Prescaler aktiv ist
            if ((this.RAM[1, 1] & 0x08) == 0)   //wenn PSA = 0 ist der Timer-Prescaler aktiv
            {
                // 1:2
                if ((this.RAM[1, 1] & 0x07) == 0)
                {
                    if (counter % 2 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                        return;
                    }
                    return;
                }

                // 1:4
                if ((this.RAM[1, 1] & 0x07) == 1)
                {
                    if (counter % 4 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                 
                        return;
                    }
                    return;

                }

                // 1:8
                if ((this.RAM[1, 1] & 0x07) == 2)
                {
                    if (counter % 8 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                  ;
                        return;
                    }
                    return;

                }

                // 1:16
                if ((this.RAM[1, 1] & 0x07) == 3)
                {
                    if (this.internalTimerCounter % 16 == 0)
                    {
                        this.internalTimerCounter = 0;
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                      
                        return;
                    }
                    return;

                }

                // 1:32
                if ((this.RAM[1, 1] & 0x07) == 4)
                {
                    if (counter % 32 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                      
                        return;
                    }
                    return;

                }

                // 1:64
                if ((this.RAM[1, 1] & 0x07) == 5)
                {
                    if (counter % 64 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                       
                        return;
                    }
                    return;

                }

                // 1:128
                if ((this.RAM[1, 1] & 0x07) == 6)
                {
                    if (counter % 128 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                       
                        return;
                    }
                    return;

                }

                // 1:256
                if ((this.RAM[1, 1] & 0x07) == 7)
                {
                    if (counter % 256 == 0)
                    {
                        ++this.RAM[0, 1];
                        if (this.RAM[0, 1] == 0)
                        {
                            RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                            RAM[0, 0xB] |= 0x04;
                        }
                        
                        return;
                    }
                    return;

                }
                
            }

            else            //falls kein Prescaler aktiv ist 

            {
                ++this.RAM[0, 1]; // wenn kein prescaler aktiv ist, wird der Timer nach jedem Cycle erhöht
                if (this.RAM[0, 1] == 0)
                {
                    RAM[1, 0xB] |= 0x04; //Bei Überlauf T0IF setzen
                    RAM[0, 0xB] |= 0x04;
                }
                
                return;
                
            }
            return;
        }


        public double WatchdogPrescaler()
        {
            
            if ((this.RAM[1, 1] & 0x08) == 0x08)   //wenn PSA = 1 ist der WDT-Prescaler aktiv
            {
                // 1:1
                if ((this.RAM[1, 1] & 0x07) == 0)
                {
                    return 18;
                }

                // 1:2
                if ((this.RAM[1, 1] & 0x07) == 1)
                {                   
                    return 36;
                }

                // 1:4
                if ((this.RAM[1, 1] & 0x07) == 2)
                {
                    
                    return 72;

                }

                // 1:8
                if ((this.RAM[1, 1] & 0x07) == 3)
                {
                    
                    return 144;

                }

                // 1:16
                if ((this.RAM[1, 1] & 0x07) == 4)
                {
                    
                    return 288;

                }

                // 1:32
                if ((this.RAM[1, 1] & 0x07) == 5)
                {
                    
                    return 576;

                }

                // 1:64
                if ((this.RAM[1, 1] & 0x07) == 6)
                {
                    
                    return 1152;

                }

                // 1:128
                if ((this.RAM[1, 1] & 0x07) == 7)
                {
                    
                    return 2304;

                }

            }

            return 18;

        }
    }
}
