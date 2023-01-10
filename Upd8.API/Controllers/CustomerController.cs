using Microsoft.AspNetCore.Mvc;
using Upd8.API.Interfaces;
using Upd8.Domain.Core.Interfaces.Services;
using Upd8.Domain.Dtos;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Upd8.API.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : MainController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, INotificator notificator) : base(notificator)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return CustomResponse(_customerService.GetAll());
            }
            catch (Exception ex)
            {
                NotifyError(ex.InnerException?.Message ?? ex.Message);
                return CustomResponse();
            }
        }

        [HttpGet("id")]
        public ActionResult GetById(long id)
        {
            try
            {
                return CustomResponse(_customerService.GetById(id));
            }
            catch (Exception ex)
            {
                NotifyError(ex.InnerException?.Message ?? ex.Message);
                return CustomResponse();
            }
        }

        [HttpPost]
        public ActionResult Post(NewCustomerDto customer)
        {
            try
            {
                return CustomResponse(_customerService.Add(customer));
            }
            catch (Exception ex)
            {
                NotifyError(ex.InnerException?.Message ?? ex.Message);
                return CustomResponse();
            }
        }

        [HttpPatch]
        public ActionResult Patch(EditCustomerDto customer)
        {
            try
            {
                return CustomResponse(_customerService.Update(customer));
            }
            catch (Exception ex)
            {
                NotifyError(ex.InnerException?.Message ?? ex.Message);
                return CustomResponse();
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                return CustomResponse(_customerService.Delete(id));
            }
            catch (Exception ex)
            {
                NotifyError(ex.InnerException?.Message ?? ex.Message);
                return CustomResponse();
            }
        }
    }
}
