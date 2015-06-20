using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchedulerService.Contract.Model
{
    [DataContract]
    public class JobList : ResponseBase
    {
        [DataMember]
        public List<Job> Items { get; set; }
    }
}