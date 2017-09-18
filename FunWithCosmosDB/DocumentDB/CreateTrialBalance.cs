using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using Microsoft.Azure.Documents;
using System;

namespace FunWithCosmosDB.DocumentDB
{
    public class CreateTrialBalance : ICommand<TrialBalance>
    {
        private readonly IDocumentClient _client;

        public CreateTrialBalance(IDocumentClient client)
        {
            _client = client;
        }

        public void Execute(TrialBalance arguments)
        {
            throw new NotImplementedException();
        }
    }
}
