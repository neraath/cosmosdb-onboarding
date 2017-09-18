using System.Threading.Tasks;

namespace FunWithCosmosDB.Interfaces
{
    public interface IQuery<TResponse>
    {
        Task<TResponse> QueryAsync();
    }

    public interface IQuery<TArgs, TResponse>
    {
        Task<TResponse> QueryAsync(TArgs args = default(TArgs));
    }
}
