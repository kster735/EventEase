namespace EventEase.Services;

using EventEase.Models;
using TG.Blazor.IndexedDB;

// async crud operations for events using IndexedDB via JSInterop
public class AttendeesServiceIndexedDB : IAttendeeService
{
    private readonly IndexedDBManager _db;

    public AttendeesServiceIndexedDB(IndexedDBManager db)
    {
        _db = db;
    }

    public async Task<AttendeeModel> CreateAttendeeAsync(AttendeeModel newAttendee)
    {
        var storedAttendee = new StoreRecord<AttendeeModel>
        {
            Storename = "attendees",
            Data = newAttendee,
        };
        await _db.AddRecord(storedAttendee);
        return newAttendee;
    }

    public async Task<bool> DeleteAttendeeAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AttendeeModel>> GetAllAttendeesAsync()
    {
        var attendees = await _db.GetRecords<AttendeeModel>("attendees");
        return attendees;
    }

    public async Task<List<AttendeeModel>> GetAttendeesByEventIdAsync(int eventId)
    {
        var allAttendees = await _db.GetRecords<AttendeeModel>("attendees");
        var result = allAttendees.Where(a => a.EventId == eventId);

        return await result.ToAsyncEnumerable().ToListAsync();
    }

    public async Task<AttendeeModel> GetAttendeeByIdAsync(int attendeeId)
    {
        throw new NotImplementedException();
    }

    public Task<AttendeeModel> UpdateAttendeeAsync(AttendeeModel updatedAttendee)
    {
        throw new NotImplementedException();
    }

    public Task<AttendeeModel> UpdateEventAsync(AttendeeModel updatedEvent)
    {
        throw new NotImplementedException();
    }
}