using System.Linq;

namespace Logger
{
        public class XsvFormatter : ILogFormatter
        {

        protected XsvFormatter(char v)
        {
            this.v = v;
        }

        public char v { get; set; }

        private static XsvFormatter _Instance;
        

        public static XsvFormatter Instance => _Instance ?? (_Instance = new XsvFormatter(','));

            public string Header =>
                 $"level{v}date{v}source{v}threadId{v}" +
                  $"ProcessId{v}message{v}name:value pairs";

            public string Footer => string.Empty;

            public string FileExtention => "log";

            public virtual string Format(LogEntry entry)
            {
                return $"{entry.Level.ToString()}{v}{entry.DateTime.ToString()}{v}{entry.Source.ToString()}{v}" +
                       $"{entry.ThreadId.ToString()}{v}{entry.ProcessId}{v}{entry.Message}{v}" +
                        string.Join($"{v}", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
            }
        }
}