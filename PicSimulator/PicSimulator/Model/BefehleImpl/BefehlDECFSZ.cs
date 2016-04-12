﻿using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlDECFSZ : Befehl {
        private string befehlsName = "DECFSZ";
        private int parameter1;
        private bool parameter2;

        public BefehlDECFSZ(int parameter1, bool parameter2) {
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
        public int ausfuehren(ref Speicher speicher) {
            throw new NotImplementedException();
        }
    }
}