using System.ServiceModel;
using SimpleServiceIsTriggeredByQuartz.DTO;

namespace SimpleServiceIsTriggeredByQuartz
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract(IsOneWay = true)]
        void OneWaySingleOutput(OneWaySingleOutputRequest request);


        [OperationContract]
        SingleOutputResponse SingleOutput(SingleOutputRequest singleOutput);

       
    }
}