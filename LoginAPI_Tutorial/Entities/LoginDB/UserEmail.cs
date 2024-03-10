using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class UserEmail
{
    public long EmailId { get; set; }

    public long UserId { get; set; }

    public string UserEmail1 { get; set; } = null!;

    public bool IsPrivate { get; set; }
}
