using AutoMapper;
using Upd8.Domain.Dtos;
using Upd8.Domain.Entities;

namespace Upd8.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, NewCustomerDto>().ReverseMap();
        }
    }
}
