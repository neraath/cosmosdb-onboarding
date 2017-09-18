using FunWithCosmosDB.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Stubs
{
    public class UpdateSpecificRecordArgs
    {
        public Guid Id { get; set; }
        public string EngagementName { get; set; }
    }

    public class StubUpdateSpecificRecord : ICommand<UpdateSpecificRecordArgs>
    {
        public async Task ExecuteAsync(UpdateSpecificRecordArgs arguments)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Searching for TrialBalance {arguments.Id}");
            var existingRecord = StaticCollection.Records.SingleOrDefault(x => x.Id == arguments.Id);
            if (existingRecord == null) throw new ArgumentException($"No trialbalance exists by id {arguments.Id}");
            Console.WriteLine("Found TrialBalance. Updating.");
            existingRecord.EngagementName = arguments.EngagementName;
            Console.WriteLine("Update complete!");
        }
    }
}
