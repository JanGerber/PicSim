using System;

namespace PicSimulator.ViewModels {
    class WhatchdogTimer {
        private Speicher speicher;
        private bool sleep;
        private int wdtCycles;
        private int prescalerCounter;
        private bool wdtNormalTimeout;

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
                if(value >= berechneMaxCycles()) {
                    if(sleep) { //Timeout wenn Sleep
                        wakeUpFromSleep(false);
                    } else { //Normaler Timeout
                        wdtNormalTimeout = true;
                    }
                }
                wdtCycles = value;
            }
        }

        public bool WdtNormalTimeout {
            get {
                return wdtNormalTimeout;
            }

            set {
                wdtNormalTimeout = value;
            }
        }

        private double berechneMaxCycles() {
            return 18000 * speicher.Frequenz;
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
                int psa_bits = speicher.Register[0x81] & 7;
                prescalerCounter++;
                switch (psa_bits) {
                    case 0:
                        if (prescalerCounter >= 1) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 1:
                        if (prescalerCounter >= 2) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 2:
                        if (prescalerCounter >= 4) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 3:
                        if (prescalerCounter >= 8) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 4:
                        if (prescalerCounter >= 16) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 5:
                        if (prescalerCounter >= 32) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 6:
                        if (prescalerCounter >= 64) {
                            WdtCycles += 1;
                            prescalerCounter = 0;
                        }
                        break;
                    case 7:
                        if (prescalerCounter >= 128) {
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
        private double berechneTime(double frequenz, int cycles) {
            return ((cycles / frequenz) * 4);
        }

        public void wdtResetNormal() {
            speicher.Register[0x02] = 0; //PCL
            speicher.Register[0x03] = (byte)((speicher.Register[0x03] & 0x07) + 0x08); //Status
            speicher.Register[0x0A] = 0; //PCLATH
            speicher.Register[0x0B] = (byte)((speicher.Register[0x03] & 0x01));//INTCON
            speicher.Register[0x81] = 0xFF;//OPTION_REG
            speicher.Register[0x82] = 0;//PCL
            speicher.Register[0x83] = (byte)((speicher.Register[0x83] & 0x07) + 0x08); //STATUS
            speicher.Register[0x85] = 0x1F;//TRISA
            speicher.Register[0x86] = 0xFF;//TRISB
            speicher.Register[0x88] =  0x08; //EECON1
            speicher.Register[0x8A] = 0;//PCLATH
            speicher.Register[0x8B] = (byte)((speicher.Register[0x03] & 0x01)); //INTCON
            wdtNormalTimeout = true;
        }
        public void wakeUpFromSleep(bool isInterrupt) {
            speicher.Register[0x02] = (byte)(speicher.Register[0x02] + 1); //PCL
            speicher.Register[0x82] = (byte)(speicher.Register[0x02] + 1);//PCL
            speicher.Register[0x88] = (byte)(speicher.Register[0x88] & 0x0F);//EECON1

            if(isInterrupt) {
                speicher.Register[0x03] = (byte)((speicher.Register[0x03] & 0xE7) + 0x10); //Status
                speicher.Register[0x83] = (byte)((speicher.Register[0x03] & 0xE7) + 0x10); //Status
            } else {
                speicher.Register[0x03] = (byte)((speicher.Register[0x03] & 0x07)); //Status 
                speicher.Register[0x83] = (byte)((speicher.Register[0x03] & 0x07)); //Status    
            }
            Sleep = false;
        }
        public void clearWDT() {
            wdtCycles = 0;
            prescalerCounter = 0;
        }
        public void clearWdtPrescaler() {
            if(speicher.getRegisterOhneBank(0x81,3)) { //PSA
                speicher.Register[0x81] = (byte)(speicher.Register[0x81] & 0xF8);
            }
        }
    }
}