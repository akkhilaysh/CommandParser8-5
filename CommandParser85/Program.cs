using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommandParser85
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleLoopFilePath = @"K:\SingleLoopExample.txt";
            string readAllText = File.ReadAllText(singleLoopFilePath);

            List<string> list = new List<string>(Regex.Split(readAllText, Environment.NewLine));
            List<string> new_list = new List<string>();

            var commentPattern = @"\s*^(#.+)";
            var loopStartCheck = @"[^\n]*?loop \d[^\n]*";
            var loopEndCheck = @"[^\n]*?endloop[^\n]*";
            var loopInsidePattern = @"[^\n]*?loop (\d)(.*?)([A-Za-z0-9\-](.*?))endloop[^\n]*";
            
            NoLoopExample nle = new NoLoopExample();
            SingleLoopExample slc = new SingleLoopExample();

            //nle.NoLoop(list,  new_list, singleLoopFilePath, commentPattern);
            slc.SingleLoop(list, new_list, singleLoopFilePath, commentPattern, loopStartCheck, loopEndCheck, loopInsidePattern);
        }

        
    }
}
