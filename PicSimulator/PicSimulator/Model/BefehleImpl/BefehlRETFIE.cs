using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlRETFIE : Befehl {

        public BefehlRETFIE(int programmCounter) {
            befehlsName = "RETFIE";
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
            speicher.setRegister(11, 7, true); // 1 -> GIE
            //Status Affected 
                //None
            //Cycles
            speicher.addToCycles(2);
            return speicher.popStack(); //TOS --> PC
        }
    }
}