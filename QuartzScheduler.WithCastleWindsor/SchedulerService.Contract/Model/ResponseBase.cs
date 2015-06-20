using System.Runtime.Serialization;

namespace SchedulerService.Contract.Model
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public string ResponseCode { get; set; }
        [DataMember]
        public string ResponseText { get; set; }
    }
}