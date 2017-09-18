using FunWithCosmosDB.Model;
using System;
using System.Collections.Generic;

namespace FunWithCosmosDB.Stubs
{
    public static class StaticCollection
    {
        public static List<TrialBalance> Records = new List<TrialBalance>()
        {
            new TrialBalance() { Id = Guid.NewGuid(), FirmGuid = Guid.NewGuid(), EngagementName = "Engagement #1" },
            new TrialBalance() { Id = Guid.NewGuid(), FirmGuid = Guid.NewGuid(), EngagementName = "Sample Engagement" },
            new TrialBalance() { Id = Guid.NewGuid(), FirmGuid = Guid.NewGuid(), EngagementName = "Real Audit" }
        };
    }
}
