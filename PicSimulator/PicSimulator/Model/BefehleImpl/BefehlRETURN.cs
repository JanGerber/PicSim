using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlRETURN : Befehl {
        private string befehlsName = "RETURN";

        public BefehlRETURN() {

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
        public int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}