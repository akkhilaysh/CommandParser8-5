using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommandParser85
{
    class NoLoopExample
    {
        public void NoLoop(List<string> list, List<string> new_list, string example_file, string commentPattern)
        {
            var path = $"{Path.GetDirectoryName(example_file)}\\{Path.GetFileNameWithoutExtension(example_file)}Complete{Path.GetExtension(example_file)}";
            
            foreach (var list_item in list)
            {
                Match commentCheck = Regex.Match(list_item, commentPattern, RegexOptions.Singleline);

                if (!commentCheck.Success)
                    new_list.Add(list_item);
            }

            //Writing to a new file
            ActionClass.WriteToFile(new_list, path);
        }
    }
}
