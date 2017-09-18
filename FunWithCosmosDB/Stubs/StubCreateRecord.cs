using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using System;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Stubs
{
    public class StubCreateRecord : ICommand<TrialBalance>
    {
        public async Task ExecuteAsync(TrialBalance arguments)
        {
            StaticCollection.Records.Add(arguments);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{arguments.EngagementName} added successfully");
        }
    }
}
