using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlINCFSZ : Befehl {
        private int parameter1;
        private bool parameter2;

        public BefehlINCFSZ(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "INCFSZ";
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
            //Cycles TODO manchmal 2
            speicher.addToCycles(1);
            throw new NotImplementedException();

        }
    }
}