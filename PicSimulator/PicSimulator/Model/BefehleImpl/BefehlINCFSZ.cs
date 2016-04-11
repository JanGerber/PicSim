using System;

namespace PicSimulator.Model {
    internal class BefehlINCFSZ : Befehl {
        private string befehlsName = "INCFSZ";
        private int parameter1;
        private bool parameter2;

        public BefehlINCFSZ(int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
        }
        public string BefehlsName {
            get {
                return befehlsName;
            }
        }
        public string Parameter1 {
            get {
                return parameter1.ToString();
            }
        }

        public string Parameter2 {
            get {
                return parameter2.ToString();
            }
        }
        public int ausfuehren() {
            throw new NotImplementedException();
        }
    }
}