using System.Runtime.Serialization;

namespace SimpleServiceIsTriggeredByQuartz.DTO
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember]
        public ResponseHeader ResponseHeader { get; set; }

        public ResponseBase()
        {
            this.ResponseHeader = new ResponseHeader();
        }
    }
}