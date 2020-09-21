using EDAutomate.Enums;
using System;

namespace EDAutomate.Utilities
{
    public class EnumParser
    {
        /// <summary>
        /// Parses the incoming string sent from voice attack variable within the proxy to match the enum representation of the variable. 
        /// Removes dashes and all white spaces from the command in order to achieve a match
        /// </summary>
        /// <typeparam name="T">Enum to match the parsed string to</typeparam>
        /// <param name="vaProxy">VoiceAttackProxy object</param>
        /// <param name="varName">The variable name that is passed from Voice Attack via proxy</param>
        /// <param name="enumType">The typeof() enum that you are parsing. Should match T</param>
        /// <returns>An enum that matches the string received from the voice attack variable set inside the voice attack command</returns>
        public static Enum ParseStringToEnum<T>(VoiceAttackProxy vaProxy, string varName, Type enumType) where T : Enum
        {
            Enum result = null;
            string incoming = vaProxy.GetText(varName);
            string parsed = ParseStringToMatchEnum(incoming);

            try
            {
                result = (T)Enum.Parse(enumType, parsed, true);
            }
            catch (Exception e)
            {
                vaProxy.WriteToLog($"Failed to find {incoming}: Parsing Error occurred", LogColors.LogColor.red);
            }

            return result;
        }
        /// <summary>
        /// Helper function that removes all white spaces and dashes from the passed string
        /// </summary>
        /// <param name="incoming">String that you want to remove white spaces and dashes from</param>
        /// <returns></returns>
        private static string ParseStringToMatchEnum(string incoming)
        {
            return incoming.Replace(" ", "").Replace("-", "");
        }

    }
}
