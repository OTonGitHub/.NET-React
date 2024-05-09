using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;

public class Listie
{
    public class Query : IRequest<List<Activity>> { }

    public class Handler(DataContext ctx) : IRequestHandler<Query, List<Activity>>
    {
        private readonly DataContext _ctx = ctx;
        // Request Handler Must Implement Handle Method.
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _ctx.Activities.ToListAsync();
        }
    }
}