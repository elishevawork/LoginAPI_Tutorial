using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class UsersNotification
{
    public string? CompanyName { get; set; }

    public string? DataRoomName { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? SendToMail { get; set; }

    public string? SendToUserName { get; set; }

    public string? UploadDocumentUserName { get; set; }

    public long Id { get; set; }

    public long CreatedBy { get; set; }

    public long DataRoomId { get; set; }

    public long CompanyId { get; set; }
}
