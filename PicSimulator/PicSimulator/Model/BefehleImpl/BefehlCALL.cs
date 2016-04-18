using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlCALL : Befehl {
        private int parameter1;

        public BefehlCALL(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "CALL";
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
            speicher.pushStack(programmCounter + 1);
            int newProgrammCounter =  (parameter1 & 0x7FF) + ((speicher.getRegister(10) & 18) >> 3); //k -> PC < 10:0 > ; (PCLATH < 4:3 >) -> PC < 12:11 >
            //Status Affected;
                //None
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);
            //PCL
            speicher.setRegister(2, (byte)(newProgrammCounter));
            return newProgrammCounter; 
                }
    }
}