﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    internal class BefehlSWAPF : BefehlViewModel {
        private int parameter1;
        private bool parameter2;

        public BefehlSWAPF(int programmCounter, int parameter1, bool parameter2) {
            this.parameter1 = parameter1;
            this.parameter2 = parameter2;
            befehlsName = "SWAPF";
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
            int result = ((speicher.getRegister(getParameter(speicher, parameter1)) & 0x0F)<< 4) + ((speicher.getRegister(getParameter(speicher, parameter1)) & 0xF0) >> 4 );
            if(parameter2) { // if parameter2 is true than store the result in the register
                speicher.setRegister(getParameter(speicher, parameter1), (byte)(result));
            } else { //otherwise in the W-Register
                speicher.WRegister = (byte)(result);
            }
            //Status Affected:
                //None
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);
     
            return programmCounter + 1;
        }
    }
}