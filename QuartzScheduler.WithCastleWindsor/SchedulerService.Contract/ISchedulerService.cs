using System.ServiceModel;
using SchedulerService.Contract.Model;

namespace SchedulerService.Contract
{
    [ServiceContract]
    public interface ISchedulerService
    {
        [OperationContract]
        ResponseBase Test(string txt);

        [OperationContract]
        ResponseBase AddAndScheduleJob(string jobType, string jobName, string jobGroupName, string triggerName, string triggerGroupName, QuickRepeatIntervals quickRepeatInterval, int intervalValue, int? nTimes);

        [OperationContract]
        JobList ListJobs();

     
        [OperationContract]
        ResponseBase DeleteJob(string jobName, string jobGroupName);


        [OperationContract]
        ResponseBase PauseJob(string jobName, string jobGroupName);

        [OperationContract]
        ResponseBase ResumeJob(string jobName, string jobGroupName);

        [OperationContract]
        JobList ListCurrentlyExecutingJobs();

        [OperationContract]
        ResponseBase PauseAll();

        [OperationContract]
        ResponseBase ResumeAll();

        [OperationContract]
        Job GetJobByJobName(string jobName);

    }
}
