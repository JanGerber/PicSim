using System;
using System.Collections;

namespace PicSimulator.ViewModels {
    class Speicher {

        private byte[] register = new byte[256];
        private byte wRegister;
        private byte PC;
        private byte ioPorts;

        public byte WRegister {
            get {
                return wRegister;
            }

            set {
                wRegister = value;
            }
        }

        public byte PC1 {
            get {
                return PC;
            }

            set {
                PC = value;
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

        public Speicher() {
            //gesamtes Register mit 0 initialisieren
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
            //ProgrammCounter init
                PC = 0;
            //IO Port init
                IoPorts = 0;
            //W Register init
                wRegister = 0;
        }
        public byte getRegister(int adresse) {
            if (new BitArray(new byte[] { register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                return register[adresse + 128];
            } else {
                return register[adresse];
            } 
        }
        public void setRegister(int adresse) {


        }

        public void addToTimer(int timeAdd) {
            if(register[1] + timeAdd > 255) { // falls es zu einem überlauf des Timers 
                register[1] += (byte)timeAdd;
                //Throw interrupt       // Wird ein Interrupt geworfen
            } else {
                register[1] += (byte)timeAdd;
            }
        }


    }
}