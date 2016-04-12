using System;

namespace PicSimulator.Model {
    class BefehlBCF : Befehl {
        private string befehlsName = "BCF";
        private int parameter1;
        private int parameter2;

        public BefehlBCF(int parameter1, int parameter2) {
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