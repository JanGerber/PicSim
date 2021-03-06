﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
     class BefehlRETLW : BefehlViewModel {
        private int parameter1;


        public BefehlRETLW(int programmCounter, int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "RETLW";
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
            speicher.WRegister = (byte)parameter1; //k --> (W)
            //Status Affected
                //None
            //Gesamt Cycles und TMR0
            speicher.addToCycles(2);
            speicher.addToTimer(2);
            //PCL
            int newProgrammCounter = speicher.popStack();
            speicher.setRegister(2, (byte)(newProgrammCounter));
            return newProgrammCounter; //TOS --> PC
        }
    }
}