using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Edit
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(DataContext ctx) : IRequestHandler<Command>
    {
        private readonly DataContext _ctx = ctx;
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _ctx.Activities.FindByIdAsync(request.Activity.Id, cancellationToken);
            ActivityMapper.UpdateActivity(request.Activity, activity);

            _ctx.Update(activity);
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}