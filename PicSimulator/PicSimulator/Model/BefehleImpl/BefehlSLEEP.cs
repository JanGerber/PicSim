using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSLEEP : BefehlViewModel {

        public BefehlSLEEP(int programmCounter) {
            befehlsName = "SLEEP";
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

            //Status effekted
            speicher.setRegister(3,4,true);//TO (Time-Out Bit)setzen
            speicher.setRegister(3, 3, false); //Power down bit clearen
            speicher.Wdt.Sleep = true;
            //Timer
            speicher.addToTimer(1);
            //Cycles
            speicher.addToCycles(1);
            return ProgrammCounter + 1;
        }
    }
}