namespace EventEase.Services;

using EventEase.Models;
using TG.Blazor.IndexedDB;

// async crud operations for events using IndexedDB via JSInterop
public class EventsServiceIndexedDb : IEventService
{
    private readonly IndexedDBManager _db;

    public EventsServiceIndexedDb(IndexedDBManager db)
    {
        _db = db;
    }

    public async Task<Event> CreateEventAsync(Event evt)
    {
        var storedEvent = new StoreRecord<Event>
        {
            Storename = "events",
            Data = evt,
        };
        await _db.AddRecord(storedEvent);
        return evt;
    }

    public Task<bool> DeleteEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        var events = await _db.GetRecords<Event>("events");
        return events;
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _db.GetRecordById<int, Event>("events", id);
    }

    public Task<Event> UpdateEventAsync(Event updatedEvent)
    {
        throw new NotImplementedException();
    }

}
