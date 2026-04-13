window.notifications = {
    requestPermission: async () => {
        return await Notification.requestPermission();
    },
    notify: (title, body) => {
        new Notification(title, { body: body });
    }
}