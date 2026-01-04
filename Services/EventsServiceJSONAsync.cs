namespace EventEase.Services;

using EventEase.Models;

// async crud operations for events
public class EventsServiceJSONAsync : IEventService
{
    public Task<Event> CreateEventAsync(Event newEvent)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetEventByIdAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<Event> UpdateEventAsync(Event updatedEvent)
    {
        throw new NotImplementedException();
    }
}