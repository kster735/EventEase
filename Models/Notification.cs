namespace EventEase.Models;

public class Notification
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool Read { get; set; } = false;
    public int EventId { get; set; }
    public Event? Event { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}