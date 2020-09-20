using System;
using System.Windows.Forms;

namespace EDAutomate
{
    public class EnumParser
    {
        private static string ParseStringToMatchEnum(string incoming)
        {
            return incoming.Replace(" ", "").Replace("-", "");
        }

        public static Enum ParseStringToEnum<T>(dynamic vaProxy, string varName, Type enumType) where T : Enum
        {
            MessageBox.Show(vaProxy.GetType().ToString());
            Enum result = null;
            string incoming = vaProxy.GetText(varName);
            string parsed = ParseStringToMatchEnum(incoming);
            vaProxy.WriteToLog($"{parsed} from inside parse", "purple");


            try
            {
                result = (T)Enum.Parse(enumType, parsed, true);
            }
            catch (Exception e)
            {
                vaProxy.WriteToLog($"Failed to find {incoming}: Parsing Error occurred", "red");

            }


            return result;
        }
    }
}
