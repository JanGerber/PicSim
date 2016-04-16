using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlBTFSC : Befehl {
        private int parameter1;
        private int parameter2;

        public BefehlBTFSC(int programmCounter, int parameter1, int parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "BTFSC";
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
            int addToProgrammCounter;
            if(speicher.getRegister(parameter1, parameter2)) {
                speicher.addToCycles(1);
                addToProgrammCounter = 1;
            } else { 
                addToProgrammCounter = 2;
            }
            //Status Affected
                //None
            //Cycles 
            speicher.addToCycles(1);
            return programmCounter + addToProgrammCounter;
        }
    }
}