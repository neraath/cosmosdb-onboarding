using FunWithCosmosDB.Interfaces;
using Microsoft.Azure.Documents;

namespace FunWithCosmosDB.Stubs
{
    public class StubInitialize : IInitialize
    {
        public IDocumentClient InitializeClient()
        {
            System.Console.WriteLine("STUB: No client connection initialized.");
            return null;
        }
    }
}
