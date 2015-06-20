using System.Collections.Generic;
using System.Runtime.Serialization;
using SchedulerService.Contract.Model;

namespace SchedulerService.Contract
{
    [DataContract]
    public class JobList :ResponseBase
    {
        [DataMember]
        public List<Job> Items { get; set; }
    }
}