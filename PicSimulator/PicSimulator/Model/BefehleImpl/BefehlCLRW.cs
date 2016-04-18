using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlCLRW : BefehlViewModel {

        public BefehlCLRW(int programmCounter) {
            befehlsName = "CLRW";
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
            speicher.WRegister = 0;
            //Status Affected: Z
            speicher.setZeroBit(true);
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            return programmCounter + 1;
        }
    }
}