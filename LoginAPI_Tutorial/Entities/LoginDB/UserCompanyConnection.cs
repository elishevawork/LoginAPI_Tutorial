using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class UserCompanyConnection
{
    public long UserCompanyConnectionId { get; set; }

    public long UserId { get; set; }

    public long RelatedCompanyId { get; set; }

    public byte UsersPermissionForCompanyLvl { get; set; }

    public byte? IsLegalEntity { get; set; }

    public DateTime? InvitationDate { get; set; }

    public DateTime? ReminderDate { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Role { get; set; }

    public string? OrganizationName { get; set; }

    public bool IsIdPhoto { get; set; }

    public string? PrivateEmail { get; set; }

    public bool IsEmployeeProfile { get; set; }

    public string? EmployeeNumber { get; set; }

    public string? Phone { get; set; }

    public string? DailingCode { get; set; }

    public bool? IsActive { get; set; }
}
