using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class CompanyPaymentPlan
{
    public long CompanyId { get; set; }

    public decimal MaxCpacity { get; set; }

    public int NumberOfRooms { get; set; }

    public int NumberOfUsers { get; set; }

    public int FundingScenarios { get; set; }

    public bool IsFunding { get; set; }

    public decimal Fee { get; set; }

    public byte Currency { get; set; }

    public int? CapTableDraftsNumber { get; set; }
}
