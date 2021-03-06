﻿using PicSimulator.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PicSimulator.ViewModels {
    class Speicher : Caliburn.Micro.Screen {

        private byte[] register;
        private byte wRegister;
        private Stack stack;
        private ulong cycles;
        Dictionary<string, RegisterBit> bitArray;
        private bool interrupt;
        Dictionary<int, String> stackAusgabe;
        private int psa_counter;
        private double frequenz; // MHz
        private int timeInyS; //in Mikrosekunde
        private WhatchdogTimer wdt;





        #region properties
        public byte WRegister {
            get {
                return wRegister;
            }

            set {
                wRegister = value;
                NotifyOfPropertyChange(() => WRegister);
            }
        }

        public bool[] PortA {
            get
            {
                bool[] bitArray = new bool[8];
                System.Collections.BitArray ba = new BitArray(new byte[] { Register[5] });
                for (int j = 0; j < 8; j++)
                    {
                        bitArray[j] = ba.Get(j);
                    }
                return bitArray;
            }
            set
            {
                    for (int j = 0; j < 8; j++)
                    {
                        if (value[j])
                        {
                            Register[5] = (byte)(Register[5] | (1 << j));
                        }
                        else
                        {
                            Register[5] = (byte)(Register[5] & ~(1 << j));
                        }
                    }
                NotifyOfPropertyChange(() => PortA);
                NotifyOfPropertyChange(() => Register);
            }

        }
        public Dictionary<string, RegisterBit> PortB
        {
            get
            {
                bitArray = new Dictionary<string, RegisterBit>();
                System.Collections.BitArray ba = new BitArray(new byte[] { Register[5] });

                RegisterBit register = new RegisterBit(this);   
                register.Bit0 = ba.Get(0);
                register.Bit1 = ba.Get(1);
                register.Bit2 = ba.Get(2);
                register.Bit3 = ba.Get(3);
                register.Bit4 = ba.Get(4);
                register.Bit5 = ba.Get(5);
                register.Bit6 = ba.Get(6);
                register.Bit7 = ba.Get(7);
                register.RegisterNr = 5;
                bitArray.Add("PORTA", register);

                ba = new BitArray(new byte[] { Register[6] });
                register = new RegisterBit(this);
                register.Bit0 = ba.Get(0);
                register.Bit1 = ba.Get(1);
                register.Bit2 = ba.Get(2);
                register.Bit3 = ba.Get(3);
                register.Bit4 = ba.Get(4);
                register.Bit5 = ba.Get(5);
                register.Bit6 = ba.Get(6);
                register.Bit7 = ba.Get(7);
                register.RegisterNr = 6;
                bitArray.Add("PORTB", register);
                return bitArray;
            }
        }
        public bool[,] RegisterBit { //Funktioniert nicht, Fehler unbekannt
            get {
                bool[,] bitArray = new bool[register.Length,8];
                for(int i = 0; i < Register.Length; i++) {
                    for (int j = 0; j < 8; j++) {
                        System.Collections.BitArray ba = new BitArray(new byte[] { Register[i] });
                        bitArray[i ,j] = ba.Get(j);
                    } 
                }
                return bitArray;
            }
            set {
                for (int i = 0; i < value.Length; i++) {
                    for (int j = 0; j < 8; j++) {
                        if (value[i,j]) {
                            Register[i] = (byte)(Register[i] | (1 << j));
                        } else {
                            Register[i] = (byte)(Register[i] & ~(1 << j));
                        }
                    }
                }
                NotifyOfPropertyChange(() => RegisterBit);
                NotifyOfPropertyChange(() => Register);
            }
        }  


        public byte[] Register {
            get {
                return register;
            }
            set {
                register = value;
                NotifyOfPropertyChange(() => Register);
                NotifyOfPropertyChange(() => RegisterBit);
            }
        }

        public ulong Cycles {
            get {
                return cycles;
            }
            set {
                cycles = value;
                berechneTime();
                NotifyOfPropertyChange(() => Cycles);
            }
        }

        public bool Interrupt {
            get {
                return interrupt;
            }

            set {
                interrupt = value;
            }
        }

        public Dictionary<int,String> StackAusgabe {
            get {
                Dictionary<int, String> stackplatz = new Dictionary<int, string>();
                int i = 0;
                foreach (Object obj in stack) {
                    stackplatz.Add(i, obj.ToString());
                    i++;
                }
                return stackplatz;
            }
        }

        public double Frequenz {
            get {
                return frequenz;
            }
            set {
                frequenz = value;
                berechneTime();
                NotifyOfPropertyChange(() => Frequenz);
                NotifyOfPropertyChange(() => TimeInyS);
            }
        }

        public int TimeInyS {
            get {
               
                return timeInyS;
            }
            set {
                timeInyS = value;
                NotifyOfPropertyChange(() => TimeInyS);
            }
        }

        public WhatchdogTimer Wdt {
            get {
                return wdt;
            }

            set {
                wdt = value;
            }
        }
        #endregion
        public Speicher() {
            //gesamtes Register mit 0 initialisieren
                Register = new byte[256];
                byte nullen = Convert.ToByte(0); //0000 0000
                for (int i = 0; i < Register.Length; i++) {
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
            //W Register init
                WRegister = 0;
            //Cycles  auf 0
            Cycles = 0;
            //Stack init
            stack = new Stack(8);
            //psa counter
            psa_counter = 0;
            //Whatchdog Timer
            Wdt = new WhatchdogTimer(this);
            //vergangene Zeit
            TimeInyS = 0;
            //Frequenz
            Frequenz = 1;

        }

        public byte getRegister(int adresse) {
            if (new BitArray(new byte[] { Register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                return Register[adresse + 128];
            } else {
                return Register[adresse];

            } 
        }
        public bool getRegister(int adresse, int bitNumber)
        {
            if (new BitArray(new byte[] { Register[3] }).Get(5))
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
        public bool getRegisterOhneBank(int adresse, int bitNumber) {
                System.Collections.BitArray ba = new BitArray(new byte[] { Register[adresse] });
                return ba.Get(bitNumber);
        }
        public byte getRegisterOhneBank(int adresse) {
                return Register[adresse];
        }

    
    public void setRegister(int adr, int bitNumber, bool wert)
        {
            if(adr == 1 | adr == 5 | adr == 6 | adr == 8 | adr == 9) { //Überprüfung ob TMR0/OPTION_REG | PORTA/TRISA | PORTB/TRISB |EEDATA/EECON1 |EEADR/EECON2 angesprochen wird
                if (new BitArray(new byte[] { Register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                if (wert) {
                        Register[adr + 128] = (byte)(Register[adr + 128] | (1 << bitNumber));
                    } else {
                        Register[adr + 128] = (byte)(Register[adr + 128] & ~(1 << bitNumber));
                    }
                } else {    
                    if (wert) {
                        Register[adr] = (byte)(Register[adr] | (1 << bitNumber));
                    } else {
                        Register[adr] = (byte)(Register[adr] & ~(1 << bitNumber));
                    }
                }
            } else {    //Schreiben in beide Bänke
                if (wert) {
                    Register[adr + 128] = (byte)(Register[adr + 128] | (1 << bitNumber));
                    Register[adr] = (byte)(Register[adr] | (1 << bitNumber));
                } else {
                    Register[adr + 128] = (byte)(Register[adr + 128] & ~(1 << bitNumber));
                    Register[adr] = (byte)(Register[adr] & ~(1 << bitNumber));
                }
            }
            NotifyOfPropertyChange(() => Register);

        }
        public void setRegister(int adr, byte wert) {
            if(adr == 2 | adr == 3 | adr == 4 | adr == 10 | adr == 11) { //Überprüfung ob das Status | PCL | FSR Register gewählt wurde
                Register[adr + 128] = wert;
                Register[adr] = wert;
            } else {
                if(new BitArray(new byte[] { Register[3] }).Get(5)) { //RP0 gesetzt / Welche Bank ist ausgewählt ?
                    Register[adr + 128] = wert;
                } else {
                    Register[adr] = wert;
                }
            }
            NotifyOfPropertyChange(() => Register);
        }

        public void addToTimer(int timeAdd) {
            if (!((Register[0x81] &  0x20)==32) ) {        //T0CS(OPTION_REG<5>) ist leer 
                for (int i = 0; i < timeAdd; i++) {
                    addToTimerHelper();
                }
            }
        }
        public void addToTimerHelper() {
            // Check PSA (1 = Prescaler für WDT (kein TMR0); 0 = Prescaler für TMR0)
            if (!getRegisterOhneBank(0x81,3)){
                // PSA = 0
                //increase With PSA
                int psa_bits = register[0x81] & 7;
                psa_counter++;
                switch (psa_bits) {
                    case 0:
                        if (psa_counter >= 2) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 1:
                        if (psa_counter >= 2) { //wegen Ablauf Programm Nr 7
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 2:
                        if (psa_counter >= 8) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 3:
                        if (psa_counter >= 16) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 4:
                        if (psa_counter >= 32) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 5:
                        if (psa_counter >= 64) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 6:
                        if (psa_counter >= 128) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;
                    case 7:
                        if (psa_counter >= 256) {
                            erhoeheTimer0counter();
                            psa_counter = 0;
                        }
                        break;

                    default:
                        break;

                }
            }else{
                // PSA = 1
                erhoeheTimer0counter();
            }
        }

        private void erhoeheTimer0counter() {
            if (Register[1] == 255) {
                Register[1]++;
                //setzte Interrupt Flag
                setRegister(0x0B, 2, true); //Overflow sets bit T0IF(INTCON < 2 >).
                if (getRegister(0x0B, 5) && getRegister(0x0B, 5)) { //Ueberpruefe ob GIE AND INTCON<5>
                    Interrupt = true;
                    setRegister(0x0B, 7, false); //clear GIE
                }
            } else {
                Register[1]++;
            }
        }

        public void addToCycles(int pCycles)
        {
            Cycles += (ulong) pCycles;
            Wdt.addToWDT(pCycles);
            berechneTime();
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
            int  lastELement = (int)stack.Pop();
            NotifyOfPropertyChange(() => StackAusgabe);
            return  lastELement;
            
        }
        public void pushStack(int addresse) {
            if(stack.Count == 8) {
                stack.Clear();
            }
            stack.Push(addresse);
            NotifyOfPropertyChange(() => StackAusgabe);
        }
        public void setDigitCarryBit(bool wert) {
            setRegister(3, 1, wert);
        }
        private void berechneTime() {
            TimeInyS =(int) (Cycles/ Frequenz*4);
        }

    }
}