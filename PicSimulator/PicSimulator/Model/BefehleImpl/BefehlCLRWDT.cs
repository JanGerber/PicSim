using System;

namespace PicSimulator.Model {
     class BefehlCLRWDT : Befehl {
        private string befehlsName = "CLRWDT";

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
        public int ausfuehren() {
            throw new NotImplementedException();
        }
    }
}