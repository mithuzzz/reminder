using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace reminder
{
    public class Schedular
    {
        public void Start(DateTime date)

        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<Jobclass>().Build();
            ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity("IDGJob", "IDG")
               .StartAt(date)
               .WithPriority(1)
               .Build();
            scheduler.ScheduleJob(job, trigger);

        }
    }
}
