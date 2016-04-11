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
        public Befehlsumwandler(Dictionary<int, int>_opcodes)
        {
            foreach (KeyValuePair<int, int> opcode in _opcodes) {
                System.Console.WriteLine(opcode.Key + " " + opcode.Value);
                wandleBefehl(opcode.Value);
               
            }
            System.Console.ReadLine();
        }
        private Befehl wandleBefehl(int befehlOpcode) {
            //BitArray bit = new BitArray(new int[] { befehlOpcode });

            #region ADDWF
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
            System.Console.WriteLine("FEHLER");

            return null;
            
        }

        private Befehl newANDWF(int befehlOpcode) {
            throw new NotImplementedException();
        }

        private Befehl newADDWF(int befehlOpcode) {
            System.Console.WriteLine("newADDWF");
            return null;
        }

        private Befehl newCLRF(int befehlOpcode) {
            System.Console.WriteLine("newCLRF");
            return null;
        }

        private Befehl newCLRW(int befehlOpcode) {
            System.Console.WriteLine("newCLRW");
            return null;
        }

        private Befehl newCOMF(int befehlOpcode) {
            System.Console.WriteLine("newCOMF");
            return null;
        }

        private Befehl newDECF(int befehlOpcode) {
            System.Console.WriteLine("newDECF");
            return null;
        }

        private Befehl newDECFSZ(int befehlOpcode) {
            System.Console.WriteLine("newDECFSZ");
            return null;
        }

        private Befehl newINCF(int befehlOpcode) {
            System.Console.WriteLine("newINCF");
            return null;
        }

        private Befehl newINCFSZ(int befehlOpcode) {
            System.Console.WriteLine("newINCFSZ");
            return null;
        }

        private Befehl newIORWF(int befehlOpcode) {
            System.Console.WriteLine("newIORWF");
            return null;
        }

        private Befehl newMOVF(int befehlOpcode) {
            System.Console.WriteLine("newMOVF");
            return null;
        }

        private Befehl newMOVWF(int befehlOpcode) {
            System.Console.WriteLine("newMOVWF");
            return null;
        }

        private Befehl newNOP(int befehlOpcode) {
            System.Console.WriteLine("newNOP");
            return null;
        }

        private Befehl newRLF(int befehlOpcode) {
            System.Console.WriteLine("newRLF");
            return null;
        }

        private Befehl newRRF(int befehlOpcode) {
            System.Console.WriteLine("newRRF");
            return null;
        }

        private Befehl newSWAPF(int befehlOpcode) {
            System.Console.WriteLine("newSWAPF");
            return null;
        }

        private Befehl newSUBWF(int befehlOpcode) {
            System.Console.WriteLine("newSUBWF");
            return null;
        }

        private Befehl newXORWF(int befehlOpcode) {
            System.Console.WriteLine("newXORWF");
            return null;
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
            System.Console.WriteLine("newADDLW");
            return null;
        }

        private Befehl newANDLW(int befehlOpcode) {
            System.Console.WriteLine("newANDLW");
            return null;
        }

        private Befehl newCALL(int befehlOpcode) {
            System.Console.WriteLine("newCALL");
            return null;
        }

        private Befehl newCLRWDT(int befehlOpcode) {
            System.Console.WriteLine("newCLRWDT");
            return null;
        }

        private Befehl newGOTO(int befehlOpcode) {
            System.Console.WriteLine("newGOTO");
            return null;
        }

        private Befehl newIORLW(int befehlOpcode) {
            System.Console.WriteLine("newIORLW");
            return null;
        }

        private Befehl newMOVLW(int befehlOpcode) {
            System.Console.WriteLine("newMOVLW");
            return null;
        }

        private Befehl newRETFIE(int befehlOpcode) {
            System.Console.WriteLine("newRETFIE");
            return null;
        }

        private Befehl newRETLW(int befehlOpcode) {
            System.Console.WriteLine("newRETLW");
            return null;
        }

        private Befehl newRETURN(int befehlOpcode) {
            System.Console.WriteLine("newRETURN");
            return null;
        }

        private Befehl newSLEEP(int befehlOpcode) {
            System.Console.WriteLine("newSLEEP");
            return null;
        }

        private Befehl newSUBLW(int befehlOpcode) {
            System.Console.WriteLine("newSUBLW");
            return null;
        }

        private Befehl newXORLW(int befehlOpcode) {
            System.Console.WriteLine("newXORLW");
            Befehl befehl = new BefehlXORLW();
            return befehl;
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
        #endregion
    }
}
