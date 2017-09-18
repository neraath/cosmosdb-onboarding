using FunWithCosmosDB.Interfaces;
using System;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace FunWithCosmosDB.DocumentDB
{
    public class InitializeDocumentDb : IInitialize
    {
        public async Task<IDocumentClient> InitializeClientAsync()
        {
            throw new NotImplementedException();
        }
    }
}
