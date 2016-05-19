using System;

namespace PicSimulator.ViewModels {
    class WhatchdogTimer {
        private Speicher speicher;
        private bool sleep;
        private int wdtCycles;
        private int prescalerCounter;

        public bool Sleep {
            get {
                return sleep;
            }

            set {
                sleep = value;
            }
        }

        public int WdtCycles {
            get {
                return wdtCycles;
            }

            set {
                wdtCycles = value;
            }
        }

        public WhatchdogTimer(Speicher speicher) {
            this.speicher = speicher;
        }

        public void addToWDT() {
            wdtWithPost();

        }

        public void addToWDT(int pCycles) {
            for (int i = 0; i < pCycles; i++) {
                wdtWithPost();
            }  
        }
        private void wdtWithPost() {
            if (speicher.getRegisterOhneBank(0x81, 3)) {
                // PSA = 0
                //increase With PSA
                int psa_bits = speicher.getRegister(0x81) & 7;
                prescalerCounter++;
                switch (psa_bits) {
                    case 0:
                        if (prescalerCounter >= 2) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 1:
                        if (prescalerCounter >= 4) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 2:
                        if (prescalerCounter >= 8) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 3:
                        if (prescalerCounter >= 16) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 4:
                        if (prescalerCounter >= 32) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 5:
                        if (prescalerCounter >= 64) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 6:
                        if (prescalerCounter >= 128) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 7:
                        if (prescalerCounter >= 256) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;

                    default:
                        break;

                }
            } else {
                // PSA = 1
                WdtCycles += 1;
            }
        }
    }
}