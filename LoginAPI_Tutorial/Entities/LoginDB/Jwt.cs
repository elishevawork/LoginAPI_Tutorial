using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Jwt
{
    public string Jwttoken { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime ExpiryDateTime { get; set; }

    public DateTime FinalExpiryDateTime { get; set; }

    public int Jwtid { get; set; }
}
