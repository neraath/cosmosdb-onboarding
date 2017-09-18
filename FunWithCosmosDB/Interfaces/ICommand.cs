using System.Threading.Tasks;

namespace FunWithCosmosDB.Interfaces
{
    public interface ICommand<TArgs>
    {
        Task ExecuteAsync(TArgs arguments);
    }

    public interface ICommand<TArgs, TResponse>
    {
        Task<TResponse> ExecuteAsync(TArgs arguments);
    }
}
