# CosmosDB Onboarding and Training
The purpose of the code in this repository is to help people get up-to-speed with the .Net
CosmosDB SDK and interacting with CosmosDB thru C#. This is part of a broader curriculum 
to help onboard new developers who are not familiar with CosmosDB. 

## Pre-requisites
All developers are encouraged to review the following two videos before starting: 
 - [PluralSight - Intro to Azure DocumentDB](http://tinyurl.com/y76m84t3)
 - [CosmosDB Developer Brown Bag Video](http://tinyurl.com/ybkqjtqc)

The next two labs in this section help to introduce team members to CosmosDB, including storing multiple different types of documents in a collection,
making raw SQL queries within the collection, using projections, and getting started with stored procedures.

## Lab #1
[Azure CosmosDB Hands-On Labs from aliuy](https://github.com/aliuy/azure-cosmosdb-labs/tree/master/DataCamp)
The purpose of this first lab is to get you familiar with the query capabilities of CosmosDB and write your first stored procedure that modifies existing records.
Supplemental Documentation: [How to query using SQL?](https://docs.microsoft.com/en-us/azure/cosmos-db/tutorial-query-documentdb)

## Lab #2
[Microsoft Azure Code Challenges - CosmosDB Lab](https://github.com/Microsoft/code-challenges/tree/master/Labs/Azure%20Cosmos%20DB)
The purpose of this second lab is to get users exposed to an existing project already using the CosmosDB SDK from .Net. They will get to tinker with the C# project and add a command to query, then understand what's happening under the hood when executing different queries. 
Supplemental Documentation: [Develop with the DocumentDB API in .NET](https://docs.microsoft.com/en-us/azure/cosmos-db/tutorial-develop-documentdb-dotnet)

# This Lab
The purpose of this lab is to deepen the knowledge gained from the above pre-requisites and provide more direct hands-on experience with the CosmosDB SDK. 

## Goals
At the end of this lab, developers should feel comfortable using the CosmosDB SDK to:

 - Initialize a connection to CosmosDB. 
 - Initialize a database and collection within CosmosDB.
 - Create queries to get one or more documents from CosmosDB. 
 - Create commands to insert and update documents in CosmosDB.

The basic data structure we're working with in this lab is a Trial Balance. Upon cloning the repository, the Trial Balance looks as follows:

```
{
    "Id": "Guid",
    "FirmGuid", "Guid",
    "EngagementName": "string"
}
```

We will setup a new database and collection (if it doesn't exist), followed by setting up the commands to insert and update our existing records, our queries to retrieve data from cosmosdb, then enhancing our queries to allow for pagination. 

## Scenario 1
At the end of this scenario, you should have initialized a connection to CosmosDB, intialized the database and collection, and finally, retrieved all documents from the collection.

 1. Clone this repository and open the solution in Visual Studio.
 2. Start up the console application by using `F5` and familiarize yourself with the actions available. 
 3. Open the `InitializeDocumentDb` class and implement the CosmosDB-specific logic to initialize a connection to CosmosDB. 
 4. In the same class, implement the logic necessary to initialize a database named `chrislabz` and a collection named `trialbalances`.
 5. Open the `GetAllTrialBalances` class and implement the CosmosDB-specific logic to get all records from the `trialbalances` collection.
 6. Run the console application and make sure you can get all TrialBalances. Initially, you should get no records. Use the CosmosDB Migration Tool to import the following JSON.

## Scenario 2
At the end of this scenario, you should be able to retrieve a specific document based on Guid. As a stretch goal, you will also implement a query to retrieve all TrialBalances that match a particular string input by the user. 

 1. Open the `GetSpecificTrialBalance` class and implement CosmosDB-specific logic to get a single record from the `trialbalances` collection based on Guid. 
 2. Start the console application and get all TrialBalances. Copy the ID of one of the TrialBalances. 
 3. Execute the flow to `Get a specific record by id` and use the ID you just copied to retrieve the record. You should see the record was retrieved successfully and see the Engagement Name. 
 4. Stop the console application and go to the `SearchTrialBalances` class. Implement the CosmosDB-specific logic to search for TrialBalances by name. You want to do a case-insensitive wildcard match based on the name. 
 5. Start the console application and execute the flow to search for TrialBalances. You should see all TrialBalances retrieved that contain the searched name. 

## Scenario 3
At the end of this scenario, you should be able to create new TrialBalance records in your `trialbalances` collection. Additionally, you'll learn how the default property names serialize to JSON, and how to specify custom property names in the documents. As a stretch, try to modify the POCO that describes a TrialBalance, add new properties, and ensure new records are created with those properties to see how those properties show up in CosmosDB. 

 1. Open the `CreateTrialBalance` class and implement the CosmosDB-specific logic to create a single record in the `trialbalances` collection.
 2. Start up the console application and create a new TrialBalance. Get all the TrialBalances and see that your record was creaetd succesfully!
 3. Close the console application and go to `Program.cs`. Go to line 53 (where the `TODO` is located) and comment out the line.
 4. Start up the console application and create a new TrialBalance. Then, attempt to retrieve the document with the created ID. 
 5. You'll notice that if you use the returned ID for the record upon creation, the query does **not** return the requested TrialBalance. 
 6. Open DocumentDB studio (or the Query Explorer thru the Portal). Execute the following query (replacing `<New ID>` with the guid returned earlier):

```
SELECT * FROM c WHERE c.id = '<New ID>'
```

You will notice the following anomaly in the record:

```
{
    "id": "<guid>",
    "Id": "<New ID>
}
```

CosmosDB by default will auto-generate an `id` for a document when one is not specified. However, your query is likely setup to be based on the `Id` column that's now shown in CosmosDB. The simplest fix: ensure that the `Id` column is mapped to the `id` column:

 7. Open the `TrialBalance` class. Use the `JsonProperty` attribute to change the `PropertName` to `id`. 
 8. Start up the console application and try step 4 again. If it succeeds, great! Do it once again, and you'll notice it fails. Why is this? 

If you've uncommented the code properly in step 3, what we've now introduced is a serialization of the `id` property in *all* cases, including when no `Guid` is specified against the `id`. The first time you create a document **without** specifying the `id`, this uses `default(Guid)` which is the same as `Guid.Empty`. The second time, it uses the same `default(guid)`, but you cannot create multiple documents with the same `id`. 

 9. Open the `TrialBalance` class again. Use the `JsonProperty` attribute to ensure that null or default values are ignored during serialization. 
 10. Repeat step 8 again. This time, multiple document creations should succeed. 

## Scenario 4
By this point, you should be pretty comfortable working with the SDK and interacting with CosmosDB. At this point, you'll flush out your knowledge by implementing update
capabilities. 

 1. Open the `UpdateTrialBalance` class and implement CosmosDB-specific logic to update an existing record. You should throw an `ArgumentException` if the requested TrialBalance does not exist. 
 2. Run the console application and verify you can update an existing TrialBalance Engagement Name. 
 3. Modify the `UpdateTrialBalanceArgs` class and add an `ETag` property. Use `JsonIgnore` to ensure the property is not serialized. 
 4. Modify `UpdateTrialBalance` and add options to the query to eforce `ETag` checks. Modify the console application to allow the `ETag` to be specified, and if so, force the check. Force a situation where you can get a `PreconditionsFailed` (e.g. the `ETag` is old).

# Supplemental Documentation
 - [.NET examples for the DocumentDB API](https://docs.microsoft.com/en-us/azure/cosmos-db/documentdb-dotnet-samples)