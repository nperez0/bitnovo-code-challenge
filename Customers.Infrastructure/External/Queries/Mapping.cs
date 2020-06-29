using AutoMapper;
using Bitnovo.Banking.Shared.Requests;

namespace Bitnovo.Customers.Infrastructure.External.Queries
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AccountsQuery, AccountsRequest>();
        }
    }
}
