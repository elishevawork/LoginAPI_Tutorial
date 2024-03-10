using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class Invitation
{
    public int InvitationId { get; set; }

    public int SourceUserId { get; set; }

    public string Application { get; set; } = null!;

    public string UniqueKey { get; set; } = null!;

    public int CompanyId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
}
