using FunWithCosmosDB.Interfaces;
using System;
using Microsoft.Azure.Documents;

namespace FunWithCosmosDB.DocumentDB
{
    public class InitializeDocumentDb : IInitialize
    {
        public IDocumentClient InitializeClient()
        {
            throw new NotImplementedException();
        }
    }
}
