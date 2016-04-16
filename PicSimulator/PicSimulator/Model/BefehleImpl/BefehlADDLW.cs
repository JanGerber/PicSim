using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlADDLW : Befehl {
        private int parameter1;

        public BefehlADDLW(int programmCounter,int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "ADDLW";
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
            speicher.WRegister += (byte)parameter1;
            //Status Affected C, DC, Z
            if (speicher.WRegister == 0) {
                speicher.setZeroBit(true);
            } else {
                speicher.setZeroBit(false);
            }
            //Cycles
            speicher.addToCycles(1);
            return programmCounter + 1 ;
        }
    }
}