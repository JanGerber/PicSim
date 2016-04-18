using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlANDLW : Befehl {
        private int parameter1;

        public BefehlANDLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "ANDLW";
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
            speicher.WRegister = (byte) (speicher.WRegister & (byte) parameter1 );
            //Status Affected: Z
            if (speicher.WRegister == 0) {
                speicher.setZeroBit(true);
            } else {
                speicher.setZeroBit(false);
            }
            //Cycles
            speicher.addToCycles(1);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            //Timer
            speicher.addToTimer(1);
            return 1 + programmCounter;
        }
    }
}