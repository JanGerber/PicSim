using PicSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulator.Model {
    interface Befehl {
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
    }
}