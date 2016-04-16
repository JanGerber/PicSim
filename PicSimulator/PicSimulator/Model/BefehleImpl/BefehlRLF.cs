using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlRLF : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlRLF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "RLF";
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
            bool carry;
            int result = ((int)speicher.getRegister(parameter1)) << 1;
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(parameter1, (byte)(result));
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(result);
            }
            //Status Affected: C
            result = 1 & (result >> 8);
            if(result == 1) {
                carry = true;
            } else {
                carry = false;
            }
            speicher.setRegister(3, 0, carry); //Status Register Carry Bit
            //Cycles
            speicher.addToCycles(1);
            return programmCounter + 1;
        }
    }
}