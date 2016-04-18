using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlDECFSZ : BefehlViewModel {
        private int parameter1;
        private bool parameter2;

        public BefehlDECFSZ(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "DECFSZ";
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
            int cycles = 0;
            bool isStoredW;
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(parameter1, (byte)(speicher.getRegister(parameter1)-1));
                isStoredW = false ;
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(speicher.getRegister(parameter1)-1);
                isStoredW = true;
            }
            if(isStoredW) {
                if(speicher.WRegister == 0) {
                    addToProgrammCounter = 2;
                    cycles = 1;
                }
            }else {
                if(speicher.getRegister(parameter1) == 0) {
                    addToProgrammCounter = 2;
                    cycles = 1;
                }
            }
            //Status Affected
            //None
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1 + cycles);
            speicher.addToTimer(1 + cycles);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + addToProgrammCounter));
            return programmCounter + addToProgrammCounter;
        }
    }
}