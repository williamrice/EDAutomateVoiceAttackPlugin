namespace EDAutomate 
{
    public class Proxy
    {
        private dynamic _Proxy;

        public Proxy() { }

        public Proxy(dynamic proxy)
        {
            _Proxy = proxy;
        }

        public virtual string GetText(string variableName) => _Proxy.GetText(variableName);

        public virtual void WriteToLog(string message, string color) => _Proxy.WriteToLog(message, color);
        public virtual void SetBoolean(string message, bool b) => _Proxy.WriteToLog(message, b);
    }
}