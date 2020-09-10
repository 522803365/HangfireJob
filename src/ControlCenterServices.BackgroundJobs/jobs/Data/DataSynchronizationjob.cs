
using ControlCenterServices.Domain.Configurations;
using Hangfire;
using Hangfire.Logging;
using Hangfire.MySql.Core;
using log4net;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ControlCenterServices.BackgroundJobs.jobs.Data
{
    public class DataSynchronizationjob : IBackgroundJob
    {

        private readonly log4net.ILog _log;
        public DataSynchronizationjob()
        {
            _log = LogManager.GetLogger(typeof(TestJob));
        }

        public async Task ExecuteAsync()
        {
            var storage = new MySqlStorage(AppSettings.ConnectionStrings);
            //if (AppSettings.EnableDb == "MySql")
            //{
            //    var storage = new MySqlStorage(AppSettings.ConnectionStrings);
            //    service.UseDataSynchronizationjob(storage);
            //}

            var _storage = storage as MySqlStorage;
            GlobalConfiguration.Configuration.UseStorage(storage as MySqlStorage);
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Hangfire  AddOrUpdate任务"), "1/5 * * * * *", TimeZoneInfo.Local, "queue1");
            BackgroundJobServer jobServer = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                Queues = new string[] { "queue1", "queue2" },
                ServerName = "ControlCenterServices",
                WorkerCount = 1
            }, _storage);
            await jobServer.WaitForShutdownAsync(CancellationToken.None); 
        }
    }
}
