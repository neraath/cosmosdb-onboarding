using FunWithCosmosDB.Interfaces;
using FunWithCosmosDB.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithCosmosDB.Stubs
{
    public class StubGetSpecificRecord : IQuery<Guid, TrialBalance>
    {
        public async Task<TrialBalance> QueryAsync(Guid args = default(Guid))
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("STUB: Getting stubbed specific record.");
            return StaticCollection.Records.SingleOrDefault(x => x.Id == args);
        }
    }
}
