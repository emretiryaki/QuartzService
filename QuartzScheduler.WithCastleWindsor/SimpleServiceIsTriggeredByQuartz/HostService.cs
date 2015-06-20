namespace SimpleServiceIsTriggeredByQuartz
{
    public class HostService
    {

        public void Start()
        {


            var bootstrap = new Bootstrapper();
            bootstrap.Initialize();

        }

        public void Stop()
        {

        }

      
    }
}