using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;
using Quartz;
using Quartz.Impl;

namespace SchedulerService.Service.QuartzServer
{
    public class QuartzServer : IQuartzServer
    {
        private ISchedulerFactory schedulerFactory;
        private IScheduler scheduler;

        public QuartzServer()
        {
            
        }

        protected virtual IScheduler Scheduler
        {
            get { return scheduler; }
        }

        public virtual void Initialize()
        {
            try
            {
                schedulerFactory = CreateSchedulerFactory();
                scheduler = GetScheduler();
            }
            catch (Exception exc)
            {
                Console.Write("Error {0}",exc.Message);
                throw;
            }
        }

        protected virtual IScheduler GetScheduler()
        {

            NameValueCollection configuration = (NameValueCollection)ConfigurationManager.GetSection("quartz");
            ISchedulerFactory sf = new StdSchedulerFactory(configuration);
            return sf.GetScheduler();
          
        }

        protected virtual ISchedulerFactory CreateSchedulerFactory()
        {
            return new StdSchedulerFactory();
        }

    
        public virtual void Start()
        {
            try
            {
                scheduler.Start();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.Write("Error {0}", ex.Message);
                
            }

           
        }

        public virtual void Stop()
        {
            scheduler.Shutdown(true);
          
        }

        public virtual void Dispose()
        {
           
        }

        public virtual void Pause()
        {
            scheduler.PauseAll();
        }

        public virtual void Resume()
        {
            scheduler.ResumeAll();
        }

       
    }
}