using API.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controller;

public class ActivitiesController(DataContext ctx) : BaseApiController
{
    // if not using primary constructor -> ctor assign _this.ctx
    private readonly DataContext _ctx = ctx;

    [HttpGet] // ~/api/activities
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        Task.Delay(1000).Wait();
        return await _ctx.Activities.ToListAsync();
    }

    [HttpGet("{id}")] // ~/api/activities/GUID
    public async Task<ActionResult<Activity>> GetActivity(Guid id) // must match Root Parameter
    {
        Task.Delay(1000).Wait();
        return await _ctx.Activities.FindAsync(id);
    }
}