namespace EventEase.Services;

using EventEase.Models;

// async crud operations for attendees
public class AttendeesServiceJSONAsync : IAttendeeService
{
    private readonly HttpClient _http;
    public AttendeesServiceJSONAsync(HttpClient http)
    {
        _http = http;
    }
    public Task<AttendeeModel> CreateAttendeeAsync(AttendeeModel newAttendee)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAttendeeAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AttendeeModel>> GetAllAttendeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<AttendeeModel>> GetAttendeesByEventIdAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<AttendeeModel> GetAttendeeByIdAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public Task<AttendeeModel> UpdateAttendeeAsync(AttendeeModel updatedAttendee)
    {
        throw new NotImplementedException();
    }
}