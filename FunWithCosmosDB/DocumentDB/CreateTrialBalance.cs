using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using Microsoft.Azure.Documents;
using System;
using System.Threading.Tasks;

namespace FunWithCosmosDB.DocumentDB
{
    public class CreateTrialBalance : ICommand<TrialBalance>
    {
        private readonly IDocumentClient _client;

        public CreateTrialBalance(IDocumentClient client)
        {
            _client = client;
        }

        public async Task ExecuteAsync(TrialBalance arguments)
        {
            throw new NotImplementedException();
        }
    }
}
