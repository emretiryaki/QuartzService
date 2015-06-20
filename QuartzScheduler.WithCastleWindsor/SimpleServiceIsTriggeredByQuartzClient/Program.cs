using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleServiceIsTriggeredByQuartz.DTO;

namespace SimpleServiceIsTriggeredByQuartzClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //You must run SimpleServiceIsTriggeredByQuartz with Debug - Start New Instance
            var serviceClientFactory = new ServiceClientFactory();
            var singleOutputRequest = new SingleOutputRequest();
            var oneWaySingleOutputRequest = new OneWaySingleOutputRequest();
            serviceClientFactory.Run(a => a.SingleOutput(singleOutputRequest));
            serviceClientFactory.Run(a => a.OneWaySingleOutput(oneWaySingleOutputRequest));
        }
    }
}
