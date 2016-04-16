using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
     class BefehlCLRWDT : Befehl {

        public BefehlCLRWDT(int programmCounter) {
            befehlsName = "CLRWDT";
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