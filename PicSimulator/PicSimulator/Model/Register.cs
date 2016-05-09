using PicSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulator.Model  {
    class RegisterBit {

        private int registerNr;
        private Speicher speicher;

        public RegisterBit(Speicher speicher) {
            this.speicher = speicher;
        }

        public bool Bit0 {
            get {

                    return speicher.getRegister(registerNr, 0);
                
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 0)) {
                            speicher.setRegister(registerNr, 0, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 0)) {
                        speicher.setRegister(registerNr, 0, value);
                        interruptINT();
                    }
                } else {
                    speicher.setRegister(registerNr, 0, value);
                }
            }
        }

        public bool Bit1 {
            get {
                return speicher.getRegister(registerNr, 1);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 1)) {
                        speicher.setRegister(registerNr, 1, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 1)) {
                        speicher.setRegister(registerNr, 1, value);
                    }
                } else {
                    speicher.setRegister(registerNr, 1, value);
                }

            }
        }

        public bool Bit2 {
            get {
                return speicher.getRegister(registerNr,2);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 2)) {
                        speicher.setRegister(registerNr, 2, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 2)) {
                        speicher.setRegister(registerNr, 2, value);
                    }
                } else {
                    speicher.setRegister(registerNr, 2, value);
                }

            }
        }

        public bool Bit3 {
            get {
                return speicher.getRegister(registerNr, 3);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 3)) {
                        speicher.setRegister(registerNr, 3, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 3)) {
                        speicher.setRegister(registerNr, 3, value);
                    }
                } else {
                    speicher.setRegister(registerNr, 3, value);
                }

            }
        }

        public bool Bit4 {
            get {
                return speicher.getRegister(registerNr, 4);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 4)) {
                        speicher.setRegister(registerNr,4, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 4)) {
                        speicher.setRegister(registerNr, 4, value);
                        interruptPortB();
                    }
                } else {
                    speicher.setRegister(registerNr, 4, value);
                }
            }
        }

        public bool Bit5 {
            get {
                return speicher.getRegister(registerNr, 5);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 5)) {
                        speicher.setRegister(registerNr, 5, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86,5)) {
                        speicher.setRegister(registerNr, 5, value);
                        interruptPortB();
                    }
                } else {
                    speicher.setRegister(registerNr, 5, value);
                }
            }
        }

        public bool Bit6 {
            get {
                return speicher.getRegister(registerNr, 6);
            }

            set {
                if (registerNr == 5) {
                    if (speicher.getRegisterOhneBank(0x85, 6)) {
                        speicher.setRegister(registerNr, 6, value);
                    }
                } else if (registerNr == 6) {
                    if (speicher.getRegisterOhneBank(0x86, 6)) {
                        speicher.setRegister(registerNr,6, value);
                        interruptPortB();
                    }
                } else {
                    speicher.setRegister(registerNr, 6, value);
                }
            }
        }

        public bool Bit7 {
            get {
                return speicher.getRegister(registerNr, 7);
            }

            set {
                if (registerNr == 5) { //PORT A
                    if (speicher.getRegisterOhneBank(0x85, 7)) {
                        speicher.setRegister(registerNr, 7, value);
                    }
                } else if (registerNr == 6) { //PORT B
                    if (speicher.getRegisterOhneBank(0x86, 7)) {
                        speicher.setRegister(registerNr, 7, value);
                        interruptPortB();
                    }
                } else {
                    speicher.setRegister(registerNr, 7, value);
                }
            }
        }

        public int RegisterNr {
            get {
                return registerNr;
            }

            set {
                registerNr = value;
            }
        }
        private void interruptPortB() {
            speicher.setRegister(0x0B, 0, true); //set INTCON<0>).
            if (speicher.getRegister(0x0B,7) && speicher.getRegister(0x0B, 3)) { //GIE  && INTCON<3>
                speicher.Interrupt = true;
                speicher.setRegister(0x0B, 7, false); //clear GIE
            }
        }
        private void interruptINT() { //TODO INT Interrupt
            if (speicher.getRegisterOhneBank(0x81, 6)) { // INTEDG bit (OPTION_REG<6>)
                if (speicher.getRegisterOhneBank(6,0)) { // if rising edge
                    speicher.setRegister(0x0B, 1, true);      //   INTF    bit (INTCON < 1 >)
                    if (speicher.getRegister(0x0B, 7) && speicher.getRegister(0x0B, 4)) { //GIE  && INTCON<4>
                        speicher.Interrupt = true;
                        speicher.setRegister(0x0B, 7, false); //clear GIE
                    }
                }
            } else {
                if (!speicher.getRegisterOhneBank(6, 0)) { // if falling edge
                    speicher.setRegister(0x0B, 1, true);     //   INTF    bit (INTCON < 1 >)
                    if (speicher.getRegister(0x0B, 7) && speicher.getRegister(0x0B, 4)) { //GIE  && INTCON<4>
                        speicher.Interrupt = true;
                        speicher.setRegister(0x0B, 7, false); //clear GIE
                    }
                }
            }

        }
    }

}
