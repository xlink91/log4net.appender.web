using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace log4net.Appender.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));
            IUnityContainer container =
                new UnityContainer()
                    .RegisterType<Handler>()
                    .AddNewExtension<Unity.log4net.Log4NetExtension>();
            var handler = container.Resolve<Handler>();
            handler.Execute("Testing appdender.");
        }
    }

    internal class Handler
    {
        protected ILog Log { get; set; }
        
        public Handler(ILog log)
        {
            Log = log;
        }

        public void Execute(string name)
        {
            Log.Info(new Exception($"Info Message!!! {name}"));
            Log.Debug(new Exception($"Debug Message!!! {name}"));
            Log.Error(new Exception($"Error Message!!! {name}"));
        }
    }
}
