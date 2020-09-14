using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDAutomate
{
    class ModuleParser
    {
        public static string ParseModuleName(dynamic vaProxy)
        {
            string name = vaProxy.GetText("moduleVariable");
            var parsed = name.Replace("one ", "1").Replace("two ", "2").Replace("three ", "3").Replace("four ", "4").Replace("five ", "5").Replace("six ", "6").Replace("seven ", "7").Replace("eight ", "8").Replace("nine ", "9");

            vaProxy.WriteToLog($"{parsed}", "orange");
            return parsed;

        }
    }
}
