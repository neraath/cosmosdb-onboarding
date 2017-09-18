using FunWithCosmosDB.Stubs;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithCosmosDB
{
    class Program
    {
        static IDocumentClient Client;

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to connect to the data source.");
            Console.ReadLine();

            Execute();
        }

        static void InvokeSelectedOption(SelectedOption option)
        {
            switch (option)
            {
                case SelectedOption.Quit:
                    Environment.Exit(0);
                    break;
                case SelectedOption.GetAllRecords:
                    var getAllRecordsQuery = new StubGetAllRecords();
                    var records = getAllRecordsQuery.Query();
                    records.ToList().ForEach((record) => Console.WriteLine($"{record.EngagementName} [{record.Id}]"));
                    break;
                case SelectedOption.GetSpecificRecord:
                    Console.WriteLine("Get specific record");
                    break;
                case SelectedOption.CreateRecord:
                    Console.WriteLine("Create record");
                    break;
                case SelectedOption.UpdateSpecificRecord:
                    Console.WriteLine("Update specific record.");
                    break;
            }
        }

        #region Boilerplate

        static void Execute()
        {
            try
            {
                if (Client == null) Client = new StubInitialize().InitializeClient();
                var selectedOption = Menu();
                InvokeSelectedOption(selectedOption);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Execute();
            }
        }

        static SelectedOption Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please select from one of the following options:");
            Console.WriteLine("1. Create a new record");
            Console.WriteLine("2. Get all records");
            Console.WriteLine("3. Get a specific record by id");
            Console.WriteLine("4. Update a specific record");
            Console.WriteLine("9. Quit");
            Console.Write("Option? ");
            string option = Console.ReadLine();

            if (!Enum.TryParse<SelectedOption>(option, out var selectedOption))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: Invalid option");
                return Menu();
            }

            return selectedOption;
        }

        private enum SelectedOption
        {
            CreateRecord = 1,
            GetAllRecords = 2,
            GetSpecificRecord = 3,
            UpdateSpecificRecord = 4,
            Quit = 9
        }

        #endregion
    }
}
