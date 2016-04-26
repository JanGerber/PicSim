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
                return speicher.getRegister(registerNr,0);
            }

            set {
                speicher.setRegister(registerNr,0,value);

            }
        }

        public bool Bit1 {
            get {
                return speicher.getRegister(registerNr, 1);
            }

            set {
                speicher.setRegister(registerNr, 1, value);

            }
        }

        public bool Bit2 {
            get {
                return speicher.getRegister(registerNr,2);
            }

            set {
                speicher.setRegister(registerNr, 2, value);

            }
        }

        public bool Bit3 {
            get {
                return speicher.getRegister(registerNr, 3);
            }

            set {
                speicher.setRegister(registerNr, 3, value);

            }
        }

        public bool Bit4 {
            get {
                return speicher.getRegister(registerNr, 4);
            }

            set {
                speicher.setRegister(registerNr, 4, value);
            }
        }

        public bool Bit5 {
            get {
                return speicher.getRegister(registerNr, 5);
            }

            set {
                speicher.setRegister(registerNr, 5, value);
            }
        }

        public bool Bit6 {
            get {
                return speicher.getRegister(registerNr, 6);
            }

            set {
                speicher.setRegister(registerNr, 6, value);
            }
        }

        public bool Bit7 {
            get {
                return speicher.getRegister(registerNr, 7);
            }

            set {
                speicher.setRegister(registerNr, 7, value);
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
    }

}
