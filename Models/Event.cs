namespace EventEase.Models;

public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Date { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageAlt { get; set; }
    public List<AttendeeModel> Attendees { get; set; } = new List<AttendeeModel>();
}