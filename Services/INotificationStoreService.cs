namespace EventEase.Services;

using EventEase.Models;
public interface INotificationStoreService
{
    event Action<Notification> OnNotificationAdded;
    event Action<Notification> OnNotificationRead;
    Task AddNotificationAsync(Notification notification);

    Task<List<Notification>> GetAllNotificationsAsync();

    Task MarkAsReadAsync(int notificationId);

    Task DeleteNotificationAsync(int notificationId);

    Task<List<Notification>> GetNotificationsForEventAsync(int eventId);
}