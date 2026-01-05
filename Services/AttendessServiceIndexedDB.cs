namespace EventEase.Services;

using EventEase.Models;
using Microsoft.JSInterop;

// async crud operations for events using IndexedDB via JSInterop
public class AttendeesServiceIndexedDB : IAttendeeService
{
    private readonly IJSRuntime _jsRuntime;

    public AttendeesServiceIndexedDB(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<Attendee> CreateAttendeeAsync(Attendee newAttendee)
    {
        var attendeeId = await _jsRuntime.InvokeAsync<int>("indexedDBFunctions.addAttendee", newAttendee);
        newAttendee.Id = attendeeId;
        return newAttendee;
    }

    public async Task<bool> DeleteAttendeeAsync(int attendeeId)
    {
        await _jsRuntime.InvokeVoidAsync("indexedDBFunctions.deleteAttendee", attendeeId);
        return true;
    }

    public async Task<IEnumerable<Attendee>> GetAllAttendeesAsync()
    {
        var attendees = await _jsRuntime.InvokeAsync<IEnumerable<Attendee>>("indexedDBFunctions.getAllAttendees");
        return attendees ?? Enumerable.Empty<Attendee>();
    }

    public async Task<Attendee> GetAttendeeByIdAsync(int attendeeId)
    {
        var attendee = await _jsRuntime.InvokeAsync<Attendee>("indexedDBFunctions.getAttendeeById", attendeeId);
        return attendee;
    }

    public Task<Attendee> UpdateAttendeeAsync(Attendee updatedAttendee)
    {
        throw new NotImplementedException();
    }

    public Task<Attendee> UpdateEventAsync(Attendee updatedEvent)
    {
        throw new NotImplementedException();
    }
}