using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunWithCosmosDB.DocumentDB
{
    public class GetAllTrialBalances : IQuery<IEnumerable<TrialBalance>>
    {
        private readonly IDocumentClient _client;

        public GetAllTrialBalances(IDocumentClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<TrialBalance>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
