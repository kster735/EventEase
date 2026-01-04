

namespace EventEase.Services;

using EventEase.Models;

public interface IAttendeeService
{
    Task<Attendee> CreateAttendeeAsync(Attendee newAttendee);
    Task<Attendee> GetAttendeeByIdAsync(int attendeeId);
    Task<IEnumerable<Attendee>> GetAllAttendeesAsync();
    Task<Attendee> UpdateAttendeeAsync(Attendee updatedAttendee);
    Task<bool> DeleteAttendeeAsync(int attendeeId);
}