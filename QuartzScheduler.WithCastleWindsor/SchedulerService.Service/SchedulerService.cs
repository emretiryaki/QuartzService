using System;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Castle.Core.Resource;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using SchedulerService.Contract;
using SchedulerService.Contract.Model;
using JobList = SchedulerService.Contract.JobList;

namespace SchedulerService.Service
{
  public  class SchedulerService : ISchedulerService
    {
      public ResponseBase Test(string txt)
      {
          return new ResponseBase();
      }

      public ResponseBase AddAndScheduleJob(string jobType, string jobName, string jobGroupName, string triggerName,
          string triggerGroupName, QuickRepeatIntervals quickRepeatInterval, int intervalValue, int? nTimes)
      {
          if (quickRepeatInterval == QuickRepeatIntervals.None)
              throw new SchedulerServiceError("None is null");
          if (string.IsNullOrEmpty(jobName))
          {
              throw new SchedulerServiceError("JobName is null");
          }
          if (string.IsNullOrEmpty(jobGroupName))
          {
              throw new SchedulerServiceError("JobGroupName is null");
          }
          if (string.IsNullOrEmpty(triggerName))
          {
              throw new SchedulerServiceError("TriggerName is null");
          }
          if (string.IsNullOrEmpty(triggerGroupName))
          {
              throw new SchedulerServiceError("TriggerGroupName is null");
          }

          Type tJob = Resolver.ResolveType(jobType);
          var runSimpleMapTest = GetType().GetMethod("AddAndScheduleGenericJob");
          var runSimpleMapTestForType = runSimpleMapTest.MakeGenericMethod(tJob);
          object[] objects = new object[7];
          objects[0] = jobName.Trim();
          objects[1] = jobGroupName.Trim();
          objects[2] = triggerName.Trim();
          objects[3] = triggerGroupName.Trim();
          objects[4] = quickRepeatInterval;
          objects[5] = intervalValue;
          objects[6] = nTimes;
          var obj = runSimpleMapTestForType.Invoke(this, objects);

          return new ResponseBase();
      }

      public JobList ListJobs()
      {
          //http://stackoverflow.com/questions/12489450/get-all-jobs-in-quartz-net-2-0
          JobList jobList = new JobList();
          jobList.Items = new List<Job>();
          IScheduler scheduler = GetScheduler();
          foreach (var getJobGroupName in scheduler.GetJobGroupNames())
          {
              foreach (JobKey jobkey in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(getJobGroupName)))
              {
                  var job = new Job
                  {
                      JobGroupName = jobkey.Group,
                      JobName = jobkey.Name
                  };

                  job.Triggers = new List<Trigger>(); foreach (ITrigger trigger in scheduler.GetTriggersOfJob(jobkey))
                    {
                        job.Triggers.Add(new Trigger
                                             {
                                                 TriggerGroupName = trigger.Key.Group,
                                                 TriggerName = trigger.Key.Name,
                                                 MayFireAgain = trigger.GetMayFireAgain(),
                                                 NextFireTimeUtc = trigger.GetNextFireTimeUtc(),
                                                 PreviousFireTimeUtc = trigger.GetPreviousFireTimeUtc(),
                                                 StartTimeUtc = trigger.StartTimeUtc,
                                                 EndTimeUtc = trigger.EndTimeUtc,
                                                 UTCNow = DateTime.UtcNow,
                                                 Status = scheduler.GetTriggerState(trigger.Key).ToString()
                                             });
                    }

                    jobList.Items.Add(job);
                }
            }

            return jobList;
              

      }

      public ResponseBase DeleteJob(string jobName, string jobGroupName)
      {
          if (string.IsNullOrEmpty(jobName))
          {
              throw new SchedulerServiceError("JobName is null");
          }
          if (string.IsNullOrEmpty(jobGroupName))
          {
              throw new SchedulerServiceError("JobGroupName is null");
          }
          IScheduler scheduler = GetScheduler();
          JobKey jobKey = new JobKey(jobName.Trim(), jobGroupName.Trim());
          scheduler.DeleteJob(jobKey);
        

          return new ResponseBase();
      }

      public void AddAndScheduleGenericJob<T>(string jobName, string jobGroupName, string triggerName, string triggerGroupName, QuickRepeatIntervals quickRepeatInterval, int intervalValue, int? nTimes) where T : class
      {
          IScheduler scheduler = GetScheduler();

          JobDetailImpl jobDetail = new JobDetailImpl(jobName, jobGroupName, typeof(T));

          ITrigger trigger = null;
          switch (quickRepeatInterval)
          {
              case QuickRepeatIntervals.EverySecond:
                  trigger = TriggerBuilder.Create()
                      .StartNow()
                      .WithIdentity(triggerName, triggerGroupName)
                      .WithSchedule(nTimes.HasValue ? SimpleScheduleBuilder.RepeatSecondlyForTotalCount(nTimes.Value, intervalValue) : SimpleScheduleBuilder.RepeatSecondlyForever(intervalValue))
                      .Build();
                  break;
              case QuickRepeatIntervals.EveryMinute:
                  trigger = TriggerBuilder.Create()
                      .StartNow()
                      .WithIdentity(triggerName, triggerGroupName)
                      .WithSchedule(nTimes.HasValue ? SimpleScheduleBuilder.RepeatMinutelyForTotalCount(nTimes.Value, intervalValue) : SimpleScheduleBuilder.RepeatMinutelyForever(intervalValue))
                      .Build();
                  break;
              case QuickRepeatIntervals.EveryHour:
                  trigger = TriggerBuilder.Create()
                      .StartNow()
                      .WithIdentity(triggerName, triggerGroupName)
                      .WithSchedule(nTimes.HasValue ? SimpleScheduleBuilder.RepeatHourlyForTotalCount(nTimes.Value, intervalValue) : SimpleScheduleBuilder.RepeatHourlyForever(intervalValue))
                      .Build();
                  break;
          }

          scheduler.ScheduleJob(jobDetail, trigger);
          //scheduler.Shutdown();
      }

      public ResponseBase PauseJob(string jobName, string jobGroupName)
      {
          if (string.IsNullOrEmpty(jobName))
          {
              throw new SchedulerServiceError("JobName is null");
          }
          if (string.IsNullOrEmpty(jobGroupName))
          {
              throw new SchedulerServiceError("JobGroupName is null");
          }
          IScheduler scheduler = GetScheduler();
          JobKey jobKey = new JobKey(jobName.Trim(), jobGroupName.Trim());
          scheduler.PauseJob(jobKey);
       

          return new ResponseBase();
      }

      public ResponseBase ResumeJob(string jobName, string jobGroupName)
      {

          if (string.IsNullOrEmpty(jobName))
          {
              throw new SchedulerServiceError("JobName is null");
          }
          if (string.IsNullOrEmpty(jobGroupName))
          {
              throw new SchedulerServiceError("JobGroupName is null");
          }
          IScheduler scheduler = GetScheduler();
          JobKey jobKey = new JobKey(jobName.Trim(), jobGroupName.Trim());
          scheduler.ResumeJob(jobKey);
          //scheduler.Shutdown();

          return new ResponseBase();
      }

      public JobList ListCurrentlyExecutingJobs()
      {
          JobList jobList = new JobList();
          jobList.Items = new List<Job>();
          IScheduler scheduler = GetScheduler();
          var jobs = scheduler.GetCurrentlyExecutingJobs();
          foreach (var j in jobs)
          {
              Job job = new Job
              {
                  JobGroupName = j.JobDetail.Key.Group,
                  JobName = j.JobDetail.Key.Name
              };
              jobList.Items.Add(job);
          }
         

          return jobList;
      }

      public ResponseBase PauseAll()
      {
          IScheduler scheduler = GetScheduler();
          scheduler.PauseAll();
         
          return new ResponseBase();
      }

      public ResponseBase ResumeAll()
      {
          IScheduler scheduler = GetScheduler();
          scheduler.ResumeAll();
          return new ResponseBase();
      }

      public Job GetJobByJobName(string jobName)
      {
          if (string.IsNullOrEmpty(jobName))
          {
              throw new SchedulerServiceError("JobName is null");
          }

          Job job = new Job();
          var jobList = ListJobs();
          if (jobList != null && jobList.Items != null)
          {
              job = jobList.Items.SingleOrDefault(i => i.JobName == jobName.Trim());
          }
          return job;
      }

      internal static IScheduler GetScheduler()
      {
          NameValueCollection configuration = (NameValueCollection)ConfigurationManager.GetSection("quartz");
          ISchedulerFactory sf = new StdSchedulerFactory(configuration);
          return sf.GetScheduler();
      }
    }
}
