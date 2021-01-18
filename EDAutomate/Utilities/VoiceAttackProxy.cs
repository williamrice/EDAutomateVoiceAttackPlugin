using EDAutomate.Enums;
using System;

namespace EDAutomate.Utilities
{
    /// <summary>
    /// This class is a wrapper for the dynamic vaProxy that is injected by voice attack. This makes it easier to mock the vaProxy for testing purposes.
    /// </summary>
    public class VoiceAttackProxy
    {
        private dynamic _Proxy;

        /// <summary>
        /// A parameterless constructor that is only used in tests. Do not use this in code. There will be no data in _Proxy if you do
        /// </summary>
        public VoiceAttackProxy() { }
        /// <summary>
        /// Constructor used to pass the data from the injected voice attack proxy to this voice attack proxy class
        /// </summary>
        /// <param name="proxy">The proxy that is injected by voice attack</param>
        public VoiceAttackProxy(dynamic proxy)
        {
            _Proxy = proxy;
        }

        /// <summary>
        /// This function gets a text variable that you would set inside the voice attack command
        /// </summary>
        /// <param name="variableName">The name of the variable declared inside voice attack command</param>
        /// <returns></returns>
        public virtual string GetText(string variableName) => _Proxy.GetText(variableName);

        /// <summary>
        /// This function writes a log message to voice attacks log on the application
        /// </summary>
        /// <param name="message">The message you want to display</param>
        /// <param name="color">The color of the block next to your message</param>
        public virtual void WriteToLog(string message, LogColors.LogColor color) => _Proxy.WriteToLog(message, Enum.GetName(typeof(LogColors.LogColor), color));

        /// <summary>
        /// Sets a boolean variable within the voice attack proxy
        /// </summary>
        /// <param name="varname">The name of the variable that you want to set inside voice attack</param>
        /// <param name="b">The boolean value that you want to set the variable to</param>
        public virtual void SetBoolean(string varname, bool b) => _Proxy.SetBoolean(varname, b);

        public virtual void SetText(string varname, string value) => _Proxy.SetText(varname, value);
    }
}