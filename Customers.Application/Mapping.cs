using AutoMapper;
using Bitnovo.Banking.Shared.Dto;
using Bitnovo.Customers.Domain.Aggregates;
using Bitnovo.Customers.Shared.Dto;

namespace Bitnovo.Customers.Application.Dto.Profiles
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.Username, o => o.MapFrom(c => c.User.Username));

            CreateMap<AccountDto, CustomerDto>()
                .ForMember(x => x.AccountNumber, o => o.MapFrom(c => c.Number));
        }
    }
}
