using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulator.Model {
    class ProgrammModel {

        private Dictionary<int, int> _opcodes;

        public ProgrammModel(string filePath) {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@filePath);
            while ((line = file.ReadLine()) != null) {
                //System.Console.WriteLine(line);
                char[] firstChar = line.ToCharArray();
                if(char.IsNumber(firstChar[0])) {
                    System.Console.WriteLine(line);
                    string befehlNummer =  firstChar[0].ToString() + firstChar[1].ToString() + firstChar[2].ToString() + firstChar[3].ToString();
                    string befehl =  firstChar[5].ToString() + firstChar[6].ToString() + firstChar[7].ToString() + firstChar[8].ToString();
                    int befehlInt = Int32.Parse(befehl, System.Globalization.NumberStyles.HexNumber);
                    int befehlNummerInt = Int32.Parse(befehlNummer, System.Globalization.NumberStyles.HexNumber);

                    System.Console.WriteLine(befehlNummerInt + "   " + befehlInt);
                    //_opcodes.Add(Int32.Parse(befehlNummer), Int32.Parse(befehl, System.Globalization.NumberStyles.HexNumber));
                 
                }
                counter++;
            }

            file.Close();
            //System.Console.WriteLine(_opcodes.ToString());
            // Suspend the screen.
            System.Console.ReadLine();
        }

        public Dictionary<int, int> Opcodes {
            get {
                return _opcodes;
            }

            set {
                _opcodes = value;
            }
        }
    }
}
