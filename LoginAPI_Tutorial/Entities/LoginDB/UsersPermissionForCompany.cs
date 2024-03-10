using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class UsersPermissionForCompany
{
    public byte PermissionId { get; set; }

    public string PermissionDescription { get; set; } = null!;
}
