using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Otp
{
    public DateTime OtpcreateDate { get; set; }

    public int NumOfHacks { get; set; }

    public string Guid { get; set; } = null!;

    public long UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public int Otpid { get; set; }

    public string Password { get; set; } = null!;
}
