using MediatR;
using WebApplication1.View;

namespace WebApplication1.Infrastructure.Queries;

public class GetNoteListQuery : IRequest<NoteListVm>
{
    public int UserId { get; set; }
}