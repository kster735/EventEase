

namespace EventEase.Services;

using EventEase.Models;

public interface IAttendeeService
{
    Task<AttendeeModel> CreateAttendeeAsync(AttendeeModel newAttendee);
    Task<AttendeeModel> GetAttendeeByIdAsync(int attendeeId);
    Task<List<AttendeeModel>> GetAttendeesByEventIdAsync(int eventId);
    Task<IEnumerable<AttendeeModel>> GetAllAttendeesAsync();
    Task<AttendeeModel> UpdateAttendeeAsync(AttendeeModel updatedAttendee);
    Task<bool> DeleteAttendeeAsync(int attendeeId);
}