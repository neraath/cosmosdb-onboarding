using FunWithCosmosDB.Interfaces;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Stubs
{
    public class StubInitialize : IInitialize
    {
        public async Task<IDocumentClient> InitializeClientAsync()
        {
            System.Console.WriteLine("STUB: No client connection initialized.");
            return null;
        }
    }
}
