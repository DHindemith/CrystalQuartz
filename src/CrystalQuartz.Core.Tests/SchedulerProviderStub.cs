namespace CrystalQuartz.Core.Tests
{
    using Quartz;
    using SchedulerProviders;
    using System.Threading.Tasks;

    public class SchedulerProviderStub : ISchedulerProvider
    {
        private readonly IScheduler _scheduler;

        public SchedulerProviderStub(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public SchedulerProviderStub()
        {
        }

        public void Init()
        {
        }

        public IScheduler Scheduler
        {
            get { return _scheduler; }
            set { }
        }
    }
}