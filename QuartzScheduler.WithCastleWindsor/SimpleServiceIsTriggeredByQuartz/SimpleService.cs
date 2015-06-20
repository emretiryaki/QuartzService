using System;
using SimpleServiceIsTriggeredByQuartz.DTO;

namespace SimpleServiceIsTriggeredByQuartz
{
    public class SimpleService:ISimpleService
    {
        public void OneWaySingleOutput(OneWaySingleOutputRequest request)
        {
            Console.WriteLine("OneWaySingleOutput is running");
        }

        public SingleOutputResponse SingleOutput(SingleOutputRequest singleOutput)
        {
            Console.WriteLine("SingleOutput is running");
            return new SingleOutputResponse
            {
                Time = DateTime.Now.ToString()
            };
        }

      
    }
}