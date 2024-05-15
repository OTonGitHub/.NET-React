
using MediatR;
using Persistence;

namespace Application.Activities;

public class Delete
{
    public class Command : IRequest
    {
        public required Guid Id {get; set;}
    }

    public class Handler(DataContext ctx) : IRequestHandler<Command>
    {
        private readonly DataContext _ctx = ctx;
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await _ctx.Activities.FindByIdAsync(request.Id, cancellationToken);
            if(activity != null)
            {
                _ctx.Activities.Remove(activity);
                await _ctx.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}