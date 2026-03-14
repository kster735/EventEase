using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Event
{
    public int Id { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string? Name { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    [FutureDate]
    // Custom validation will ensure the date is in the future
    public DateTime Date { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Location must be between 4 and 100 characters.")]
    public string? Location { get; set; }

    [Required]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters.")]
    public string? Description { get; set; }
    [UrlOrNullorEmpty]
    public string? ImageUrl { get; set; }

    [AltTextRequiredIfImageUrl]
    public string? ImageAlt { get; set; }
    public List<AttendeeModel> Attendees { get; set; } = new List<AttendeeModel>();

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime < DateTime.Now)
                {
                    return new ValidationResult("The date must be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class UrlOrNullorEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString()) || Uri.IsWellFormedUriString(value.ToString(), UriKind.Absolute))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The field must be a valid URL or null.");
        }
    }

    public class AltTextRequiredIfImageUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var eventModel = (Event)validationContext.ObjectInstance;
            if (!string.IsNullOrEmpty(eventModel.ImageUrl) && (eventModel.ImageAlt == null || eventModel.ImageAlt.Length < 2))
            {
                return new ValidationResult("ImageAlt is required when ImageUrl is provided.");
            }
            return ValidationResult.Success;
        }
    }
}