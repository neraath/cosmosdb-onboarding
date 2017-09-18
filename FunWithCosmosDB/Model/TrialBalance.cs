using Newtonsoft.Json;
using System;

namespace FunWithCosmosDB.Model
{
    public class TrialBalance
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Id { get; set; }

        public Guid FirmGuid { get; set; }

        public string EngagementName { get; set; }
    }
}
