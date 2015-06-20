using System.Runtime.Serialization;

namespace SimpleServiceIsTriggeredByQuartz.DTO
{
    [DataContract]
    public class SingleOutputResponse
    {
        [DataMember]
        public string Time { get; set; }
    }
}