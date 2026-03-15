using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class AttendeeModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string? Name { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string? Email { get; set; }
    public int EventId { get; set; }
}