namespace EventEase.Models;

public class AttendeeModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public int EventId { get; set; }
}