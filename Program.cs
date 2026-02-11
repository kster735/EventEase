using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase;
using EventEase.Services;
using TG.Blazor.IndexedDB;
using EventEase.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IEventService, EventsServiceIndexedDb>();
builder.Services.AddScoped<IAttendeeService, AttendeesServiceIndexedDB>();
builder.Services.AddScoped<EventStateContainer>();


builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "EventEaseDB";
    dbStore.Version = 1;
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "events",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec { Name = "name", KeyPath = "name", Unique = false },
            new IndexSpec { Name = "date", KeyPath = "date", Unique = false },
            new IndexSpec { Name = "location", KeyPath = "location", Unique = false },
            new IndexSpec { Name = "description", KeyPath = "description", Unique = false },
            new IndexSpec { Name = "image_url", KeyPath = "image_url", Unique = false },
            new IndexSpec { Name = "image_alt", KeyPath = "image_alt", Unique = false },
        }
    });
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "attendees",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec { Name = "email", KeyPath = "email", Unique = false },
            new IndexSpec { Name = "name", KeyPath = "name", Unique = false },
            new IndexSpec { Name = "event_id", KeyPath = "event_id", Unique = false },
        }
    });
});

builder.Services.AddScoped<IndexedDbSeeder>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IndexedDbSeeder>();
    await seeder.SeedAsync();
}

await app.RunAsync();
