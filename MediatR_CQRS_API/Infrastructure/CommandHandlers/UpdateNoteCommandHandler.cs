using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure.Commands;

namespace WebApplication1.Infrastructure.ComandHandlers;

public class UpdateNoteCommandHandler
    : IRequestHandler<UpdateNoteCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateNoteCommandHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.Details = request.Details;
        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}