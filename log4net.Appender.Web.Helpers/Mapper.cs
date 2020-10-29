using log4net.Appender.Web.Models;
using log4net.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace log4net.Appender.Web.Helpers
{
    public static class Mapper
    {
        public static LogRecordWeb MapTo(this LoggingEvent loggingEvent)
        {
            var logRecordWeb = new LogRecordWeb
            {
                ClassName = loggingEvent.LocationInformation.ClassName,
                DateTime = loggingEvent.TimeStamp,
                FileName = loggingEvent.LocationInformation.FileName,
                LineNumber = loggingEvent.LocationInformation.LineNumber,
                MethodName = loggingEvent.LocationInformation.MethodName,
                SeverityType = loggingEvent.Level.Name,
                Message = loggingEvent.MessageObject.ToString()
            };

            return logRecordWeb;
        }
    
        public static IList<HeaderWeb> GetHeaders(this string headerAsString)
        {
            var headerSplitted = headerAsString.Split(';').ToArray();
            IList<HeaderWeb> headerList = new List<HeaderWeb>();
            foreach (var header in headerSplitted)
            {
                var _header = header.Split('=');
                if (_header.Length != 2)
                    continue;
                headerList.Add(new HeaderWeb(_header[0], _header[1]));
            }
            return headerList;
        }
    }
}
