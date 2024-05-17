using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class Listie
{
    public class Query : IRequest<List<Activity>> { }

    public class Handler(DataContext ctx, ILogger<Listie> logger) : IRequestHandler<Query, List<Activity>>
    {
        private readonly DataContext _ctx = ctx;
        private readonly ILogger<Listie> _logger = logger;
        // Request Handler Must Implement Handle Method.
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            // cancellation token must be passed from API, as request is started there.
            // application handler is not where request is sitting at,
            // request has contacted the API controller via HTTP request, API controller passes off to application via Handler.
            // so need to pass from API controller to handler.

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(1000, cancellationToken);
                    _logger.LogCritical("Task {LoopCount} Has Completed", i);
                }
            }
            catch (System.Exception exc)
            {
                _logger.LogError(exc, "Task Was Cancelled: {Exception}", exc);
            }

            return await _ctx.Activities.ToListAsync(cancellationToken);
        }
    }
}