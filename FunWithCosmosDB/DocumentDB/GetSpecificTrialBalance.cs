using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using Microsoft.Azure.Documents;
using System;

namespace FunWithCosmosDB.DocumentDB
{
    public class GetSpecificTrialBalance : IQuery<Guid, TrialBalance>
    {
        private readonly IDocumentClient _client;

        public GetSpecificTrialBalance(IDocumentClient client)
        {
            _client = client;
        }

        public TrialBalance Query(Guid args = default(Guid))
        {
            throw new NotImplementedException();
        }
    }
}
