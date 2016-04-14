using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlMOVLW : Befehl {
        private int parameter1;

        public BefehlMOVLW(int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "MOVLW";
        }

        public override string Parameter1 {
            get {
                return parameter1.ToString();
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