﻿using PicSimulator.ViewModel;
using PicSimulator.ViewModels;
using System;

namespace PicSimulator.Model {
    class BefehlADDLW : BefehlViewModel {
        private int parameter1;

        public BefehlADDLW(int programmCounter,int parameter1) {
            this.parameter1 = parameter1;
            befehlsName = "ADDLW";
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
            int result = speicher.WRegister + parameter1;
            speicher.WRegister = (byte)result;
            //Status Affected C, DC, Z
                if((speicher.WRegister & 0x0F) + (parameter1 & 0x0F) > 15) {
                    speicher.setDigitCarryBit(true);
                } else {
                    speicher.setDigitCarryBit(false);
                }
                if(((result >> 8) & 1) == 1) {
                    speicher.setCarryBit(true);
                } else {
                    speicher.setCarryBit(false);
                }
                if (speicher.WRegister == 0) {
                    speicher.setZeroBit(true);
                } else {
                    speicher.setZeroBit(false);
                }
            //Gesamt Cycles und TMR0
            speicher.addToCycles(1);
            speicher.addToTimer(1);      
            return programmCounter + 1 ;
        }
    }
}