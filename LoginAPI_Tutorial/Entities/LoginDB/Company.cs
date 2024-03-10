using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Company
{
    public long CompanyId { get; set; }

    public string CompanyLegalName { get; set; } = null!;

    public int? CompanyNumber { get; set; }

    public string? Website { get; set; }

    public string? BusinessDescription { get; set; }

    public int? Nationallity { get; set; }

    public int? Industry { get; set; }

    public DateTime? FormationDate { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? PaidUntil { get; set; }

    public string? Status { get; set; }

    public int? NoOfEmployees { get; set; }

    public long? CompanyAdminUserId { get; set; }

    public byte? AccessDataRoomLvl { get; set; }

    public byte? AccessCapTableLvl { get; set; }

    public byte? AccessPivotalLvl { get; set; }

    public bool? IsLogoExist { get; set; }

    public int Currency { get; set; }

    public int? CustomerId { get; set; }

    public string? PivotalToken { get; set; }
}
