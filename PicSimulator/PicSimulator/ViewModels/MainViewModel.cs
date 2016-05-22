using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Forms; //TEST
using PicSimulator.Model;
using System.Windows.Controls;
using System.Windows.Documents;
using PicSimulator.ViewModel;
using System.Windows.Media;
using System.ComponentModel;

namespace PicSimulator.ViewModels {
    class MainViewModel : Caliburn.Micro.Screen {
        #region fields
        private string _openFileContent;
        private string _fileNameContent;
        private string _Dateiname;
        private Dictionary<int, BefehlViewModel> _opcodesObj; //in int wird die Zeilennummer gespeichert, Befehl ist  ein Objekt
        private Speicher speicher;
        private int programmCounter;
        private bool stopProgramm;
        private string filename;
        BackgroundWorker prgWorker = new BackgroundWorker();
        bool resetProgramm;



        #endregion //fields

        #region properties
        public string OpenFileContent {
            get {
                return _openFileContent;
            }

            set {
                _openFileContent = value;
                NotifyOfPropertyChange(() => OpenFileContent);
            }
        }

        public string FileNameContent {
            get {
                return _fileNameContent;
            }

            set {
                _fileNameContent = value;
                NotifyOfPropertyChange(() => FileNameContent);


            }
        }

        public Dictionary<int, BefehlViewModel> OpcodesObj {
            get {
                return _opcodesObj;
            }

            set {
                _opcodesObj = value;
                NotifyOfPropertyChange(() => OpcodesObj);
            }
        }

        public string Dateiname     //function für Zugriff auf die Texteigenschaft des Textblock-Elements der Oberfläche
        {
            get {
                return _Dateiname;
            }

            set {
                _Dateiname = value;
                NotifyOfPropertyChange(() => Dateiname);
            }
        }

        public int ProgrammCounter {
            get {
               // int pch = speicher.getRegister(0x0A) << 8;

                return ((programmCounter & 0xFF00) + speicher.getRegister(2)); /* pch + speicher.getRegister(2);*/
            }

            set {
                programmCounter = value;
                foreach (KeyValuePair<int, BefehlViewModel> befehl in OpcodesObj) {
                    if (befehl.Value.ProgrammCounter == ProgrammCounter) {
                        befehl.Value.Background = Brushes.LightGray;
                    } else {
                        befehl.Value.Background = Brushes.White;
                    }
                }
              //  Speicher.setRegister(2, (byte)value); //set PCL
                int newPCLath = (int)Speicher.getRegister(0x0A) >> 8;
                newPCLath = newPCLath & 0x1F; //
                Speicher.setRegister(0x0A, (byte)newPCLath); //set PCH
                NotifyOfPropertyChange(() => ProgrammCounter);
            }
        }

        public Speicher Speicher {
            get {
                return speicher;
            }

            set {
                speicher = value;
                NotifyOfPropertyChange(() => Speicher);
            }
        }

        #endregion //properties

        #region constructor
        public MainViewModel() {
            OpenFileContent = "Datei öffnen";
            prgWorker.DoWork += worker_StartProgrammThread;
            prgWorker.RunWorkerCompleted += worker_StartProgrammrCompleted;
            prgWorker.WorkerReportsProgress = true;
            prgWorker.WorkerSupportsCancellation = true;
            Speicher = new Speicher();
            resetProgramm = false;
        }

        #endregion //constructur

        #region methods
        public void OpenFile() {        //Wird beim Drücken des Buttons "Datei öffnen" ausgeführt
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "LST Files (*.lst)|*.lst";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                // Open document 
                filename = dlg.FileName;
                ProgrammModel programModel = new ProgrammModel(filename); //Dictionary mit Befehlen anlegen
                Befehlsumwandler wandler = new Befehlsumwandler(programModel.Opcodes);
                OpcodesObj = wandler.OpcodesObj;    //Opcodes in Befehle umwandeln
                Dateiname = filename;
                foreach (KeyValuePair<int, BefehlViewModel> befehl in wandler.OpcodesObj) {    //Ausgabe der Befehle und Operatoren auf der Konsole
                    System.Console.WriteLine(befehl.Value.BefehlsName + " " + befehl.Value.Parameter1 + " " + befehl.Value.Parameter2);
                }
                Speicher = new Speicher();
            } else {
                //TODO Fehler
            }

        }
        public void StartProgramm() {   //Wird beim Klicken des Buttons Start aufgerufen
            stopProgramm = false;
            if (_opcodesObj != null) {
                if (Speicher == null) {
                    Speicher = new Speicher();
                }
                if (!prgWorker.IsBusy) {
                    prgWorker.RunWorkerAsync();
                }
            }
        }
        public void StopProgramm() {    //Wird beim Klicken des Buttons Stop aufgerufen
            Console.WriteLine("Stopbutton gedrueckt");
            stopProgramm = true;
        }
        public void ResetProgramm() {   //Wird beim Klicken des Buttons Zurücksetzen aufgerufen
            resetProgramm = true;
            Speicher = new Speicher();
            ProgrammCounter = 0;
        }
        public void StepProgramm() {    //Wird beim Klicken des Buttons Schritt Vorwärts aufgerufen
            Console.WriteLine("Schritt-V-button gedrueckt");
            if (_opcodesObj != null) {
                if (Speicher == null) {
                    Speicher = new Speicher();
                }
                oneStepPrg();
            }
        }
        private void worker_StartProgrammThread(object sender, DoWorkEventArgs e) {
            System.Console.WriteLine("StartProgrammThread");
            while (!resetProgramm && !stopProgramm && !_opcodesObj.ElementAt(ProgrammCounter).Value.Breakpoint) { //überprüfung ob in der Zeile Breakpoint gestzt oder Programm Stop
                oneStepPrg();
            }
        }
        private void worker_StartProgrammrCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (resetProgramm) {
                System.Console.WriteLine("worker_StartProgrammrCompleted -- RESET");
                Speicher = new Speicher();
                resetProgramm = false;
                ProgrammCounter = 0;
                foreach (KeyValuePair<int, BefehlViewModel> befehl in OpcodesObj) { //Workaround aktueller ProgrammCounter anpassung der Hintergrundfarbe
                    if (befehl.Value.ProgrammCounter == ProgrammCounter) {
                        befehl.Value.Background = Brushes.LightGray;
                    } else {
                        befehl.Value.Background = Brushes.White;
                    }
                }
                NotifyOfPropertyChange(() => ProgrammCounter);
            }

        }
        public void OpenHelp() {   //Wird beim Klicken des Buttons Help aufgerufen
            //Convert The resource Data into Byte[]
            byte[] PDF = Properties.Resources.hilfePic;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(PDF);
            //Create PDF File From Binary of resources folders help.pdf
            System.IO.FileStream f = new System.IO.FileStream("help.pdf", System.IO.FileMode.OpenOrCreate);
            //Write Bytes into Our Created help.pdf
            ms.WriteTo(f);
            f.Close();
            ms.Close();
            // Finally Show the Created PDF from resources
            System.Diagnostics.Process.Start("help.pdf");
        }
        private void oneStepPrg() {
            if(!speicher.Wdt.Sleep) { //Ist momentan 
                if(!speicher.Wdt.WdtNormalTimeout) {
                    if(speicher.Interrupt) {
                        speicher.Interrupt = false;
                        speicher.pushStack(ProgrammCounter + 1);
                        Speicher.setRegister(2, 4); //set PCL
                        Speicher.setRegister(0x0A, 0); //set PCH
                        ProgrammCounter = 4;
                    }
                    ProgrammCounter = _opcodesObj.ElementAt(ProgrammCounter).Value.ausfuehren(ref speicher);
                } else {
                    speicher.Wdt.wdtResetNormal();
                    speicher.Wdt.WdtNormalTimeout = false;
                    ProgrammCounter = 0;
                }
            } else { 
                speicher.Cycles += 1;
                speicher.Wdt.addToWDT();
            }
        }
        #endregion //methods
    }
}
