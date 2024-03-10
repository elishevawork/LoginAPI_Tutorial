using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class User
{
    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public short? Nationality { get; set; }

    public byte? Role { get; set; }

    public string PersonalIdnumber { get; set; } = null!;

    public string? Phone { get; set; }

    public long? PivotalUserId { get; set; }

    public string? PhoneNationality { get; set; }

    public string? PassportCardId { get; set; }

    public byte? TermsOfService { get; set; }
}
