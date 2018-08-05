using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommandParser85
{
    class SingleLoopExample
    {
        public void SingleLoop(List<string> list, List<string> new_list, string example_file, string commentPattern, string loopStartCheck, string loopEndCheck, string loopInsidePattern)
        {
            var path = $"{Path.GetDirectoryName(example_file)}\\{Path.GetFileNameWithoutExtension(example_file)}Complete{Path.GetExtension(example_file)}";
            var allText = Regex.Replace(File.ReadAllText(example_file), commentPattern, string.Empty, RegexOptions.Multiline).Trim();

            foreach (var list_item in list.ToList())
            {
                Match mCommentCheck = Regex.Match(list_item, commentPattern, RegexOptions.Singleline);
                Match mLoopstartCheck = Regex.Match(list_item, loopStartCheck, RegexOptions.Singleline);
                Match mLoopInsidePattern = Regex.Match(allText, loopInsidePattern, RegexOptions.Singleline);
                Match mLoopEndCheck = Regex.Match(list_item, loopEndCheck, RegexOptions.Singleline);

                if (mLoopInsidePattern.Success)
                {
                    string times = mLoopInsidePattern.Groups[1].Value;
                    string key = mLoopInsidePattern.Groups[3].Value;
                }

                if (!(mCommentCheck.Success || mLoopstartCheck.Success || mLoopEndCheck.Success))
                    new_list.Add(list_item);

                if (mLoopstartCheck.Success)
                {
                    if (mLoopInsidePattern.Success)
                    {
                        int count = 0;
                        for (int i = 0; i <= count; i++)
                        {
                            count = Convert.ToInt32(mLoopInsidePattern.Groups[1].Value) - 1;
                            var insideloop = mLoopInsidePattern.Groups[3].Value;
                            new_list.Add(insideloop);
                            --count;
                        }
                    }
                }
            }

            //Writing to a new file
            ActionClass.WriteToFile(new_list, path);

        }
    }
}