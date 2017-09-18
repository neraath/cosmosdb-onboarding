using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using System;
using System.Collections.Generic;

namespace FunWithCosmosDB.Stubs
{
    public class StubGetAllRecords : IQuery<IEnumerable<TrialBalance>>
    {
        public IEnumerable<TrialBalance> Query()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("STUB: Getting stubbed results.");
            return StaticCollection.Records;
        }
    }
}
