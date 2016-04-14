using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlNOP : Befehl {

        public BefehlNOP() {
            befehlsName = "NOP";
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