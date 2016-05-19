using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlRLF : BefehlViewModel {
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
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            //
            int result = ((int)speicher.getRegister(getParameter(speicher, parameter1))) << 1;
            if (speicher.getRegister(3, 0)) {
                result++;
            }
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(getParameter(speicher, parameter1), (byte)(result));
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(result);
            }
            //Status Affected: C
            result = 1 & (result >> 8);
            if(result == 1) {
                speicher.setCarryBit(true);
            } else {
                speicher.setCarryBit(false);
            }
            //Gesamt Cycles und TMR0
                speicher.addToCycles(1);
                speicher.addToTimer(1);
           
            return programmCounter + 1;
        }
    }
}