﻿using FunWithCosmosDB.Model;
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
        static Program Instance;

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to connect to the data source.");
            Console.ReadLine();
            Client = new StubInitialize().InitializeClientAsync().Result;
            Instance = new Program();
            Instance.Execute().Wait();
        }

        private async Task InvokeSelectedOption(SelectedOption option)
        {
            switch (option)
            {
                case SelectedOption.Quit:
                    Environment.Exit(0);
                    break;
                case SelectedOption.GetAllRecords:
                    var getAllRecordsQuery = new StubGetAllRecords();
                    var records = await getAllRecordsQuery.QueryAsync();
                    records.ToList().ForEach((record) => Console.WriteLine($"{record.EngagementName} [{record.Id}]"));
                    break;
                case SelectedOption.GetSpecificRecord:
                    Console.Write("Please enter the Guid to get: ");
                    Guid recordToGet = Guid.Parse(Console.ReadLine());
                    var getSpecificRecordQuery = new StubGetSpecificRecord();
                    var specificRecord = await getSpecificRecordQuery.QueryAsync(recordToGet);
                    if (specificRecord == null) Console.WriteLine("NO RECORDS FOUND");
                    else Console.WriteLine($"{specificRecord.EngagementName} [{specificRecord.Id}]");
                    break;
                case SelectedOption.CreateRecord:
                    Console.WriteLine("Please fill out the following details:");
                    Console.Write("Engagement Name: ");
                    string engagementName = Console.ReadLine();
                    Console.Write("Firm Guid: ");
                    Guid firmGuid = Guid.Parse(Console.ReadLine());
                    var trialBalance = new TrialBalance()
                    {
                        Id = Guid.NewGuid(), // TODO: Allow CosmosDB to auto-generate the ID.
                        EngagementName = engagementName,
                        FirmGuid = firmGuid
                    };
                    var createRecordCommand = new StubCreateRecord();
                    await createRecordCommand.ExecuteAsync(trialBalance);
                    break;
                case SelectedOption.UpdateSpecificRecord:
                    Console.Write("Specify the trial balance id to modify: ");
                    Guid trialBalanceId = Guid.Parse(Console.ReadLine());
                    Console.Write("What is the new engagement name? : ");
                    string newEngagementName = Console.ReadLine();
                    var updateRecordCommand = new StubUpdateSpecificRecord();
                    await updateRecordCommand.ExecuteAsync(new UpdateSpecificRecordArgs() { Id = trialBalanceId, EngagementName = newEngagementName });
                    break;
            }
        }

        #region Boilerplate

        private async Task Execute()
        {
            try
            {
                var selectedOption = Menu();
                await InvokeSelectedOption(selectedOption);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                await Execute();
            }
        }

        private SelectedOption Menu()
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
