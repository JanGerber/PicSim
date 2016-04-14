using System;
using System.Collections;

namespace PicSimulator.ViewModels {
    class Speicher {

        private byte[] register;
        private byte wRegister;
        private int[] stack;
        private byte ioPorts;

        #region properties
        public byte WRegister {
            get {
                return wRegister;
            }

            set {
                wRegister = value;
            }
        }

        

        public byte IoPorts {
            get {
                return ioPorts;
            }

            set {
                ioPorts = value;
            }
        }
        #endregion
        public Speicher() {
            //gesamtes Register mit 0 initialisieren
                register = new byte[256];
                byte nullen = Convert.ToByte(0); //0000 0000
                for (int i = 0; i < register.Length; i++) { 
                    register[i] = nullen;
                }
            //Special Function Register initialisieren
                byte STATUS = Convert.ToByte(24); //0001 1000
                register[3] = STATUS;
                register[131] = STATUS;
                byte OPTION_REG = Convert.ToByte(255); //1111 1111
                register[129] = OPTION_REG;
                byte TRISA = Convert.ToByte(31); //0001 1111
                register[133] = TRISA;
                byte TRISB = Convert.ToByte(255); //1111 1111
                register[134] = TRISB;
            //IO Port init
                IoPorts = 0;
            //W Register init
                wRegister = 0;
            //Stack init
                stack = new int[8];
                for (int i = 0; i < stack.Length; i++) {
                    register[i] = 0;
                }
        }
        public byte getRegister(int adresse) {
            if (new BitArray(new byte[] { register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                return register[adresse + 128];
            } else {
                return register[adresse];
            } 
        }
        public void setRegister(int adresse, byte wert) {


        }

        public void addToTimer(int timeAdd) {
            for (int i = 0; i < timeAdd; i++) {
                if(register[1] == 255) {
                    register[1]++;
                    //setzte Interrupt Flag
                } else {
                    register[1]++;
                }
            }
        }
        public void setZeroBit(bool wert) {
            if (wert) {
                register[3] = (byte)(register[3] | 0x04); //Zero Bit null setzten
                register[131] = (byte)(register[3] | 0x04);
            } else {
                register[3] = (byte)(register[3] & 0xFB);
                register[131] = (byte)(register[3] & 0xFB);
            }
            
        }


    }
}