using Upd8.API.Interfaces;

namespace Upd8.API.Models
{
    public class Notificator : INotificator
    {
        private List<string> Messages { get; set; } = new();

        public void Handle(string notification)
            => Messages.Add(notification);

        public List<string> GetNotifications()
            => Messages;

        public bool HasNotification()
            => Messages.Any();
    }
}
