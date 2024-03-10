using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class TemporaryUser
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PersonalIdnumber { get; set; } = null!;

    public string WorkMail { get; set; } = null!;

    public byte Plan { get; set; }

    public string CreditDetails { get; set; } = null!;

    public string? ValidateGuid { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public string? MobileNumber { get; set; }

    public string? Organization { get; set; }

    public byte? Role { get; set; }

    public short? Nationality { get; set; }

    public string? Id { get; set; }

    public string? CompanyName { get; set; }

    public string? CorporateNumber { get; set; }

    public byte? TermsOfService { get; set; }

    public string? DailingCode { get; set; }
}
