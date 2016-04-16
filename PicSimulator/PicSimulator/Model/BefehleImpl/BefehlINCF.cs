using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlINCF : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlINCF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "INCF";
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
            bool isStoredW;
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(parameter1, (byte)(speicher.getRegister(parameter1)+1));
                isStoredW = false;
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(speicher.getRegister(parameter1) + 1);
                isStoredW = true;
            }
            //Status Affected: Z
                if(isStoredW) {
                    if(speicher.WRegister == 0) { speicher.setZeroBit(true); }
                } else {
                    if(speicher.getRegister(parameter1) == 0) { speicher.setZeroBit(true); }
                 }
            //Cycles
            speicher.addToCycles(1);
            return programmCounter + 1;
        }
    }
}