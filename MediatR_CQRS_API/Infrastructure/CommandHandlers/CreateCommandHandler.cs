using MediatR;
using WebApplication1.Core;
using WebApplication1.Data;
using WebApplication1.Infrastructure.Commands;

namespace WebApplication1.Infrastructure.ComandHandlers;

public class CreateCommandHandler
    : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateCommandHandler(ApplicationDbContext context) => _dbContext = context;

    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId,
            Title = request.Title,
            Details = request.Details,
            Id = Guid.NewGuid(),
            CreationDate = DateTime.Now,
            EditDate = null
        };

        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return note.Id;
    }
}