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

    [HttpGet("{id}")] // ~/api/activities/GUID
    // returns 204 no content if item with key not found is not handled, becayuse:
    // -> FindAsync returns null, which is returned by mediator, there is no error, so 20X, with nothing in the body, resulting in 204.
    public async Task<ActionResult<Activity>> GetActivity(Guid id) // must match Root Parameter
    {
        Task.Delay(1000).Wait();
        return await Mediator.Send(new Details.Query { Id = id });
    }


    [HttpPut("{id}")]
    // Omitted Seperate Patch Request - Personal Design Choice.
    public async Task<IActionResult> EditActivity([FromBody] Activity activity, [FromRoute] Guid id)
    {
        activity.Id = id;
        await Mediator.Send(new Edit.Command { Activity = activity });
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        await Mediator.Send(new Delete.Command { Id = id });
        return Ok();
    }
}