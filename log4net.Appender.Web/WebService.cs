using log4net.Appender.Web.Models;
using log4net.Core;
using System.Collections.Generic;
using log4net.Appender.Web.Helpers;
using System.Net.Http;
using static Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json;
using System;
using System.Text;

namespace log4net.Appender.Web
{
    public class WebService : AppenderSkeleton
    {
        public string Uri { get; set; }
        public string Headers { get; set; }
        
        public WebService()
        {
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                var logRecordWeb = 
                    loggingEvent
                        .MapTo();
                IList<HeaderWeb> headerWebList =
                    Headers
                    .GetHeaders();
                var httpClient = new HttpClient();
                foreach (var header in headerWebList)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                StringContent httpContent =
                    new StringContent(SerializeObject(logRecordWeb), Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(Uri, httpContent).Result;
            }catch(Exception ex) 
            {
                System.IO.File.WriteAllText("WebAppender.txt", ex.ToString());
            }
        }
    }
}
