using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSUBLW : Befehl {
        private int parameter1;

        public BefehlSUBLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "SUBLW";
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
            speicher.WRegister = (byte)((byte)parameter1 - speicher.WRegister); 
            return ++programmCounter;
        }
    }
}