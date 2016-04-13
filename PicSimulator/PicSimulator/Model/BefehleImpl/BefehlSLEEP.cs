using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSLEEP : Befehl {
        private string befehlsName = "SLEEP";
        private bool breakpoint;

        public BefehlSLEEP() {

        }

        public string BefehlsName {
            get {
                return befehlsName;
            }
        }
        public string Parameter1 {
            get {
                return "";
            }
        }

        public string Parameter2 {
            get {
                return "";
            }
        }
        public bool Breakpoint {
            get {
                return breakpoint;
            }

            set {
                this.breakpoint = value;
            }
        }
        public int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}