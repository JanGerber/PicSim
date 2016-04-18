using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlINCFSZ : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlINCFSZ(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "INCFSZ";
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
            int addToProgrammCounter = 1;
            bool isStoredW;
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(parameter1, (byte)(speicher.getRegister(parameter1) + 1));
                isStoredW = false;
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(speicher.getRegister(parameter1) + 1);
                isStoredW = true;
            }
            if(isStoredW) {
                if(speicher.WRegister == 0) {
                    addToProgrammCounter = 2;
                    speicher.addToCycles(1);
                }
            } else {
                if(speicher.getRegister(parameter1) == 0) {
                    addToProgrammCounter = 2;
                    speicher.addToCycles(1);
                }
            }
            //Status Affected 
                //None
            //Cycles
            speicher.addToCycles(1);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            return programmCounter + addToProgrammCounter;

        }
    }
}