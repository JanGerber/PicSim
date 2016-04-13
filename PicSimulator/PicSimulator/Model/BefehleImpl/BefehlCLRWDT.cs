using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
     class BefehlCLRWDT : Befehl {
        private string befehlsName = "CLRWDT";
        private bool breakpoint;

        public BefehlCLRWDT() {

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