using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace FilmIndex.Host
{
    public class FilmIndexHost
    {
        public async Task Start()
        {
            // 建立 scheduler
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();

            // 建立 Job
            var job = JobBuilder.Create<JobScheduler>()
                .WithIdentity("FilmIndexJob")
                .Build();

            // 建立 Trigger，每秒跑一次
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("FilmIndexJobTrigger")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3600)
                    .RepeatForever())
                .StartAt(DateBuilder.FutureDate(15, IntervalUnit.Second))
                .Build();

            // 加入 ScheduleJob 中
            await scheduler.ScheduleJob(job, trigger);

            // 啟動
            await scheduler.Start();

            Console.ReadKey();
        }
    }
}
