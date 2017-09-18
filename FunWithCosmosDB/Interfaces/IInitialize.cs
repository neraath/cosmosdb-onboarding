using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Interfaces
{
    public interface IInitialize
    {
        Task<IDocumentClient> InitializeClientAsync();
    }
}
