using PicSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PicSimulator.Model {  //Namespace stellt sowas wie ein Package dar
    class Befehl {  //Befehl ist ein Interface, das bedeutet es stellt die Form für weitere Objekte dar
        protected bool breakpoint = false;
        protected int programmCounter;
        protected string befehlsName;

        public virtual int ausfuehren(ref Speicher speicher) {
             throw new NotImplementedException(); }
        public string BefehlsName {
            get {
                return befehlsName;
            }
            set {
                this.befehlsName = value;
            }
        }
        public virtual string Parameter1 {
            get;
        }
        public virtual string Parameter2 {
            get;
        }

        public bool Breakpoint {
            get {
                return breakpoint;
            }

            set {
                this.breakpoint = value;
            }
        }
        public int ProgrammCounter {
            get {
                return programmCounter;
            }
            set {
                this.programmCounter = value;
            }
        }
    }
}