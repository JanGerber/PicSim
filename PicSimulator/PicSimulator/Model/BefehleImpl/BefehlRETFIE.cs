﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlRETFIE : BefehlViewModel {

        public BefehlRETFIE(int programmCounter) {
            befehlsName = "RETFIE";
            this.programmCounter = programmCounter;
        }

        public override string Parameter1 {
            get {
                return "";
            }
        }

        public override string Parameter2 {
            get {
                return "";
            }
        }

        public override int ausfuehren(ref Speicher speicher) {
            speicher.setRegister(11, 7, true); // 1 -> GIE
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