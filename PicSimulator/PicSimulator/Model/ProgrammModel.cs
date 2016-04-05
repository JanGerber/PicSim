using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSimulator.Model {
    class ProgrammModel {

        private List<int> _opcodes;

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
                    for (int i = 0; i < firstChar.Length; 9) {
                        //char[] gesChar[1]
                    }
                }
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.
            System.Console.ReadLine();
        }

    }
}
