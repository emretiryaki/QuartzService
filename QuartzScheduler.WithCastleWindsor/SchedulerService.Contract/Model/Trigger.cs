using System;
using System.Runtime.Serialization;

namespace SchedulerService.Contract.Model
{
    [DataContract]
    public class Trigger
    {
        [DataMember]
        public string TriggerName { get; set; }
        [DataMember]
        public string TriggerGroupName { get; set; }
        [DataMember]
        public bool MayFireAgain { get; set; }
        [DataMember]
        public DateTime UTCNow { get; set; }
        [DataMember]
        public DateTimeOffset? NextFireTimeUtc { get; set; }
        [DataMember]
        public DateTimeOffset? PreviousFireTimeUtc { get; set; }
        [DataMember]
        public DateTimeOffset? StartTimeUtc { get; set; }
        [DataMember]
        public DateTimeOffset? EndTimeUtc { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}