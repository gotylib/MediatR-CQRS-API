using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure.Queries;
using WebApplication1.View;

namespace WebApplication1.Infrastructure.QuerieHandlers;

public class GetNoteDetailsHandler
    : IRequestHandler<GetNoteDetailsQuery,NoteDetailsVm>
{
    private readonly ApplicationDbContext _dbContext;

    public GetNoteDetailsHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        return new NoteDetailsVm
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            CreationDate = entity.CreationDate,
            EditDate = entity.EditDate
        };
    }
}