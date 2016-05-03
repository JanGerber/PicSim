using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PicSimulator.ViewModel;

namespace PicSimulator.Model
{
    class Befehlsumwandler
    {
        Dictionary<int, BefehlViewModel> _opcodesObj;

        public Befehlsumwandler(Dictionary<int, int>_opcodes){
            Dictionary<int, BefehlViewModel> opcodesObjImpl = new Dictionary<int, BefehlViewModel>();

            foreach (KeyValuePair<int, int> opcode in _opcodes) {
                BefehlViewModel befehl = wandleBefehl(opcode.Key, opcode.Value);
                opcodesObjImpl.Add(opcode.Key, befehl);
            }
            OpcodesObj = opcodesObjImpl;
        }
        private BefehlViewModel wandleBefehl(int key, int befehlOpcode) {
            //BitArray bit = new BitArray(new int[] { befehlOpcode });

            #region Befehlscodemaske
            if ((befehlOpcode & ADDLW) == ADDLW) {
                return newADDLW(key, befehlOpcode);
            }
            if ((befehlOpcode & SUBLW) == SUBLW) {
                return newSUBLW(key, befehlOpcode);
            }
            if ((befehlOpcode & XORLW) == XORLW) {
                return newXORLW(key, befehlOpcode);
            }
            if ((befehlOpcode & ANDLW) == ANDLW) {
                return newANDLW(key, befehlOpcode);
            }
            if ((befehlOpcode & IORLW) == IORLW) {
                return newIORLW(key, befehlOpcode);
            }
            if ((befehlOpcode & RETLW) == RETLW) {
                return newRETLW(key, befehlOpcode);
            }
            if ((befehlOpcode & MOVLW) == MOVLW) {
                return newMOVLW(key, befehlOpcode);
            }
            if ((befehlOpcode & GOTO) == GOTO) {
                return newGOTO(key, befehlOpcode);
            }
            if ((befehlOpcode & CALL) == CALL) {
                return newCALL(key, befehlOpcode);
            }
            if ((befehlOpcode & BTFSS) == BTFSS) {
                return newBTFSS(key, befehlOpcode);
            }
            if ((befehlOpcode & BTFSC) == BTFSC) {
                return newBTFSC(key, befehlOpcode);
            }
            if ((befehlOpcode & BSF) == BSF) {
                return newBSF(key, befehlOpcode);
            }
            if ((befehlOpcode & BCF) == BCF) {
                return newBCF(key, befehlOpcode);
            }
            if ((befehlOpcode & INCFSZ) == INCFSZ) {
                return newINCFSZ(key, befehlOpcode);
            }
            if ((befehlOpcode & SWAPF) == SWAPF) {
                return newSWAPF(key, befehlOpcode);
            }
            if ((befehlOpcode & RLF) == RLF) {
                return newRLF(key, befehlOpcode);
            }
            if ((befehlOpcode & RRF) == RRF) {
                return newRRF(key, befehlOpcode);
            }
            if ((befehlOpcode & DECFSZ) == DECFSZ) {
                return newDECFSZ(key, befehlOpcode);
            }
            if ((befehlOpcode & INCF) == INCF) {
                return newINCF(key, befehlOpcode);
            }
            if ((befehlOpcode & COMF) == COMF) {
                return newCOMF(key, befehlOpcode);
            }
            if ((befehlOpcode & MOVF) == MOVF) {
                return newMOVF(key, befehlOpcode);
            }
            if ((befehlOpcode & ADDWF) == ADDWF) {
                return newADDWF(key, befehlOpcode);
            }
            if ((befehlOpcode & XORWF) == XORWF) {
                return newXORWF(key, befehlOpcode);
            }
            if ((befehlOpcode & ANDWF) == ANDWF) {
                return newANDWF(key, befehlOpcode);
            }
            if ((befehlOpcode & IORWF) == IORWF) {
                return newIORWF(key, befehlOpcode);
            }
            if ((befehlOpcode & DECF) == DECF) {
                return newDECF(key, befehlOpcode);
            }
            if ((befehlOpcode & SUBWF) == SUBWF) {
                return newSUBWF(key, befehlOpcode);
            }
            if ((befehlOpcode & CLRF) == CLRF) {
                return newCLRF(key, befehlOpcode);
            }
            if ((befehlOpcode & CLRW) == CLRW) {
                return newCLRW(key, befehlOpcode);
            }
            if ((befehlOpcode & MOVWF) == MOVWF) {
                return newMOVWF(key, befehlOpcode);
            }
            if ((befehlOpcode & CLRWDT) == CLRWDT) {
                return newCLRWDT(key, befehlOpcode);
            }
            if ((befehlOpcode & SLEEP) == SLEEP) {
                return newSLEEP(key, befehlOpcode);
            }
            if ((befehlOpcode & RETFIE) == RETFIE) {
                return newRETFIE(key, befehlOpcode);
            }
            if ((befehlOpcode & RETURN) == RETURN) {
                return newRETURN(key, befehlOpcode);
            }
            if ((befehlOpcode & NOP) == NOP) {
                return newNOP(key, befehlOpcode);
            }
            #endregion

            //TODO Fehlermeldung
            System.Console.WriteLine("FEHLER: es konnte keine Bitmaske gefunden werden");
            return null;         
        }

        private BefehlViewModel newANDWF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlANDWF(programmCounter,(befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newADDWF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlADDWF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newCLRF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlCLRF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private BefehlViewModel newCLRW(int programmCounter, int befehlOpcode) {
            return new BefehlCLRW(programmCounter);
        }

        private BefehlViewModel newCOMF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlCOMF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newDECF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlDECF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newDECFSZ(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlDECFSZ(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newINCF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlINCF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newINCFSZ(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlINCFSZ(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newIORWF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlIORWF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newMOVF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlMOVF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newMOVWF(int programmCounter, int befehlOpcode) {
            return new BefehlMOVWF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private BefehlViewModel newNOP(int programmCounter, int befehlOpcode) {
            return new BefehlNOP(programmCounter);
        }

        private BefehlViewModel newRLF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlRLF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newRRF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlRRF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newSWAPF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlSWAPF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newSUBWF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlSUBWF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newXORWF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlXORWF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), bitArray[7]);
        }

        private BefehlViewModel newBCF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlBCF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), (int)((befehlOpcode & Convert.ToInt32("1110000000", 2)) / 128));
        }

        private BefehlViewModel newBSF(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlBSF(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), (int)((befehlOpcode & Convert.ToInt32("1110000000", 2)) / 128));
        }

        private BefehlViewModel newBTFSC(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlBTFSC(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)), (int)((befehlOpcode & Convert.ToInt32("1110000000", 2)) / 128));
        }

        private BefehlViewModel newBTFSS(int programmCounter, int befehlOpcode) {
            BitArray bitArray = new BitArray(new int[] { befehlOpcode });
            return new BefehlBTFSS(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)),(int)((befehlOpcode & Convert.ToInt32("1110000000", 2))/128));
        }

        private BefehlViewModel newADDLW(int programmCounter, int befehlOpcode) {
            return new BefehlADDLW(programmCounter, (befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private BefehlViewModel newANDLW(int programmCounter, int befehlOpcode) {
            return new BefehlANDLW(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private BefehlViewModel newCALL(int programmCounter, int befehlOpcode) {
            return new BefehlCALL(programmCounter, (befehlOpcode & Convert.ToInt32("11111111111", 2)));
        }

        private BefehlViewModel newCLRWDT(int programmCounter, int befehlOpcode) {
            return new BefehlCLRWDT(programmCounter);
        }

        private BefehlViewModel newGOTO(int programmCounter, int befehlOpcode) {
            return new BefehlGOTO(programmCounter, (befehlOpcode & Convert.ToInt32("11111111111", 2)));
        }

        private BefehlViewModel newIORLW(int programmCounter, int befehlOpcode) {
            return new BefehlIORLW(programmCounter, (befehlOpcode & Convert.ToInt32("1111111", 2)));
        }

        private BefehlViewModel newMOVLW(int programmCounter, int befehlOpcode) {
            return new BefehlMOVLW(programmCounter, (befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private BefehlViewModel newRETFIE(int programmCounter, int befehlOpcode) {
            return new BefehlRETFIE(programmCounter);
        }

        private BefehlViewModel newRETLW(int programmCounter, int befehlOpcode) {
            return new BefehlRETLW(programmCounter,(befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private BefehlViewModel newRETURN(int programmCounter, int befehlOpcode) {
            return new BefehlRETURN(programmCounter);
        }

        private BefehlViewModel newSLEEP(int programmCounter, int befehlOpcode) {
            return new BefehlSLEEP(programmCounter);
        }

        private BefehlViewModel newSUBLW(int programmCounter, int befehlOpcode) {
            return new BefehlSUBLW(programmCounter,(befehlOpcode & Convert.ToInt32("11111111", 2)));
        }

        private BefehlViewModel newXORLW(int programmCounter, int befehlOpcode) {
            return new BefehlXORLW(programmCounter,(befehlOpcode & Convert.ToInt32("11111111", 2)));
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

        public Dictionary<int, BefehlViewModel> OpcodesObj {
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
