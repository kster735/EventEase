namespace EventEase.Services;

using Microsoft.JSInterop;
public class NotificationsService
{
    private readonly IJSRuntime _js;

    public NotificationsService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<bool> RequestPermissionAsync()
    {
        var result = await _js.InvokeAsync<string>("notifications.requestPermission");
        return result == "granted";
    }
    public async Task ShowNotificationAsync(string title, string message)
    {
        await _js.InvokeVoidAsync("notifications.notify", title, message);
    }


}