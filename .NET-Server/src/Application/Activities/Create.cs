using Domain;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Create
{
    public class Command : IRequest // <Activity> : Return Type Not Needed As Command Do Not Return Anything.
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(DataContext ctx) : IRequestHandler<Command>
    {
        private readonly DataContext _ctx = ctx;

        // used to be Task<Unit> as in Unit with no value just to notify API, maybe not used in new version.
        // updated for MediatR 12. : Depending on Line 9.
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            _ctx.Activities.Add(request.Activity); // AddAsync not used, as database operation, just tracking here.
            // not sure what the token does here either yet.
            await _ctx.SaveChangesAsync(cancellationToken); // why not just save in one go above?
        }
    }
}
