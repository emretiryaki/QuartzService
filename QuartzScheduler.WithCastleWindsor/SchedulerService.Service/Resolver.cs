using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;

namespace SchedulerService.Service
{
    public class Resolver
    {
        internal static Type ResolveType(string jobType)
        {
            List<Assembly> aList = new List<Assembly>();
            string path = ConfigurationManager.AppSettings["AssemblyPath"];
            if (path == null)
                throw new SchedulerServiceError("AssemblyPath is missing in config file.");
            if (!path.EndsWith(@"\"))
                path = path + @"\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.dll");

            foreach (FileInfo fileInfo in fileInfos)
            {
                aList.Add(Assembly.LoadFile(fileInfo.FullName));
            }
            var jobAssembly = aList.SingleOrDefault(a => a.FullName.Contains("SchedulerJob"));

            if (jobAssembly != null)
            {
                var jobs = jobAssembly.GetTypes().Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IJob))).ToList();
                 Type tJob = jobs.SingleOrDefault(t => t.Name == jobType);
                return tJob;
            }
            else
            {
                return null;
            }
        }

        internal static Assembly ResolveAssembly(string assemblyName)
        {
          
            List<Assembly> aList = new List<Assembly>();
            string path = ConfigurationManager.AppSettings["AssemblyPath"];
            if (path == null)
                throw new SchedulerServiceError("AssemblyPath is missing in config file.");
            if (!path.EndsWith(@"\"))
                path = path + @"\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.dll");

            try
            {
                foreach (FileInfo fileInfo in fileInfos)
                {
                    var asm = Assembly.LoadFile(fileInfo.FullName);
                    aList.Add(asm);
                }
            }
            catch (Exception)
            {

                throw;

            }
            Assembly assembly = aList.SingleOrDefault(a => a.FullName.Split(',')[0].Trim().ToLower() == assemblyName.Split(',')[0].Trim().ToLower());
            if (assembly == null && !assemblyName.Contains("Quartz.XmlSerializers"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(assemblyName + " | not found by Resolver. Check jobs folder!");
                Console.ResetColor();
           
            }
            return assembly;
        }
    }
}
