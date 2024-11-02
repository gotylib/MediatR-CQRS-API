using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Note> Notes { get; set; } = null!;
}