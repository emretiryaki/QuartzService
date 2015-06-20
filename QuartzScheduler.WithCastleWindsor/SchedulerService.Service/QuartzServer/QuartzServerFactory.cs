using System;

namespace SchedulerService.Service.QuartzServer
{
    public class QuartzServerFactory {

        public static IQuartzServer CreateServer()
        {
            string typeName = Configuration.ServerImplementationType;

            Type t = Type.GetType(typeName, true);

            //logger.Debug("Creating new instance of server type '" + typeName + "'");
            IQuartzServer retValue = (IQuartzServer)Activator.CreateInstance(t);
            //logger.Debug("Instance successfully created");
            return retValue; ;
        }
    }
}