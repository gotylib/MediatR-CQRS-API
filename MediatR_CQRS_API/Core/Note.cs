namespace WebApplication1.Core;

public class Note
{
    
    public Guid Id { get; set; }
    public int UserId { get; init; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime CreationDate { get; init; }
    public DateTime? EditDate { get; set; }

}