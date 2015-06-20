using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;

namespace SimpleServiceIsTriggeredByQuartz
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<HostService>(s =>                      
                {
                    s.ConstructUsing(name => new HostService()); 
                    s.WhenStarted(tc => tc.Start());             
                    s.WhenStopped(tc => tc.Stop());              
                });
                x.RunAsLocalSystem();

                x.SetDescription("Simple Service Is Triggered By Quartz");
                x.SetDisplayName("SimpleService");
                x.SetServiceName("SimpleService");                       
            });         
        }
    }
}
