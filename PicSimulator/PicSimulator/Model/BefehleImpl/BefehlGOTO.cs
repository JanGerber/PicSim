﻿using System;

namespace PicSimulator.Model {
    class BefehlGOTO : Befehl {
        private string befehlsName = "GOTO";
        private int parameter1;

        public BefehlGOTO(int parameter1) {
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
        public int ausfuehren() {
            throw new NotImplementedException();
        }
    }
}