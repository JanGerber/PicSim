﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlBCF : BefehlViewModel {
        private int parameter1;
        private int parameter2;

        public BefehlBCF(int programmCounter, int parameter1, int parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "BCF";
            this.programmCounter = programmCounter;
        }
        public override string Parameter1 {
            get {
                return parameter1.ToString();
            }
        }

        public override  string Parameter2 {
            get {
                return parameter2.ToString();
            }
        }
        public override int ausfuehren(ref Speicher speicher) {
            //PCL
            speicher.setRegister(2, (byte)(programmCounter + 1));
            //
            speicher.setRegister(getParameter(speicher, parameter1), parameter2, false); //Bit parameter1 in register parameter2 is cleared
            //Status Affected
                //none
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);          
            return programmCounter + 1;
        }
    }
}