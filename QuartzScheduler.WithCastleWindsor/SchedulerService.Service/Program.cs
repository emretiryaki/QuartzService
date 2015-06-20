using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace SchedulerService.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogWriterFactory.Use("log4net.config");
            HostFactory.Run(x =>
            {
                x.Service<HostService>(s =>
                {
                    s.ConstructUsing(name => new HostService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                     
                });
                x.RunAsLocalSystem();
                x.SetDescription("Scheduler Service");
                x.SetDisplayName("SchedulerService");
                x.SetServiceName("SchedulerService");
            });
        }
    }
}
