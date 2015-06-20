namespace SchedulerService.Service.Json
{
    public interface IJsonSerializer
    {
         string Serialize(object objectToSerialize);
    }
}