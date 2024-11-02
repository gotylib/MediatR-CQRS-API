using MediatR;

namespace WebApplication1.Infrastructure.Commands;

public class UpdateNoteCommand : IRequest
{
    public int UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
}