namespace WebApplication1.DTOs;

public class UpdateNoteDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
}