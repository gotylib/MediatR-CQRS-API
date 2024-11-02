using MediatR;

namespace WebApplication1.Infrastructure.Commands;

public class DeleteNoteCommand : IRequest
{
    public int UserId { get; set; }
    public Guid Id { get; set; }
}