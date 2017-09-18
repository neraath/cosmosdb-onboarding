using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using System;

namespace FunWithCosmosDB.Stubs
{
    public class StubCreateRecord : ICommand<TrialBalance>
    {
        public void Execute(TrialBalance arguments)
        {
            StaticCollection.Records.Add(arguments);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{arguments.EngagementName} added successfully");
        }
    }
}
