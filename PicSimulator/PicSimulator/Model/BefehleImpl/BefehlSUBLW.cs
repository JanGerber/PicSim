﻿using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlSUBLW : Befehl {
        private int parameter1;

        public BefehlSUBLW(int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "SUBLW";
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
            throw new NotImplementedException();
        }
    }
}