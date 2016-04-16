using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlNOP : Befehl {

        public BefehlNOP(int programmCounter) {
            befehlsName = "NOP";
            this.programmCounter = programmCounter;
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
            //Cycles
            speicher.addToCycles(1);
            throw new NotImplementedException();
        }
    }
}