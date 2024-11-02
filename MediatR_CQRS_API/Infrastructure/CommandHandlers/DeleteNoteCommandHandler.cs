using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure.Commands;

namespace WebApplication1.Infrastructure.CommandHandlers;

public class DeleteNoteCommandHandler
    : IRequestHandler<DeleteNoteCommand>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteNoteCommandHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes.FindAsync(request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        _dbContext.Notes.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}