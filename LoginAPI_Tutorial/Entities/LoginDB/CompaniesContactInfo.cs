using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class CompaniesContactInfo
{
    public long CompanyId { get; set; }

    public string CompanyEmailAddress { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Role { get; set; }

    public int? Nationality { get; set; }

    public string? Id { get; set; }

    public string? OrganizationName { get; set; }

    public string? PhonePrefix { get; set; }
}
