using System;

namespace PicSimulator.Model {
    internal class BefehlRETFIE : Befehl {
        private string befehlsName = "RETFIE";

        public BefehlRETFIE() {

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