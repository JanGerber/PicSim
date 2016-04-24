using System;
using System.Collections;

namespace PicSimulator.ViewModels {
    class Speicher : Caliburn.Micro.Screen {

        private byte[] register;
        private byte wRegister;
        private Stack stack;
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
        public byte[] Register {
            get {
                return register;
            }

            set {
                register = value;
                NotifyOfPropertyChange(() => Register);
            }
        }
        #endregion
        public Speicher() {
            //gesamtes Register mit 0 initialisieren
                Register = new byte[256];
                byte nullen = Convert.ToByte(0); //0000 0000
                for (int i = 0; i < register.Length; i++) {
                Register[i] = nullen;
                }
            //Special Function Register initialisieren
                byte STATUS = Convert.ToByte(24); //0001 1000
                Register[3] = STATUS;
                Register[131] = STATUS;
                byte OPTION_REG = Convert.ToByte(255); //1111 1111
                Register[129] = OPTION_REG;
                byte TRISA = Convert.ToByte(31); //0001 1111
                Register[133] = TRISA;
                byte TRISB = Convert.ToByte(255); //1111 1111
                Register[134] = TRISB;
            //IO Port init
                IoPorts = 0;
            //W Register init
                wRegister = 0;
            //Cycles  auf 0
            cycles = 0;
            //Stack init
            stack = new Stack(8);
        }
    
        public byte getwRegister()  //get Funktion w-Register Test-Lukas
        {
            return wRegister;
        }

        public byte getRegister(int adresse) {
            if (new BitArray(new byte[] { Register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                return Register[adresse + 128];
            } else {
                return register[adresse];

            } 
        }
        public bool getRegister(int adresse, int bitNumber)
        {
            if (new BitArray(new byte[] { register[3] }).Get(5))
            { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                System.Collections.BitArray ba = new BitArray(new byte[] { Register[adresse + 128] });
                return ba.Get(bitNumber);
            }
            else
            {
                System.Collections.BitArray ba = new BitArray(new byte[] { Register[adresse] });
                return ba.Get(bitNumber);
            }
        }
        public void setRegister(int adr, int bitNumber, bool wert)
        {
            if(adr == 2 | adr == 3 | adr == 4 | adr == 10 | adr == 11) { //Überprüfung ob das Status | PCL | FSR | PCLATH | INTCON Register gewählt wurde
                if(wert) {
                    Register[adr + 128] = (byte)(Register[adr + 128] | (1 << bitNumber));
                    Register[adr] = (byte)(Register[adr] | (1 << bitNumber));
                } else {
                    Register[adr + 128] = (byte)(Register[adr + 128] & ~(1 << bitNumber));
                    Register[adr] = (byte)(Register[adr] & ~(1 << bitNumber));
                }
            } else {
                if(new BitArray(new byte[] { Register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                    if(wert) {
                        Register[adr + 128] = (byte)(Register[adr + 128] | (1 << bitNumber));
                    } else {
                        Register[adr + 128] = (byte)(Register[adr + 128] & ~(1 << bitNumber));
                    }
                } else {
                    if(wert) {
                        Register[adr] = (byte)(Register[adr] | (1 << bitNumber));
                    } else {
                        Register[adr] = (byte)(Register[adr] & ~(1 << bitNumber));
                    }
                }
            }
           
        }
        public void setRegister(int adr, byte wert) {
            if(adr == 2 | adr == 3 | adr == 4 | adr == 10 | adr == 11) { //Überprüfung ob das Status | PCL | FSR Register gewählt wurde
                Register[adr + 128] = wert;
                Register[adr] = wert;
            } else {
                if(new BitArray(new byte[] { register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                    Register[adr + 128] = wert;
                } else {
                    Register[adr] = wert;
                }
            }
        }

        public void addToTimer(int timeAdd) {
            if (!((Register[0x81] &  0x20)==32) ) {        //T0CS(OPTION_REG<5>) ist leer 
                for (int i = 0; i < timeAdd; i++) {
                    if (Register[1] == 255) {
                        Register[1]++;
                        //setzte Interrupt Flag
                        if(getRegister(0x0B, 5) && getRegister(0x0B, 5)) { //Ueberpruefe ob GIE AND INTCON<5>
                            setRegister(0x0B, 2, true); //Overflow sets bit T0IF(INTCON < 2 >).
                        }
                    } else {
                        Register[1]++;
                    }
                }
            }
        }   
        public void addToCycles(int pCycles)
        {
            cycles += (ulong) pCycles;
        }
        public void setZeroBit(bool wert) {
            if (wert) {
                Register[3] = (byte)(Register[3] | 0x04); //Zero Bit null setzten
                Register[131] = (byte)(Register[3] | 0x04);
            } else {
                Register[3] = (byte)(Register[3] & 0xFB);
                Register[131] = (byte)(Register[3] & 0xFB);
            }
            
        }
        public void setCarryBit(bool wert) {
            setRegister(3, 0, wert);
        }
        public int popStack() {
            return (int)stack.Pop();
        }
        public void pushStack(int addresse) {
            stack.Push(addresse);
        }

    }
}