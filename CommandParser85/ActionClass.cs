using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParser85
{
    class ActionClass
    {
        public static void WriteToFile(List<string> new_list, string path)
        {
            foreach (var list_item1 in new_list)
            {
                File.AppendAllText(path, list_item1 + Environment.NewLine);
            }
        }
    }
}
