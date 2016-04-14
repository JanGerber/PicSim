using PicSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PicSimulator.Model {  //Namespace stellt sowas wie ein Package dar
    interface Befehl {  //Befehl ist ein Interface, das bedeutet es stellt die Form für weitere Objekte dar
        int ausfuehren(ref Speicher speicher);
        string BefehlsName {
            get;
        }
        string Parameter1 {
            get;
        }
        string Parameter2 {
            get;
        }
       
        bool Breakpoint {
            get;
            set;
        }
    }
}