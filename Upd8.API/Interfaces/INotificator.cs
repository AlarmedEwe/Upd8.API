namespace Upd8.API.Interfaces
{
    public interface INotificator
    {
        public bool HasNotification();
        public List<string> GetNotifications();
        public void Handle(string notification);
    }
}
