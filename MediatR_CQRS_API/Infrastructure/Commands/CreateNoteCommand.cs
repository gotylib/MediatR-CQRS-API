using MediatR;

namespace WebApplication1.Infrastructure.Commands;

public class CreateNoteCommand : IRequest<Guid>
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
}