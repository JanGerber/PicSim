using PicSimulator.ViewModels;
using System;
namespace PicSimulator.Model {
    internal class BefehlXORWF : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlXORWF(int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "XORWF";

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
            throw new NotImplementedException();
        }
    }
}