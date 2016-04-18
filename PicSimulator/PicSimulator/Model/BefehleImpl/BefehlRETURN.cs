using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlRETURN : Befehl {

        public BefehlRETURN(int programmCounter) {
            befehlsName = "RETURN";
            this.programmCounter = programmCounter;
        }
        public override string Parameter1 {
            get {
                return "";
            }
        }

        public override string Parameter2 {
            get {
                return "";
            }
        }


        public override int ausfuehren(ref Speicher speicher) {
            //Status Affected
                //None
            //Cycles
            speicher.addToCycles(2);
            //PCL
            int newProgrammCounter = speicher.popStack();
            speicher.setRegister(2, (byte)(newProgrammCounter));
            return newProgrammCounter; //TOS --> PC
        }
    }
}