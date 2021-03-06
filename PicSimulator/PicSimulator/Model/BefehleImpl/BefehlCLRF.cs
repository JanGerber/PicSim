﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlCLRF : BefehlViewModel {
        private int parameter1;

        public BefehlCLRF(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "CLRF";
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
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            //
            speicher.setRegister(getParameter(speicher, parameter1), 0);
            //Status Affected Z
            speicher.setZeroBit(true);
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);
            
            return programmCounter + 1;
        }
    }
}