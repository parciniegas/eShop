namespace eShop.Orders.Domain;

public class Note(DateTime noteDate, string content)
{
    public DateTime NoteDate { get; set; } = noteDate;
    public string Content { get; set; } = content;
}