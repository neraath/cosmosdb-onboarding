using Newtonsoft.Json;
using System;

namespace FunWithCosmosDB.Model
{
    public class TrialBalance
    {
        public Guid Id { get; set; }

        public Guid FirmGuid { get; set; }

        public string EngagementName { get; set; }
    }
}
