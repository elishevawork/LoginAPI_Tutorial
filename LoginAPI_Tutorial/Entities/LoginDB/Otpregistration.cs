using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Otpregistration
{
    public DateTime OtpcreateDate { get; set; }

    public int NumOfHacks { get; set; }

    public string Guid { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public int TempUserId { get; set; }

    public int Otpid { get; set; }

    public string? Password { get; set; }
}
