using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class LoginDbContext : DbContext
{
    public LoginDbContext()
    {
    }

    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompaniesContactInfo> CompaniesContactInfos { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyPaymentPlan> CompanyPaymentPlans { get; set; }

    public virtual DbSet<CurrencysList> CurrencysLists { get; set; }

    public virtual DbSet<DefaultPayment> DefaultPayments { get; set; }

    public virtual DbSet<GlobalParam> GlobalParams { get; set; }

    public virtual DbSet<ImportExcelStaticCode> ImportExcelStaticCodes { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<InvetationUser> InvetationUsers { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Jwt> Jwts { get; set; }

    public virtual DbSet<Jwtinvitation> Jwtinvitations { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<Otpregistration> Otpregistrations { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TemporaryUser> TemporaryUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCompanyConnection> UserCompanyConnections { get; set; }

    public virtual DbSet<UserEmail> UserEmails { get; set; }

    public virtual DbSet<UsersNotification> UsersNotifications { get; set; }

    public virtual DbSet<UsersPermissionForCompany> UsersPermissionForCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=LoginDB;Data Source=localhost\\SQLEXPRESS;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompaniesContactInfo>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.CompanyEmailAddress });

            entity.ToTable("CompaniesContactInfo");

            entity.Property(e => e.CompanyEmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OrganizationName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.PhonePrefix).HasMaxLength(5);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.AccessCapTableLvl).HasColumnName("AccessCapTableLVL");
            entity.Property(e => e.AccessDataRoomLvl).HasColumnName("AccessDataRoomLVL");
            entity.Property(e => e.AccessPivotalLvl).HasColumnName("AccessPivotalLVL");
            entity.Property(e => e.BusinessDescription).HasMaxLength(2000);
            entity.Property(e => e.CompanyAdminUserId).HasColumnName("CompanyAdminUserID");
            entity.Property(e => e.CompanyLegalName).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("date");
            entity.Property(e => e.FormationDate).HasColumnType("date");
            entity.Property(e => e.PaidUntil).HasColumnType("date");
            entity.Property(e => e.PivotalToken)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("pivotal_token");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Active')");
            entity.Property(e => e.Website).HasMaxLength(200);
        });

        modelBuilder.Entity<CompanyPaymentPlan>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_osher");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();
            entity.Property(e => e.CapTableDraftsNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.Fee).HasColumnType("money");
            entity.Property(e => e.MaxCpacity).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<CurrencysList>(entity =>
        {
            entity.HasKey(e => e.CurrencyId);

            entity.ToTable("CurrencysList");

            entity.Property(e => e.CurrencyId)
                .ValueGeneratedNever()
                .HasColumnName("CurrencyID");
            entity.Property(e => e.CurrencyDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<DefaultPayment>(entity =>
        {
            entity.HasKey(e => e.Type);

            entity.ToTable("DefaultPayment");

            entity.Property(e => e.Type).ValueGeneratedNever();
            entity.Property(e => e.CapTableDraftsNumber).HasDefaultValueSql("((0))");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GlobalParam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GlobalParam");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Value).HasMaxLength(500);
        });

        modelBuilder.Entity<ImportExcelStaticCode>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Code).HasMaxLength(200);
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("Industry");

            entity.Property(e => e.IndustryId).ValueGeneratedNever();
            entity.Property(e => e.Industry1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Industry");
        });

        modelBuilder.Entity<InvetationUser>(entity =>
        {
            entity.Property(e => e.InvetationUserId).HasColumnName("InvetationUserID");
            entity.Property(e => e.InvetationDate).HasColumnType("date");
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.ToTable("invitation");

            entity.Property(e => e.InvitationId).HasColumnName("invitation_id");
            entity.Property(e => e.Application)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("application");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.SourceUserId).HasColumnName("source_user_id");
            entity.Property(e => e.UniqueKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unique_key");
        });

        modelBuilder.Entity<Jwt>(entity =>
        {
            entity.ToTable("JWT");

            entity.Property(e => e.Jwtid).HasColumnName("JWTID");
            entity.Property(e => e.ExpiryDateTime).HasColumnType("datetime");
            entity.Property(e => e.FinalExpiryDateTime).HasColumnType("datetime");
            entity.Property(e => e.Jwttoken)
                .HasMaxLength(300)
                .HasColumnName("JWTToken");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Jwtinvitation>(entity =>
        {
            entity.ToTable("JWTInvitation");

            entity.Property(e => e.JwtinvitationId).HasColumnName("JWTInvitationID");
            entity.Property(e => e.ExpiryDateTime).HasColumnType("datetime");
            entity.Property(e => e.FinalExpiryDateTime).HasColumnType("datetime");
            entity.Property(e => e.InvitationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("invitation_date");
            entity.Property(e => e.Jwttoken)
                .HasMaxLength(300)
                .HasColumnName("JWTToken");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(300);
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.ToTable("Nationality");

            entity.Property(e => e.Nationality1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Nationality");
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.ToTable("OTP");

            entity.Property(e => e.Otpid).HasColumnName("OTPID");
            entity.Property(e => e.Guid)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.OtpcreateDate).HasColumnName("OTPCreateDate");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .HasColumnName("password");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Otpregistration>(entity =>
        {
            entity.HasKey(e => e.Otpid);

            entity.ToTable("OTPRegistration");

            entity.Property(e => e.Otpid).HasColumnName("OTPID");
            entity.Property(e => e.Guid)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.OtpcreateDate).HasColumnName("OTPCreateDate");
            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.TempUserId).HasColumnName("TempUserID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Status");
        });

        modelBuilder.Entity<TemporaryUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_TemporaryUsersID");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CompanyName).HasMaxLength(9);
            entity.Property(e => e.CorporateNumber).HasMaxLength(9);
            entity.Property(e => e.CreditDetails).HasMaxLength(50);
            entity.Property(e => e.DailingCode).HasMaxLength(10);
            entity.Property(e => e.ExpiredDate).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .HasColumnName("ID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Organization).HasMaxLength(50);
            entity.Property(e => e.PersonalIdnumber)
                .HasMaxLength(20)
                .HasColumnName("PersonalIDNumber");
            entity.Property(e => e.TermsOfService).HasDefaultValueSql("((0))");
            entity.Property(e => e.ValidateGuid)
                .HasMaxLength(50)
                .HasColumnName("ValidateGUID");
            entity.Property(e => e.WorkMail).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PassportCardId).HasMaxLength(20);
            entity.Property(e => e.PersonalIdnumber)
                .HasMaxLength(40)
                .HasColumnName("PersonalIDNumber");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhoneNationality).HasMaxLength(10);
            entity.Property(e => e.TermsOfService).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<UserCompanyConnection>(entity =>
        {
            entity.HasKey(e => e.UserCompanyConnectionId).HasName("PK_UserCompanyConnectionID");

            entity.ToTable("UserCompanyConnection");

            entity.Property(e => e.UserCompanyConnectionId).HasColumnName("UserCompanyConnectionID");
            entity.Property(e => e.DailingCode).HasMaxLength(10);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(200)
                .HasColumnName("employee_number");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.InvitationDate)
                .HasDefaultValueSql("('1900-1-1')")
                .HasColumnType("date");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.IsEmployeeProfile).HasColumnName("is_employee_profile");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OrganizationName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PrivateEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("private_email");
            entity.Property(e => e.RelatedCompanyId).HasColumnName("RelatedCompanyID");
            entity.Property(e => e.ReminderDate)
                .HasDefaultValueSql("('1900-1-1')")
                .HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UsersPermissionForCompanyLvl).HasColumnName("UsersPermissionForCompanyLVL");
        });

        modelBuilder.Entity<UserEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK_EmailID");

            entity.ToTable("UserEmail");

            entity.HasIndex(e => e.UserEmail1, "UQ__UserEmai__08638DF8C3A1CD34").IsUnique();

            entity.Property(e => e.EmailId).HasColumnName("EmailID");
            entity.Property(e => e.UserEmail1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("UserEmail");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<UsersNotification>(entity =>
        {
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyName).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DataRoomId).HasColumnName("data_room_id");
            entity.Property(e => e.DataRoomName).HasMaxLength(200);
            entity.Property(e => e.SendToMail).HasMaxLength(200);
            entity.Property(e => e.SendToUserName).HasMaxLength(200);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UploadDocumentUserName).HasMaxLength(200);
        });

        modelBuilder.Entity<UsersPermissionForCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsersPermissionForCompany");

            entity.Property(e => e.PermissionDescription).HasMaxLength(50);
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
