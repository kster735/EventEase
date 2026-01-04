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
    public Task<Attendee> CreateAttendeeAsync(Attendee newAttendee)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAttendeeAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Attendee>> GetAllAttendeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Attendee> GetAttendeeByIdAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public Task<Attendee> UpdateAttendeeAsync(Attendee updatedAttendee)
    {
        throw new NotImplementedException();
    }
}