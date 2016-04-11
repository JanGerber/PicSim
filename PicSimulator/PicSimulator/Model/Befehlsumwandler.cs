using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PicSimulator.Model
{
    class Befehlsumwandler
    {
        Dictionary<int, Befehl> _opcodesObj;

        public Befehlsumwandler(Dictionary<int, int>_opcodes){
            Dictionary<int, Befehl> opcodesObjImpl = new Dictionary<int, Befehl>();

            foreach (KeyValuePair<int, int> opcode in _opcodes) {
                Befehl befehl = wandleBefehl(opcode.Value);
                opcodesObjImpl.Add(opcode.Key, befehl);
            }
            OpcodesObj = opcodesObjImpl;
        }
        private Befehl wandleBefehl(int befehlOpcode) {
            //BitArray bit = new BitArray(new int[] { befehlOpcode });

            #region Befehlscodemaske
            if ((befehlOpcode & ADDLW) == ADDLW) {
                return newADDLW(befehlOpcode);
            }
            if ((befehlOpcode & SUBLW) == SUBLW) {
                return newSUBLW(befehlOpcode);
            }
            if ((befehlOpcode & XORLW) == XORLW) {
                return newXORLW(befehlOpcode);
            }
            if ((befehlOpcode & ANDLW) == ANDLW) {
                return newANDLW(befehlOpcode);
            }
            if ((befehlOpcode & IORLW) == IORLW) {
                return newIORLW(befehlOpcode);
            }
            if ((befehlOpcode & RETLW) == RETLW) {
                return newRETLW(befehlOpcode);
            }
            if ((befehlOpcode & MOVLW) == MOVLW) {
                return newMOVLW(befehlOpcode);
            }
            if ((befehlOpcode & GOTO) == GOTO) {
                return newGOTO(befehlOpcode);
            }
            if ((befehlOpcode & CALL) == CALL) {
                return newCALL(befehlOpcode);
            }
            if ((befehlOpcode & BTFSS) == BTFSS) {
                return newBTFSS(befehlOpcode);
            }
            if ((befehlOpcode & BTFSC) == BTFSC) {
                return newBTFSC(befehlOpcode);
            }
            if ((befehlOpcode & BSF) == BSF) {
                return newBSF(befehlOpcode);
            }
            if ((befehlOpcode & BCF) == BCF) {
                return newBCF(befehlOpcode);
            }
            if ((befehlOpcode & INCFSZ) == INCFSZ) {
                return newINCFSZ(befehlOpcode);
            }
            if ((befehlOpcode & SWAPF) == SWAPF) {
                return newSWAPF(befehlOpcode);
            }
            if ((befehlOpcode & RLF) == RLF) {
                return newRLF(befehlOpcode);
            }
            if ((befehlOpcode & RRF) == RRF) {
                return newRRF(befehlOpcode);
            }
            if ((befehlOpcode & DECFSZ) == DECFSZ) {
                return newDECFSZ(befehlOpcode);
            }
            if ((befehlOpcode & INCF) == INCF) {
                return newINCF(befehlOpcode);
            }
            if ((befehlOpcode & COMF) == COMF) {
                return newCOMF(befehlOpcode);
            }
            if ((befehlOpcode & MOVF) == MOVF) {
                return newMOVF(befehlOpcode);
            }
            if ((befehlOpcode & ADDWF) == ADDWF) {
                return newADDWF(befehlOpcode);
            }
            if ((befehlOpcode & XORWF) == XORWF) {
                return newXORWF(befehlOpcode);
            }
            if ((befehlOpcode & ANDWF) == ANDWF) {
                return newANDWF(befehlOpcode);
            }
            if ((befehlOpcode & IORWF) == IORWF) {
                return newIORWF(befehlOpcode);
            }
            if ((befehlOpcode & DECF) == DECF) {
                return newDECF(befehlOpcode);
            }
            if ((befehlOpcode & SUBWF) == SUBWF) {
                return newSUBWF(befehlOpcode);
            }
            if ((befehlOpcode & CLRF) == CLRF) {
                return newCLRF(befehlOpcode);
            }
            if ((befehlOpcode & CLRW) == CLRW) {
                return newCLRW(befehlOpcode);
            }
            if ((befehlOpcode & MOVWF) == MOVWF) {
                return newMOVWF(befehlOpcode);
            }
            if ((befehlOpcode & CLRWDT) == CLRWDT) {
                return newCLRWDT(befehlOpcode);
            }
            if ((befehlOpcode & SLEEP) == SLEEP) {
                return newSLEEP(befehlOpcode);
            }
            if ((befehlOpcode & RETFIE) == RETFIE) {
                return newRETFIE(befehlOpcode);
            }
            if ((befehlOpcode & RETURN) == RETURN) {
                return newRETURN(befehlOpcode);
            }
            if ((befehlOpcode & NOP) == NOP) {
                return newNOP(befehlOpcode);
            }
            #endregion

            //TODO Fehlermeldung
            System.Console.WriteLine("FEHLER: es konnte keine Bitmaske gefunden werden");

            return null;
            
        }

        private Befehl newANDWF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlANDWF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newADDWF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlADDWF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newCLRF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlCLRF((befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private Befehl newCLRW(int befehlOpcode) {
            return new BefehlCLRW();
        }

        private Befehl newCOMF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlCOMF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newDECF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlDECF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newDECFSZ(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlDECFSZ((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newINCF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlINCF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newINCFSZ(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlINCFSZ((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newIORWF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlIORWF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newMOVF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlMOVF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newMOVWF(int befehlOpcode) {
            return new BefehlMOVWF((befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private Befehl newNOP(int befehlOpcode) {
            return new BefehlNOP();
        }

        private Befehl newRLF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlRLF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newRRF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlRRF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newSWAPF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlSWAPF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newSUBWF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlSUBWF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newXORWF(int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlXORWF((befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private Befehl newBCF(int befehlOpcode) {
            System.Console.WriteLine("newBCF");
            return null;
        }

        private Befehl newBSF(int befehlOpcode) {
            System.Console.WriteLine("newBSF");
            return null;
        }

        private Befehl newBTFSC(int befehlOpcode) {
            System.Console.WriteLine("newBTFSC");
            return null;
        }

        private Befehl newBTFSS(int befehlOpcode) {
            System.Console.WriteLine("newBTFSS");
            return null;
        }

        private Befehl newADDLW(int befehlOpcode) {
            return new BefehlADDLW((befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private Befehl newANDLW(int befehlOpcode) {
            return new BefehlANDLW((befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private Befehl newCALL(int befehlOpcode) {
            return new BefehlCALL((befehlOpcode & Convert.ToInt32("11111111111", 2)));
        }

        private Befehl newCLRWDT(int befehlOpcode) {
            return new BefehlCLRWDT();
        }

        private Befehl newGOTO(int befehlOpcode) {
            return new BefehlGOTO((befehlOpcode & Convert.ToInt32("11111111111", 2)));
        }

        private Befehl newIORLW(int befehlOpcode) {
            return new BefehlIORLW((befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private Befehl newMOVLW(int befehlOpcode) {
            return new BefehlMOVLW((befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private Befehl newRETFIE(int befehlOpcode) {
            return new BefehlRETFIE();
        }

        private Befehl newRETLW(int befehlOpcode) {
            return new BefehlRETLW((befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private Befehl newRETURN(int befehlOpcode) {
            return new BefehlRETURN();
        }

        private Befehl newSLEEP(int befehlOpcode) {
            return new BefehlSLEEP();
        }

        private Befehl newSUBLW(int befehlOpcode) {
            return new BefehlSUBLW((befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private Befehl newXORLW(int befehlOpcode) {
            return new BefehlXORLW((befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        #region Befehlsliste
        private int ADDWF = Convert.ToInt32("00011100000000", 2);
        private int ANDWF = Convert.ToInt32("00010100000000", 2);
        private int CLRF =  Convert.ToInt32("00000110000000", 2);
        private int CLRW =  Convert.ToInt32("00000100000000", 2);
        private int COMF =  Convert.ToInt32("00100100000000", 2);
        private int DECF =  Convert.ToInt32("00001100000000", 2);
        private int DECFSZ =Convert.ToInt32("00101100000000", 2);
        private int INCF =  Convert.ToInt32("00101000000000", 2);
        private int INCFSZ =Convert.ToInt32("00111100000000", 2);
        private int IORWF = Convert.ToInt32("00010000000000", 2);
        private int MOVF =  Convert.ToInt32("00100000000000", 2);
        private int MOVWF = Convert.ToInt32("00000010000000", 2);
        private int NOP =   Convert.ToInt32("00000000000000", 2);
        private int RLF =   Convert.ToInt32("00110100000000", 2);
        private int RRF =   Convert.ToInt32("00110000000000", 2);
        private int SUBWF = Convert.ToInt32("00001000000000", 2);
        private int SWAPF = Convert.ToInt32("00111000000000", 2);
        private int XORWF = Convert.ToInt32("00011000000000", 2);
        private int BCF =   Convert.ToInt32("01000000000000", 2);
        private int BSF =   Convert.ToInt32("01010000000000", 2);
        private int BTFSC = Convert.ToInt32("01100000000000", 2);
        private int BTFSS = Convert.ToInt32("01110000000000", 2);
        private int ADDLW = Convert.ToInt32("11111000000000", 2);
        private int ANDLW = Convert.ToInt32("11100100000000", 2);
        private int CALL =  Convert.ToInt32("10000000000000", 2);
        private int CLRWDT =Convert.ToInt32("00000001100100", 2);
        private int GOTO =  Convert.ToInt32("10100000000000", 2);
        private int IORLW = Convert.ToInt32("11100000000000", 2);
        private int MOVLW = Convert.ToInt32("11000000000000", 2);
        private int RETFIE =Convert.ToInt32("00000000001001", 2);
        private int RETLW = Convert.ToInt32("11010000000000", 2);
        private int RETURN =Convert.ToInt32("00000000001000", 2);
        private int SLEEP = Convert.ToInt32("00000001100011", 2);
        private int SUBLW = Convert.ToInt32("11110000000000", 2);
        private int XORLW = Convert.ToInt32("11101000000000", 2);

        public Dictionary<int, Befehl> OpcodesObj {
            get {
                return _opcodesObj;
            }

            set {
                _opcodesObj = value;
            }
        }
        #endregion
    }
}
