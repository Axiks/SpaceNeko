using EntityFrameworkCore.Triggered;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;

namespace NekoSpace.Core.Triggers
{
    public class AddMediaTrigger : IBeforeSaveTrigger<MediaEntity>
    {
        readonly ApplicationDbContext _applicationDbContext;

        public AddMediaTrigger(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task BeforeSave(ITriggerContext<MediaEntity> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                var aa = 0;
            }

            return Task.CompletedTask;
        } 
    }
}
