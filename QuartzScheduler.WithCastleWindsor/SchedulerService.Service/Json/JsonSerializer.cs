using Newtonsoft.Json;

namespace SchedulerService.Service.Json
{
    public class JsonSerializer :  IJsonSerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return  JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}