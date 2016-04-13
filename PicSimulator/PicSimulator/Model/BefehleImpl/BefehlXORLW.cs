using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlXORLW : Befehl {
        private string befehlsName = "XORLW";
        private int parameter1;

        public BefehlXORLW(int parameter1) {
            this.parameter1 = parameter1;
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
                return "";
            }
        }
        public int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}