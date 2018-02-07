﻿
namespace CrystalQuartz.Application.Comands
{
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;
    using Quartz.Impl.Matchers;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeleteGroupCommand : AbstractOperationCommand<GroupInput>
    {
        public DeleteGroupCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task PerformOperation(GroupInput input)
        {
            var keys = await Scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(input.Group));
            await Scheduler.DeleteJobs(keys.ToList());
        }
    }
}