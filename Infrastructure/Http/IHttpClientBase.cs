using System.Threading.Tasks;
using Bitnovo.Common;

namespace Bitnovo.Infrastructure.Http
{
    public interface IHttpClientBase<TQuery, TModel>
    {
        Task<Result<TModel>> ExecuteAsync(TQuery query);
    }
}