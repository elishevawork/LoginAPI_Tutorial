using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class DefaultPayment
{
    public long Type { get; set; }

    public int NumberOfRooms { get; set; }

    public int MaxSizeOfFiles { get; set; }

    public int NumberOfUsers { get; set; }

    public bool IsFunding { get; set; }

    public string Description { get; set; } = null!;

    public int FundingScenarios { get; set; }

    public int? CapTableDraftsNumber { get; set; }
}
