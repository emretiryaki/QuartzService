using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Common.Logging;
using Quartz;
using SimpleServiceIsTriggeredByQuartz.DTO;

namespace SchedulerJob
{
    [DisallowConcurrentExecution]
    public class SingleOutputJob : IJob
    {
        private readonly ILog _logger;

        public SingleOutputJob()
        {
            _logger = LogManager.GetLogger(GetType());
        }
        public void Execute(IJobExecutionContext context)
        {
            _logger.Info("SingleOutputJob method fired");
            var serviceClientFactory = new ServiceClientFactory();
            var singleOutputRequest = new SingleOutputRequest();
            serviceClientFactory.Run(a => a.SingleOutput(singleOutputRequest));
            _logger.Info("SingleOutputJob method fired completed...");
        }
    }
}
