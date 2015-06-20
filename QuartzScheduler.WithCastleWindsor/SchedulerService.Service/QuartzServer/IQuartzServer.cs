namespace SchedulerService.Service.QuartzServer
{
    public interface IQuartzServer
    {
        void Initialize();

       
        void Start();

      
        void Stop();

      
        void Pause();

     
        void Resume();
    }
}