using System.Threading.Tasks;

namespace CrystalQuartz.Web.Demo
{
    using System;
    using Quartz;

    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello, CrystalQuartz!");
            return Task.CompletedTask;
        }
    }
}