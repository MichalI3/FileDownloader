using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloader
{
    static class StringHelper
    {
        public static string[] GetUntilOrEmpty(this string text, string stopAt = ";")//create list of separated strings
        {
            string[] subs = text.Split(stopAt);
            return subs;
        }
    }
}
