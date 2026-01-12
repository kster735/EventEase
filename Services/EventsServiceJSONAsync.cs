namespace EventEase.Services;

using System.Net.Http.Json;
using EventEase.Models;

// async crud operations for events
public class EventsServiceJSONAsync : IEventService
{
    // This field holds the HttpClient instance used for making HTTP requests.
    private readonly HttpClient _http;
    // Automatic dependency resolution of HttpClient via constructor injection.
    public EventsServiceJSONAsync(HttpClient http)
    {
        _http = http;
    }

    public async Task<Event> CreateEventAsync(Event newEvent)
    {
        var events = await _http.GetFromJsonAsync<IEnumerable<Event>>("sample-data/events.json");

        // Simulate adding the new event to the list
        // In a real implementation, this would involve POSTing to a server endpoint
        // and returning the newly created event with its assigned ID.
        if (events == null || !events.Any() || events.Count() == 0)
        {
            newEvent.Id = 1; // First ID if no events exist
            events = new List<Event> { newEvent };
        }
        else
        {
            newEvent.Id = events.Max(e => e.Id) + 1; // Assign next ID
            events = events.Append(newEvent);
        }

        await _http.PostAsJsonAsync("sample-data/events.json", events);

        return newEvent;
    }

    public Task<bool> DeleteEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        var events = await _http.GetFromJsonAsync<IEnumerable<Event>>("sample-data/events.json");
        if (events == null)
        {
            return Enumerable.Empty<Event>(); // or just []
        }
        return events;
    }

    public async Task<Event> GetEventByIdAsync(int eventId)
    {
        var events = await _http.GetFromJsonAsync<IEnumerable<Event>>("sample-data/events.json");
        return events?.FirstOrDefault(e => e.Id == eventId);
    }

    public Task<Event> UpdateEventAsync(Event updatedEvent)
    {
        throw new NotImplementedException();
    }

}