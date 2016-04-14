﻿using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlIORLW : Befehl {
        private int parameter1;

        public BefehlIORLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "IORLW";
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
            speicher.WRegister = (byte)(speicher.WRegister | (byte) parameter1);
            return ++programmCounter;
        }
    }
}