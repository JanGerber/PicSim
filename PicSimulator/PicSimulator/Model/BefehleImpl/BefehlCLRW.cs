using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlCLRW : Befehl {

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
            throw new NotImplementedException();
        }
    }
}