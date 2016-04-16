using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
     class BefehlRETLW : Befehl {
        private int parameter1;


        public BefehlRETLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "RETLW";
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
            speicher.WRegister = (byte)parameter1; //k --> (W)
            //Status Affected
                //None
            //Cycles
            speicher.addToCycles(2);
            return speicher.popStack(); //TOS --> PC
        }
    }
}