using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Jwtinvitation
{
    public string Jwttoken { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime ExpiryDateTime { get; set; }

    public DateTime FinalExpiryDateTime { get; set; }

    public string UserName { get; set; } = null!;

    public int JwtinvitationId { get; set; }

    public DateTime InvitationDate { get; set; }

    public byte? Product { get; set; }
}
