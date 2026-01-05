using System.Net.Http.Json;
using TG.Blazor.IndexedDB;
using EventEase.Models;
namespace EventEase.Services;

public class IndexedDbSeeder
{
    private readonly HttpClient _http;
    private readonly IndexedDBManager _db;

    public IndexedDbSeeder(HttpClient http, IndexedDBManager db)
    {
        _http = http;
        _db = db;
    }

    public async Task SeedAsync()
    {
        // 1. Check if events store already has data
        var existing = await _db.GetRecords<Event>("events");

        if (existing.Count > 0)
        {
            // Already seeded
            return;
        }

        // 2. Load JSON from wwwroot/data/events.json
        var events = await _http.GetFromJsonAsync<List<Event>>("sample-data/events.json");

        if (events is null || events.Count == 0)
            return;



        foreach (var evt in events)
        {
            var storedEvent = new StoreRecord<Event>
            {
                Storename = "events",
                Data = evt,
            };

            await _db.AddRecord(storedEvent);
        }

    }
}
