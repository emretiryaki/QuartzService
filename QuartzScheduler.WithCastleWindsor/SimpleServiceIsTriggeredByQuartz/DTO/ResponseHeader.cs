using System;
using System.Runtime.Serialization;
using SimpleServiceIsTriggeredByQuartz.Enum;

namespace SimpleServiceIsTriggeredByQuartz.DTO
{
    [DataContract]
    public class ResponseHeader
    {
        [DataMember]
        public int ResponseStatus { get; set; }

        [DataMember]
        public string ResponseCode { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }

        [DataMember]
        public DateTime ResponseDateTime { get; set; }

        public ResponseHeader()
        {
            this.ResponseStatus = (int)ResponseStatusValue.Success;
            this.ResponseCode = ((int)Enum.ResponseCode.Success).ToString("d4");
            this.ResponseDateTime = DateTime.Now;
        }
    }
}