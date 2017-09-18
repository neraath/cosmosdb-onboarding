using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Stubs
{
    public class StubGetAllRecords : IQuery<IEnumerable<TrialBalance>>
    {
        public async Task<IEnumerable<TrialBalance>> QueryAsync()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("STUB: Getting stubbed results.");
            return StaticCollection.Records;
        }
    }
}
