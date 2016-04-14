using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows.Forms;
using PicSimulator.Model;

namespace PicSimulator.ViewModels {
    class MainViewModel : Caliburn.Micro.Screen {
        #region fields
        private string _openFileContent;
        private string _fileNameContent;
        private Dictionary<int, Befehl> _opcodesObj; //in int wird die Zeilennummer gespeichert, Befehl ist ein Objekt
        private Speicher speicher;
        private int programmCounter;
        private bool stopProgramm;


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

        public Dictionary<int, Befehl> OpcodesObj {
            get {
                return _opcodesObj;
            }

            set {
                _opcodesObj = value;
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


            // Get the selected file name and display in a TextBox 
            if (result == true) {
                // Open document 
                string filename = dlg.FileName;
                ProgrammModel programModel = new ProgrammModel(filename);
                Befehlsumwandler wandler = new Befehlsumwandler(programModel.Opcodes);
                OpcodesObj = wandler.OpcodesObj;
                foreach(KeyValuePair<int,Befehl> befehl in wandler.OpcodesObj) {
                    System.Console.WriteLine(befehl.Value.BefehlsName + " " + befehl.Value.Parameter1 +" " + befehl.Value.Parameter2);
                }
            } else {
                //TODO Fehler
            }
            

        }
        public void StartProgramm() {
            stopProgramm = false;
            if(_opcodesObj != null) {
                if(speicher == null) {
                    speicher = new Speicher();
                }
                while (!stopProgramm && _opcodesObj.ElementAt(programmCounter).Value.Breakpoint) { //überprüfung ob in der Zeile Breakpoint gestzt oder Programm Stop
                    programmCounter = _opcodesObj.ElementAt(programmCounter).Value.ausfuehren(ref speicher);
                }
            } 
        }
        public void StopProgramm() {
            stopProgramm = true;
        }
        public void ResetProgramm() {
            stopProgramm = true;
            programmCounter = 0;
            speicher = new Speicher();
        }
        public void StepProgramm() {
            if (_opcodesObj != null) {
                if (speicher == null) {
                    speicher = new Speicher();
                }
                    programmCounter = _opcodesObj.ElementAt(programmCounter).Value.ausfuehren(ref speicher);  
            }
        }
        #endregion //methods


    }
}
