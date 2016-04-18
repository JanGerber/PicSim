using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSUBLW : Befehl {
        private int parameter1;

        public BefehlSUBLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "SUBLW";
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
            int result = parameter1 - speicher.WRegister;
            speicher.WRegister = (byte)result;
            //Status Affected: C, DC, Z
                //TODO DC
                if(((result >> 8) & 1) == 1) {
                    speicher.setCarryBit(true);
                } else {
                    speicher.setCarryBit(false);
                }
                if (speicher.WRegister == 0) {
                    speicher.setZeroBit(true);
                } else {
                    speicher.setZeroBit(false);
                }
            //Cycles
            speicher.addToCycles(1);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            return 1 + programmCounter;
        }
    }
}