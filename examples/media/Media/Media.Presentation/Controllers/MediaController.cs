using Media.Application.Media.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Media.Presentation.Controllers;

public class MediaController : ControllerBase
{
    private readonly ISender _mediator;
    
    public MediaController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
        var command = new UploadMediaCommand(fileName, file.OpenReadStream());
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}