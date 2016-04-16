using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlSWAPF : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlSWAPF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "SWAPF";
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
            int result = (speicher.getRegister(parameter1) & 0x0F) + (speicher.getRegister(parameter1) & 0xF0);
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(parameter1, (byte)(result));
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(result);
            }
            //Status Affected:
                //None
            //Cycles
            speicher.addToCycles(1);
            return programmCounter + 1;
        }
    }
}