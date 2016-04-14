using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlCALL : Befehl {
        private int parameter1;

        public BefehlCALL(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "CALL";
            this.programmCounter = programmCounter;
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