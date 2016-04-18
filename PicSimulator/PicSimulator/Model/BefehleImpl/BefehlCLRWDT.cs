using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
     class BefehlCLRWDT : Befehl {

        public BefehlCLRWDT(int programmCounter) {
            befehlsName = "CLRWDT";
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
            //TODO //00h --> WDT
            //TODO  //0 --> WDT prescaler
         

            //Status Affected TO PD
                speicher.setRegister(3, 4, true);    //1 --> TO
                speicher.setRegister(3, 3, true);    //1--> PD
            //Cycles
                speicher.addToCycles(1);
            //PCL
                speicher.setRegister(2, (byte)(programmCounter + 1));
            return programmCounter + 1;
        }
    }
}