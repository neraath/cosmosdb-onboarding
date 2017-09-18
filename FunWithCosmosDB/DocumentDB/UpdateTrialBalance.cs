using FunWithCosmosDB.Interfaces;
using Microsoft.Azure.Documents;
using System;
using System.Threading.Tasks;

namespace FunWithCosmosDB.DocumentDB
{
    public class UpdateTrialBalanceArgs
    {
        public Guid Id { get; set; }
        public string EngagementName { get; set; }
    }

    public class UpdateTrialBalance : ICommand<UpdateTrialBalanceArgs>
    {
        private readonly IDocumentClient _client;

        public UpdateTrialBalance(IDocumentClient client)
        {
            _client = client;
        }

        public async Task ExecuteAsync(UpdateTrialBalanceArgs arguments)
        {
            throw new NotImplementedException();
        }
    }
}
