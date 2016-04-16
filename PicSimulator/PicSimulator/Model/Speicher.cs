using System;
using System.Collections;

namespace PicSimulator.ViewModels {
    class Speicher {

        private byte[] register;
        private byte wRegister;
        private int[] stack;
        private byte ioPorts;
        private ulong cycles;

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
            //Cycles  auf 0
            cycles = 0;
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
        public bool getRegister(int adresse, int bitNumber)
        {
            if (new BitArray(new byte[] { register[3] }).Get(5))
            { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                System.Collections.BitArray ba = new BitArray(new byte[] { register[adresse + 128] });
                return ba.Get(bitNumber);
            }
            else
            {
                System.Collections.BitArray ba = new BitArray(new byte[] { register[adresse] });
                return ba.Get(bitNumber);
            }
        }
        public void setRegister(int adr, int bitNumber, bool wert)
        {
            if(adr == 2 | adr == 3 | adr == 4 | adr == 130 | adr == 131 | adr == 132) { //Überprüfung ob das Status | PCL | FSR Register gewählt wurde
                if(wert) {
                    register[adr + 128] = (byte)(register[adr + 128] | (1 << bitNumber));
                    register[adr] = (byte)(register[adr] | (1 << bitNumber));
                } else {
                    register[adr + 128] = (byte)(register[adr + 128] & ~(1 << bitNumber));
                    register[adr] = (byte)(register[adr] & ~(1 << bitNumber));
                }
            } else {
                if(new BitArray(new byte[] { register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                    if(wert) {
                        register[adr + 128] = (byte)(register[adr + 128] | (1 << bitNumber));
                    } else {
                        register[adr + 128] = (byte)(register[adr + 128] & ~(1 << bitNumber));
                    }
                } else {
                    if(wert) {
                        register[adr] = (byte)(register[adr] | (1 << bitNumber));
                    } else {
                        register[adr] = (byte)(register[adr] & ~(1 << bitNumber));
                    }
                }
            }
           
        }
        public void setRegister(int adr, byte wert) {
            if(adr == 2 | adr == 3 | adr == 4 | adr == 130 | adr == 131 | adr == 132) { //Überprüfung ob das Status | PCL | FSR Register gewählt wurde
                register[adr + 128] = wert;
                register[adr] = wert;
            } else {
                if(new BitArray(new byte[] { register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                    register[adr + 128] = wert;
                } else {
                    register[adr] = wert;
                }
            }
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
        public void addToCycles(int pCycles)
        {
            cycles += (ulong) pCycles;
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