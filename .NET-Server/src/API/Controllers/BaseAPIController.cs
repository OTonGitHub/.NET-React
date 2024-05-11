using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController(/*IMediator mediator*/) : ControllerBase
{
    private IMediator _mediator; // = mediator

    // In case inheriting class already has mediator.
    // Not sure why readonly not available for Mediator here.
    // Protected fields will be available for inheriting class.
    protected IMediator Mediator => _mediator ??=
        HttpContext.RequestServices.GetService<IMediator>();
}
