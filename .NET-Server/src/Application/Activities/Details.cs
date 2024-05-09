#nullable disable

namespace Application.Activities;

using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

public class Details
{
    public class Query : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public class Handler(DataContext ctx) : IRequestHandler<Query, Activity>
    {
        private readonly DataContext _ctx = ctx;
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            // tutorial passes just request ID, cancellation token recommended by linter,
            // seems to have something to do with cancelling async methods that may block.
            return await _ctx.Activities.FindByIdAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}