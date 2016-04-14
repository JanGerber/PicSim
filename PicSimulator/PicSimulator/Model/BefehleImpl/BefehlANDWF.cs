using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlANDWF : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlANDWF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "ANDWF";
            this.programmCounter = programmCounter;
        }
        public override string Parameter1 {
            get {
                return parameter1.ToString();
            }
        }

        public override string Parameter2 {
            get {
                return parameter2.ToString();
            }
        }
        public override int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}