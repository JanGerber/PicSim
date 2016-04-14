using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlRETURN : Befehl {

        public BefehlRETURN() {
            befehlsName = "RETURN";
        }
        public override string Parameter1 {
            get {
                return "";
            }
        }

        public override string Parameter2 {
            get {
                return "";
            }
        }


        public override int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}