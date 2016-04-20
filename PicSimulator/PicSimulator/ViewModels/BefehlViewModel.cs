using PicSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PicSimulator.ViewModel {  //Namespace stellt sowas wie ein Package dar
    class BefehlViewModel  : Caliburn.Micro.Screen {  //Befehl ist ein Interface, das bedeutet es stellt die Form für weitere Objekte dar
        protected bool breakpoint = false;
        protected int programmCounter;
        protected string befehlsName;
        protected Brush background;


        public virtual int ausfuehren(ref Speicher speicher) {
             throw new NotImplementedException(); }
        public string BefehlsName {
            get {
                return befehlsName;
            }
            set {
                this.befehlsName = value;
                NotifyOfPropertyChange(() => BefehlsName);
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
                NotifyOfPropertyChange(() => Breakpoint);
            }
        }
        public int ProgrammCounter {
            get {
                return programmCounter;
            }
            set {
                this.programmCounter = value;
                NotifyOfPropertyChange(() => ProgrammCounter);
            }
        }

        public Brush Background {
            get {
                System.Console.WriteLine("GetBackground: " + BefehlsName);
                return background;
            }
            set {
                background = value;
                NotifyOfPropertyChange(() => Background);
            }
        }
    }
}