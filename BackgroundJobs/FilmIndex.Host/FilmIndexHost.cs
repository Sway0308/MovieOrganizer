using FilmIndex.Job;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FilmIndex.Host
{
    public class FilmIndexHost
    {
        public void Start()
        {
            Console.WriteLine("FilmIndexHost Starting...");
            var appDataPath = ConfigurationManager.AppSettings["ExportPath"];
            Console.WriteLine($"AppDataPath: {appDataPath}");
            var filmPaths = new List<string>();
            var searchPaths = ConfigurationManager.GetSection("indexInfo/searchPath") as NameValueCollection;
            for (int i = 0; i < searchPaths.Count; i++)
            {
                filmPaths.Add(searchPaths[i]);
                Console.WriteLine($"SearchPath: {searchPaths[i]}");
            }

            var paths = new List<string>();
            var samplePaths = ConfigurationManager.GetSection("indexInfo/samplePath") as NameValueCollection;
            for (int i = 0; i < samplePaths.Count; i++)
            {
                paths.Add(samplePaths[i]);
                Console.WriteLine($"SamplePath: {samplePaths[i]}");
            }

            var indexJob = new IndexJob { AppDataPath = appDataPath, FilmPaths = filmPaths, SamplePaths = paths };
            Console.WriteLine($"Start Indexing...");
            var sw = new Stopwatch();
            sw.Start();
            indexJob.ExecuteJob();
            sw.Stop();
            Console.WriteLine($"End Indexing...");
            Console.WriteLine($"elapse time: {sw.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        public async Task StartScheduleJob()
        {
            try
            {
                // 建立 scheduler
                var factory = new StdSchedulerFactory();
                var scheduler = await factory.GetScheduler();

                // 建立 Job
                var job = JobBuilder.Create<IndexJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // 建立 Trigger，每秒跑一次
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(1)
                        .RepeatForever())
                    .Build();

                // 加入 ScheduleJob 中
                await scheduler.ScheduleJob(job, trigger);

                // 啟動
                await scheduler.Start();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}
