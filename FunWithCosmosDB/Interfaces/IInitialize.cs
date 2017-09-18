using Microsoft.Azure.Documents;

namespace FunWithCosmosDB.Interfaces
{
    public interface IInitialize
    {
        IDocumentClient InitializeClient();
    }
}
