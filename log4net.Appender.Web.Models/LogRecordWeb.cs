using System;

namespace log4net.Appender.Web.Models
{
    public class LogRecordWeb
    {
        public DateTime DateTime { get; set; }
        public string SeverityType { get; set; }
        public string FileName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string LineNumber { get; set; }
        public object Message { get; set; }
    }
}
