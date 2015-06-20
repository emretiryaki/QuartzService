using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace SchedulerService.Service
{
    public class HostService
    {

        private static string _serviceName;

        private static string _serviceDisplayName;
       

        public void Start()
        {
            //try
            //{
            //    AppDomain currentAppDomain = AppDomain.CurrentDomain;
            //    currentAppDomain.AssemblyResolve += AssemblyResolve;
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine("An error occured at AssemblyResolve");
            //    Console.ReadKey();
            //    return;
            //}

            try
            {
                _serviceName = ConfigurationManager.AppSettings["ServiceName"];
                _serviceDisplayName = ConfigurationManager.AppSettings["ServiceDisplayName"];
            }
            catch (Exception exc)
            {

                Console.WriteLine(exc.Message);
                Console.ReadKey();
                return;
            }

            if (String.IsNullOrEmpty(_serviceName) || String.IsNullOrEmpty(_serviceDisplayName))
            {
                Console.WriteLine("ServiceName and/or ServiceDisplayName missing in config file.");
                Console.ReadKey();
                return;
            };

            Bootstrapper.Initialize();
            IScheduler scheduler = SchedulerService.GetScheduler();
           Console.WriteLine("Quartz Scheduler IsStarted : {0} !", scheduler.IsStarted);
        }

        public void Stop()
        {

        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                Console.WriteLine("Resolving {0}...", args.Name);
                Assembly assembly = Resolver.ResolveAssembly(args.Name);
                if (assembly != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} resolved successfully...", args.Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to resolve {0}...", args.Name);
                    Console.ResetColor();
                }
                return assembly;
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    Console.WriteLine(exSub.Message);
                    if (exSub is FileNotFoundException)
                    {
                        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            Console.WriteLine(exFileNotFound.FusionLog);
                        }
                    }
                }
                Console.ResetColor();
                throw;
            }
        }
    }
}
