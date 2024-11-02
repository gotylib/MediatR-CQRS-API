using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Infrastructure.Commands;
using WebApplication1.Infrastructure.Queries;
using WebApplication1.View;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class NoteController : ControllerBase
{
    IMediator _mediator;
    public NoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<NoteListVm>> GetAll(int userId)
    {
        var query = new GetNoteListQuery
        {
            UserId = userId
        };
        var vm = await _mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet]
    public async Task<ActionResult<NoteDetailsVm>> Get(Guid id, int userId)
    {
        var query = new GetNoteDetailsQuery
        {
            UserId = userId,
            Id = id
        };
        var vm = await _mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
    {
        var command = new CreateNoteCommand
        {
            UserId = createNoteDto.UserId,
            Title = createNoteDto.Title,
            Details = createNoteDto.Details
        };
        var noteId = await _mediator.Send(command);
        return Ok(noteId);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
    {
        var command = new UpdateNoteCommand
        {
            Id = updateNoteDto.Id,
            UserId = updateNoteDto.UserId,
            Title = updateNoteDto.Title,
            Details = updateNoteDto.Details

        };
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, int userId)
    {
        var command = new DeleteNoteCommand
        {
            Id = id,
            UserId = userId
        };
        await _mediator.Send(command);
        return NoContent();
    }
}