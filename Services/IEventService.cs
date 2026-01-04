namespace EventEase.Services;

using EventEase.Models;

// async crud operations for events
public interface IEventService
{
    Task<Event> CreateEventAsync(Event newEvent);
    Task<Event> GetEventByIdAsync(int eventId);
    Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event> UpdateEventAsync(Event updatedEvent);
    Task<bool> DeleteEventAsync(int eventId);
}
