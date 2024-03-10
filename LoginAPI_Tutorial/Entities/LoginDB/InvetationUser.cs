using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class InvetationUser
{
    public long InvetationUserId { get; set; }

    public string Token { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime InvetationDate { get; set; }
}
