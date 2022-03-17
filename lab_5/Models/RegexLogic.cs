using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_5.Models
{
    public partial class RegexLogic
    {
        public static string FindRegexInText(string txt, string r)
        {
            if (r == String.Empty || r == null)
            {
                return "Exception";
            }

            string Result = "";

            Regex regex = new Regex(r);

            MatchCollection match = regex.Matches(txt);

            foreach (Match x in match)
            {
                Result += (x.Value + "\n");
            }

            return Result;
        }
    }
}
