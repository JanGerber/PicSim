using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Forms;
using PicSimulator.Model;
using System.Windows.Controls;
using System.Windows.Documents;
using PicSimulator.ViewModel;
using System.Windows.Media;

namespace PicSimulator.ViewModels {
    class MainViewModel : Caliburn.Micro.Screen {
        #region fields
        private string _openFileContent;
        private string _fileNameContent;
        private string _Dateiname;
        private Dictionary<int, BefehlViewModel> _opcodesObj; //in int wird die Zeilennummer gespeichert, Befehl ist ein Objekt
        private Speicher speicher;
        private int programmCounter;
        private bool stopProgramm;
        private string filename;
        


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
            get
            {
                return _Dateiname;
            }

            set
            {
                _Dateiname = value;
                NotifyOfPropertyChange(() => Dateiname);
            }
        }

        public int ProgrammCounter {
            get {
                return programmCounter;
            }

            set {
                System.Console.WriteLine("setProgrammCounter");
                foreach (KeyValuePair<int, BefehlViewModel> befehl in OpcodesObj) {
                    if (befehl.Value.ProgrammCounter == ProgrammCounter) {
                        befehl.Value.Background = Brushes.LightGray;
                    } else {
                        befehl.Value.Background = Brushes.White;
                    }
                }
                programmCounter = value;
                NotifyOfPropertyChange(() => ProgrammCounter);
            }
        }

        #endregion //properties

        #region constructor
        public MainViewModel() {
            OpenFileContent = "Datei öffnen";
        }
        #endregion //constructur

        #region methods
        public void OpenFile() {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "LST Files (*.lst)|*.lst";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                // Open document 
                filename = dlg.FileName;
                ProgrammModel programModel = new ProgrammModel(filename);
                Befehlsumwandler wandler = new Befehlsumwandler(programModel.Opcodes);
                OpcodesObj = wandler.OpcodesObj;
                Ausgabe();
                foreach (KeyValuePair<int,BefehlViewModel> befehl in wandler.OpcodesObj) {    //Ausgabe der Befehle und Operatoren auf der Konsole
                    System.Console.WriteLine(befehl.Value.BefehlsName + " " + befehl.Value.Parameter1 +" " + befehl.Value.Parameter2);
                }
            } else {
                //TODO Fehler
            }
            
        }
        public void StartProgramm() {
            Console.WriteLine("Startbutton gedrueckt");
            System.Threading.Thread newThread = new System.Threading.Thread(StartProgrammThread);
            newThread.Start();
        }
        public void StopProgramm() {
            Console.WriteLine("Stopbutton gedrueckt");
            stopProgramm = true;
        }
        public void ResetProgramm() {
            Console.WriteLine("Resetbutton gedrueckt");
            stopProgramm = true;
            ProgrammCounter = 0;
            speicher = new Speicher();
        }
        public void StepProgramm() {
            Console.WriteLine("Schritt-V-button gedrueckt");
            if (_opcodesObj != null) {
                if (speicher == null) {
                    speicher = new Speicher();
                }
                System.Console.WriteLine(ProgrammCounter + " " + _opcodesObj.ElementAt(ProgrammCounter).Value.BefehlsName + " " + _opcodesObj.ElementAt(ProgrammCounter).Value.Parameter1 + " | " + speicher.WRegister);
                ProgrammCounter = _opcodesObj.ElementAt(ProgrammCounter).Value.ausfuehren(ref speicher);  
            }
        }
        public void StartProgrammThread() {
            stopProgramm = false;
            if (_opcodesObj != null) {
                if (speicher == null) {
                    speicher = new Speicher();
                }
                while (!stopProgramm && !_opcodesObj.ElementAt(ProgrammCounter).Value.Breakpoint) { //überprüfung ob in der Zeile Breakpoint gestzt oder Programm Stop
                    System.Console.WriteLine(ProgrammCounter + " " + _opcodesObj.ElementAt(ProgrammCounter).Value.BefehlsName + " " + _opcodesObj.ElementAt(ProgrammCounter).Value.Parameter1 + " | " + speicher.WRegister);
                    ProgrammCounter = _opcodesObj.ElementAt(ProgrammCounter).Value.ausfuehren(ref speicher);
                }
            }
            
        }

        public void Ausgabe() {
            Dateiname = filename; 
        }
        #endregion //methods
    }
}
