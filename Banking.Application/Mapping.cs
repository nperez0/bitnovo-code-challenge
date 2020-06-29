using AutoMapper;
using Bitnovo.Banking.Domain.Entities;
using Bitnovo.Banking.Shared.Dto;

namespace Bitnovo.Banking.Application
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
