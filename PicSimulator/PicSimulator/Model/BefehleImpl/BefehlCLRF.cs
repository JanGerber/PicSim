using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlCLRF : Befehl {
        private string befehlsName = "CLRF";
        private int parameter1;
        private bool breakpoint;

        public BefehlCLRF(int parameter1) {
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