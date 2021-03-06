﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlIORWF : BefehlViewModel {
        private int parameter1;
        private bool parameter2;

        public BefehlIORWF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "IORWF";
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
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            //
            bool isStoredW;
            if (parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(getParameter(speicher, parameter1), (byte)(speicher.WRegister | speicher.getRegister(getParameter(speicher, parameter1))));
                isStoredW = false;
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(speicher.WRegister | speicher.getRegister(getParameter(speicher, parameter1)));
                isStoredW = true;
            }
            //Status Affected: Z
            if (isStoredW) {
                if (speicher.WRegister == 0) {
                    speicher.setZeroBit(true);
                } else {
                    speicher.setZeroBit(false);
                }
            } else {
                if (speicher.getRegister(getParameter(speicher, parameter1)) == 0) {
                    speicher.setZeroBit(true);
                } else {
                    speicher.setZeroBit(false);
                }
            }
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);

            return programmCounter + 1;
        }
    }
}