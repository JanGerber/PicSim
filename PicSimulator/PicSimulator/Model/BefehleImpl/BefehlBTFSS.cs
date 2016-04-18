using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlBTFSS : BefehlViewModel {
        private int parameter1;
        private int parameter2;

        public BefehlBTFSS(int programmCounter, int parameter1, int parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "BTFSS";
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
            if(speicher.getRegister(parameter1,parameter2)){
                addToProgrammCounter = 2;
            }else {
                speicher.addToCycles(1);
                addToProgrammCounter = 1;
            }
            //Status Affected
                //None
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + addToProgrammCounter));
            return programmCounter + addToProgrammCounter;
        }
    }
}