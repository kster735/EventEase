namespace EventEase.Services;

using TG.Blazor.IndexedDB;
using EventEase.Models;

public class NotificationStoreServiceIndexedDB : INotificationStoreService
{
    private readonly IndexedDBManager _db;

    public event Action<Notification> OnNotificationAdded;
    public event Action<Notification> OnNotificationRead;

    public NotificationStoreServiceIndexedDB(IndexedDBManager db)
    {
        _db = db;
    }

    public async Task AddNotificationAsync(Notification notification)
    {
        var storedNotification = new StoreRecord<Notification>
        {
            Storename = "notifications",
            Data = notification,
        };
        await _db.AddRecord(storedNotification);
        OnNotificationAdded?.Invoke(notification);
    }

    public Task DeleteNotificationAsync(int notificationId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Notification>> GetAllNotificationsAsync()
    {
        var notifications = await _db.GetRecords<Notification>("notifications");
        return notifications;
    }

    public Task<List<Notification>> GetNotificationsForEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        var notification = await _db.GetRecordById<int, Notification>("notifications", notificationId);
        if (notification != null)
        {
            notification.Read = !notification.Read;
            var storedNotification = new StoreRecord<Notification>
            {
                Storename = "notifications",
                Data = notification,
            };
            await _db.UpdateRecord(storedNotification);
            OnNotificationRead?.Invoke(notification);
        }
    }


}