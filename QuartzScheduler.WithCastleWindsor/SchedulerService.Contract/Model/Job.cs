using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchedulerService.Contract.Model
{
    [DataContract]
    public class Job : ResponseBase
    {
        [DataMember]
        public string JobName { get; set; }
        [DataMember]
        public string JobGroupName { get; set; }
        [DataMember]
        public List<Trigger> Triggers { get; set; }
    }
}