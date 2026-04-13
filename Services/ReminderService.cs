namespace EventEase.Services;

using EventEase.Models;

public class ReminderService : IAsyncDisposable
{
    private readonly INotificationStoreService _notificationStore;
    private readonly NotificationsService _notifications;
    private readonly IEventService _db;
    private PeriodicTimer _timer;

    public ReminderService(NotificationsService notifications, INotificationStoreService notificationStore, IEventService db)
    {
        _notifications = notifications;
        _notificationStore = notificationStore;
        _db = db;
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(20));
        _ = RunAsync();
    }

    private async Task RunAsync()
    {
        while (await _timer.WaitForNextTickAsync())
        {
            await CheckEventsAsync();
        }
    }

    private async Task CheckEventsAsync()
    {
        var tomorrow = DateTime.Today.AddDays(1);
        var events = await _db.GetAllEventsAsync();
        var upcomingEvents = events.Where(e => !e.Canceled && !e.NotificationIsRead && e.Date.Date == tomorrow);

        foreach (var ev in upcomingEvents)
        {
            await _notifications.ShowNotificationAsync(
                "Event Reminder",
                $"{ev.Name} starts tommorrow at {ev.Date}"
            );
            await _notificationStore.AddNotificationAsync(new Notification
            {
                Title = "Event Reminder",
                Message = $"{ev.Name} starts tommorrow at {ev.Date}",
                Read = false,
                EventId = ev.Id,
                Timestamp = DateTime.Now
            });
            ev.NotificationIsRead = true;
            await _db.UpdateEventAsync(ev);
        }

    }

    public async ValueTask DisposeAsync()
    {
        _timer.Dispose();
        await Task.CompletedTask;
    }
}