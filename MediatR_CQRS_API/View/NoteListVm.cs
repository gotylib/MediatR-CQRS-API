using WebApplication1.DTOs;

namespace WebApplication1.View;

public class NoteListVm
{
    public IList<NoteLookupDto> Notes { get; set; }
}