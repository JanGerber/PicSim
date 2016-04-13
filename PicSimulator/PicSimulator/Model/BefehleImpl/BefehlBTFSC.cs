using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlBTFSC : Befehl {
        private string befehlsName = "BTFSC";
        private int parameter1;
        private int parameter2;
        private bool breakpoint;

        public BefehlBTFSC(int parameter1, int parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
        }
        public string BefehlsName {
            get {
                return befehlsName;
            }
        }
        public string Parameter1 {
            get {
                return parameter1.ToString();
            }
        }

        public string Parameter2 {
            get {
                return parameter2.ToString();
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