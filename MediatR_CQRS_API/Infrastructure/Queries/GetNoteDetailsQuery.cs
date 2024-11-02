using MediatR;
using WebApplication1.View;

namespace WebApplication1.Infrastructure.Queries;

public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
{
    public int UserId { get; set; }
    public Guid Id { get; set; }
}