using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Infrastructure.Queries;
using WebApplication1.View;

namespace WebApplication1.Infrastructure.QuerieHandlers;

public class GetNoteListQueryHandler
    : IRequestHandler<GetNoteListQuery, NoteListVm>
{
    private readonly ApplicationDbContext _dbContext;

    public GetNoteListQueryHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Notes
            .Where(note => note.UserId == request.UserId) 
            .ToListAsync(cancellationToken);
        return new NoteListVm
        {
            Notes = notesQuery.Select(note =>
                new NoteLookupDto
                {
                    Id = note.Id,
                    Title = note.Title
                }).ToList()
        };
    }
}