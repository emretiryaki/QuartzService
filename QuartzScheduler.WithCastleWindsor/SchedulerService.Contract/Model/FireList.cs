using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchedulerService.Contract.Model
{
    [DataContract]
    public class FireList : ResponseBase
    {
        [DataMember]
        public List<string> Items { get; set; }
    }
}
