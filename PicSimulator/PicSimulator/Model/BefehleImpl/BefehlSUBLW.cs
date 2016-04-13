using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSUBLW : Befehl {
        private string befehlsName = "SUBLW";
        private int parameter1;
        private bool breakpoint;

        public BefehlSUBLW(int parameter1) {
            this.parameter1 = parameter1;
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