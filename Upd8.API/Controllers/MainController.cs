using Microsoft.AspNetCore.Mvc;
using Upd8.API.Interfaces;

namespace Upd8.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        private bool IsValidOperation { get => !_notificator.HasNotification(); }

        protected MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void NotifyError(string message)
            => _notificator.Handle(message);

        protected ActionResult CustomResponse(object? response = null)
        {
            if (IsValidOperation)
            {
                return Ok(new
                {
                    success = true,
                    data = response
                });
            }

            var error = new
            {
                success = false,
                errors = _notificator.GetNotifications()
            };

            return BadRequest(error);
        }
    }
}
