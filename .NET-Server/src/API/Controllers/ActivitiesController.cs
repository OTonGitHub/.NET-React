using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet] // ~/api/activities
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        Task.Delay(1000).Wait();
        return await Mediator.Send(new Listie.Query());
    }

    [HttpGet("{id}")] // ~/api/activities/GUID
    public async Task<ActionResult<Activity>> GetActivity(Guid id) // must match Root Parameter
    {
        Task.Delay(1000).Wait();
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    // ApiController inheritence will cause the param here, "Activity" to be searched for
    // in pattern  matching, from the body of the request, and will pick it up automatically.
    // [FromBody] is a hint, not necessary
    // can combine with [FromRoute] maybe and match root param.
    public async Task<IActionResult> CreateActivity(Activity activity)
    {
        // In Earlier versions, something is returned here and be wrapped in Ok(), now its void.
        await Mediator.Send(new Create.Command { Activity = activity });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity([FromBody] Activity activity, [FromRoute] Guid id)
    {
        activity.Id = id;
        await Mediator.Send(new Edit.Command { Activity = activity });
        return Ok();
    }
}