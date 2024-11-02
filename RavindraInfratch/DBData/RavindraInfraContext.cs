using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RavindraInfratch.DBData;

public partial class RavindraInfraContext : DbContext
{
    public RavindraInfraContext()
    {
    }

    public RavindraInfraContext(DbContextOptions<RavindraInfraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminLogin> AdminLogins { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Block> Blocks { get; set; }

    public virtual DbSet<LogTblAccount> LogTblAccounts { get; set; }

    public virtual DbSet<LogTblCity> LogTblCities { get; set; }

    public virtual DbSet<LogTblCompany> LogTblCompanies { get; set; }

    public virtual DbSet<LogTblExpense> LogTblExpenses { get; set; }

    public virtual DbSet<LogTblMaster> LogTblMasters { get; set; }

    public virtual DbSet<LogTblPara> LogTblParas { get; set; }

    public virtual DbSet<LogTblUser> LogTblUsers { get; set; }

    public virtual DbSet<Paidcommission> Paidcommissions { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Plot> Plots { get; set; }

    public virtual DbSet<ProjectDb> ProjectDbs { get; set; }

    public virtual DbSet<PropertyType> PropertyTypes { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<RegistrationType> RegistrationTypes { get; set; }

    public virtual DbSet<RptAccount> RptAccounts { get; set; }

    public virtual DbSet<RptReceipt> RptReceipts { get; set; }

    public virtual DbSet<Rptplot> Rptplots { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saledirect> Saledirects { get; set; }

    public virtual DbSet<Saleteam> Saleteams { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TblTempStatement> TblTempStatements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=P3NWPLSK12SQL-v12.shr.prod.phx3.secureserver.net;Database=RavindraInfra;user id=RavindraInfra;password=Ravindra#Infra321@; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("RavindraInfra");

        modelBuilder.Entity<AdminLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AdminLogin", "dbo");

            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.Username).HasMaxLength(10);
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bank", "dbo");

            entity.Property(e => e.AccountName).HasMaxLength(50);
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Display).HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Block>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BLOCK__3214EC27F5027778");

            entity.ToTable("BLOCK");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Block1)
                .HasMaxLength(10)
                .HasColumnName("BLOCK");
        });

        modelBuilder.Entity<LogTblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("LOG_tblAccount", "dbo");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AadharBack).HasMaxLength(100);
            entity.Property(e => e.AadharFront).HasMaxLength(100);
            entity.Property(e => e.AadharNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Business).HasColumnName("BUSINESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cperson)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CPerson");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasColumnName("DISTRICT");
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("GENDER");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAN");
            entity.Property(e => e.Panphoto)
                .HasMaxLength(100)
                .HasColumnName("PANPhoto");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Photo).HasMaxLength(100);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
            entity.Property(e => e.TType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tType");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.WhatsApp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogTblCity>(entity =>
        {
            entity.ToTable("LOG_tblCity", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.MinAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PerKgrate)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PerKGRate");
            entity.Property(e => e.StateId).HasColumnName("StateID");
        });

        modelBuilder.Entity<LogTblCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("LOG_tblCompany", "dbo");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CompanyID");
            entity.Property(e => e.CompanyAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyEmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompanyEmailID");
            entity.Property(e => e.CompanyGstinNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompanyGSTinNo");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyState)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyWebsite)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnableSsl).HasColumnName("EnableSSL");
            entity.Property(e => e.Smtpclient)
                .HasMaxLength(50)
                .HasColumnName("SMTPClient");
            entity.Property(e => e.Smtpemail)
                .HasMaxLength(50)
                .HasColumnName("SMTPEmail");
            entity.Property(e => e.Smtppassword)
                .HasMaxLength(50)
                .HasColumnName("SMTPPassword");
            entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");
            entity.Property(e => e.ToEmailId)
                .HasMaxLength(50)
                .HasColumnName("ToEmailID");
        });

        modelBuilder.Entity<LogTblExpense>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_tblExpense", "dbo");

            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Remarks).HasMaxLength(150);
        });

        modelBuilder.Entity<LogTblMaster>(entity =>
        {
            entity.ToTable("LOG_tblMaster", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.FldName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fldName");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tType");
        });

        modelBuilder.Entity<LogTblPara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOG_tblP__3214EC2727F6E018");

            entity.ToTable("LOG_tblPara", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillPreFix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Cgst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CGST");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.DExp).HasColumnName("dExp");
            entity.Property(e => e.Dm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dm");
            entity.Property(e => e.Dy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dy");
            entity.Property(e => e.Gst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GST");
            entity.Property(e => e.Igst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IGST");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.Sgst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SGST");
        });

        modelBuilder.Entity<LogTblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("LOG_tblUsers", "dbo");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AccessType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EditedDate).HasColumnType("datetime");
            entity.Property(e => e.FldName)
                .HasMaxLength(50)
                .HasColumnName("fldName");
            entity.Property(e => e.FldPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fldPassword");
            entity.Property(e => e.FldUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fldUserName");
        });

        modelBuilder.Entity<Paidcommission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAIDCOMM__3214EC2713C07D8F");

            entity.ToTable("PAIDCOMMISSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Bankname)
                .HasMaxLength(50)
                .HasColumnName("BANKNAME");
            entity.Property(e => e.Branchname)
                .HasMaxLength(50)
                .HasColumnName("BRANCHNAME");
            entity.Property(e => e.Cheque)
                .HasMaxLength(50)
                .HasColumnName("CHEQUE");
            entity.Property(e => e.Chequedate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQUEDATE");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.Paymode)
                .HasMaxLength(50)
                .HasColumnName("PAYMODE");
            entity.Property(e => e.Ref).HasColumnName("REF");
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
            entity.Property(e => e.Upi)
                .HasMaxLength(100)
                .HasColumnName("UPI");
            entity.Property(e => e.Utr)
                .HasMaxLength(150)
                .HasColumnName("UTR");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PHOTOS__3214EC27FECB1B82");

            entity.ToTable("PHOTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Purchaseid).HasColumnName("PURCHASEID");
            entity.Property(e => e.Tpath)
                .HasMaxLength(100)
                .HasColumnName("TPATH");
            entity.Property(e => e.Ttype)
                .HasMaxLength(10)
                .HasColumnName("TTYPE");
        });

        modelBuilder.Entity<Plot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PLOT__3214EC271C21C094");

            entity.ToTable("PLOT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Blockid).HasColumnName("BLOCKID");
            entity.Property(e => e.PlotSize).HasMaxLength(20);
            entity.Property(e => e.Plots).HasColumnName("PLOTS");
            entity.Property(e => e.Projectid).HasColumnName("PROJECTID");
            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");
        });

        modelBuilder.Entity<ProjectDb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__project__3214EC271CE00E54");

            entity.ToTable("projectDB", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<PropertyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Property__3214EC2787E78F37");

            entity.ToTable("PropertyType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TType)
                .HasMaxLength(50)
                .HasColumnName("tTYPE");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PURCHASE__3214EC2796BC81E5");

            entity.ToTable("PURCHASE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aarajino)
                .HasMaxLength(20)
                .HasColumnName("AARAJINO");
            entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");
            entity.Property(e => e.Advanceamoutn).HasColumnName("ADVANCEAMOUTN");
            entity.Property(e => e.Advocatefee).HasColumnName("ADVOCATEFee");
            entity.Property(e => e.Advocateid).HasColumnName("ADVOCATEID");
            entity.Property(e => e.Advocatename)
                .HasMaxLength(50)
                .HasColumnName("ADVOCATENAME");
            entity.Property(e => e.Agreementdeadline)
                .HasMaxLength(50)
                .HasColumnName("AGREEMENTDEADLINE");
            entity.Property(e => e.Area).HasColumnName("AREA");
            entity.Property(e => e.BankAccount).HasMaxLength(20);
            entity.Property(e => e.Bankname)
                .HasMaxLength(50)
                .HasColumnName("BANKNAME");
            entity.Property(e => e.Banknoc)
                .HasMaxLength(100)
                .HasColumnName("BANKNOC");
            entity.Property(e => e.Branchname)
                .HasMaxLength(50)
                .HasColumnName("BRANCHNAME");
            entity.Property(e => e.Cheque).HasMaxLength(50);
            entity.Property(e => e.Chequedate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQUEDATE");
            entity.Property(e => e.Courtfee).HasColumnName("COURTFEE");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deed)
                .HasMaxLength(50)
                .HasColumnName("DEED");
            entity.Property(e => e.Dueamount).HasColumnName("DUEAMOUNT");
            entity.Property(e => e.Editeddate)
                .HasColumnType("datetime")
                .HasColumnName("EDITEDDATE");
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.Inspection1291)
                .HasMaxLength(100)
                .HasColumnName("INSPECTION1291");
            entity.Property(e => e.Inspection1356)
                .HasMaxLength(100)
                .HasColumnName("INSPECTION1356");
            entity.Property(e => e.Khasra)
                .HasMaxLength(100)
                .HasColumnName("KHASRA");
            entity.Property(e => e.Khatauni)
                .HasMaxLength(100)
                .HasColumnName("KHATAUNI");
            entity.Property(e => e.Lekhpalmobile)
                .HasMaxLength(15)
                .HasColumnName("LEKHPALMOBILE");
            entity.Property(e => e.Lekhpalname)
                .HasMaxLength(50)
                .HasColumnName("LEKHPALNAME");
            entity.Property(e => e.Najrinaksha)
                .HasMaxLength(100)
                .HasColumnName("NAJRINAKSHA");
            entity.Property(e => e.Oldagreement)
                .HasMaxLength(100)
                .HasColumnName("OLDAGREEMENT");
            entity.Property(e => e.Photoid).HasColumnName("PHOTOID");
            entity.Property(e => e.Process).HasColumnName("PROCESS");
            entity.Property(e => e.Rasid)
                .HasMaxLength(100)
                .HasColumnName("RASID");
            entity.Property(e => e.Sala12)
                .HasMaxLength(100)
                .HasColumnName("SALA12");
            entity.Property(e => e.Shareholder)
                .HasMaxLength(250)
                .HasColumnName("SHAREHOLDER");
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
            entity.Property(e => e.Stamp)
                .HasMaxLength(100)
                .HasColumnName("STAMP");
            entity.Property(e => e.Upi)
                .HasMaxLength(50)
                .HasColumnName("UPI");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RECEIPT__3214EC2717497F15");

            entity.ToTable("RECEIPT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Blockid).HasColumnName("BLOCKID");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Dueamount).HasColumnName("DUEAMOUNT");
            entity.Property(e => e.Editeddate)
                .HasColumnType("datetime")
                .HasColumnName("EDITEDDATE");
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Plotno)
                .HasMaxLength(10)
                .HasColumnName("PLOTNO");
            entity.Property(e => e.Projectid).HasColumnName("PROJECTID");
            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");
            entity.Property(e => e.Receiptno).HasColumnName("RECEIPTNO");
            entity.Property(e => e.Receivedamount).HasColumnName("RECEIVEDAMOUNT");
            entity.Property(e => e.Saleid).HasColumnName("SALEID");
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
        });

        modelBuilder.Entity<RegistrationType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RegistrationType");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.RegType).HasMaxLength(20);
        });

        modelBuilder.Entity<RptAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("rptAccount", "dbo");

            entity.Property(e => e.AadharBack).HasMaxLength(100);
            entity.Property(e => e.AadharFront).HasMaxLength(100);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ACTIVE");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Business).HasColumnName("BUSINESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Panphoto)
                .HasMaxLength(100)
                .HasColumnName("PANPhoto");
            entity.Property(e => e.Photo).HasMaxLength(100);
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
            entity.Property(e => e.Sponsorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SPONSORNAME");
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.TType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tType");
            entity.Property(e => e.WhatsApp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RptReceipt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("rptRECEIPT");

            entity.Property(e => e.Aarajino)
                .HasMaxLength(50)
                .HasColumnName("AARAJINO");
            entity.Property(e => e.Accountname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTNAME");
            entity.Property(e => e.Accountno)
                .HasMaxLength(25)
                .HasColumnName("ACCOUNTNO");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Bankname)
                .HasMaxLength(50)
                .HasColumnName("BANKNAME");
            entity.Property(e => e.Branchname)
                .HasMaxLength(50)
                .HasColumnName("BRANCHNAME");
            entity.Property(e => e.Chauhaddi)
                .HasMaxLength(50)
                .HasColumnName("CHAUHADDI");
            entity.Property(e => e.Cheque).HasMaxLength(50);
            entity.Property(e => e.Chequedate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQUEDATE");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .HasColumnName("DIRECTION");
            entity.Property(e => e.Dueamount).HasColumnName("DUEAMOUNT");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Plot)
                .HasMaxLength(63)
                .HasColumnName("PLOT");
            entity.Property(e => e.Plotsize)
                .HasMaxLength(20)
                .HasColumnName("PLOTSIZE");
            entity.Property(e => e.Receiptno)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("RECEIPTNO");
            entity.Property(e => e.Receivedamount).HasColumnName("RECEIVEDAMOUNT");
            entity.Property(e => e.Upi)
                .HasMaxLength(50)
                .HasColumnName("UPI");
        });

        modelBuilder.Entity<Rptplot>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RPTPLOT");

            entity.Property(e => e.Block)
                .HasMaxLength(10)
                .HasColumnName("BLOCK");
            entity.Property(e => e.BlockId).HasColumnName("BlockID");
            entity.Property(e => e.PlotSize).HasMaxLength(20);
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.Projectid).HasColumnName("PROJECTID");
            entity.Property(e => e.Properytid).HasColumnName("PROPERYTID");
            entity.Property(e => e.TType)
                .HasMaxLength(50)
                .HasColumnName("tType");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SALE__3214EC27C866D276");

            entity.ToTable("SALE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aarajino)
                .HasMaxLength(50)
                .HasColumnName("AARAJINO");
            entity.Property(e => e.Accountno)
                .HasMaxLength(25)
                .HasColumnName("ACCOUNTNO");
            entity.Property(e => e.Advanceamoutn).HasColumnName("ADVANCEAMOUTN");
            entity.Property(e => e.Bankname)
                .HasMaxLength(50)
                .HasColumnName("BANKNAME");
            entity.Property(e => e.Blockid).HasColumnName("BLOCKID");
            entity.Property(e => e.Branchname)
                .HasMaxLength(50)
                .HasColumnName("BRANCHNAME");
            entity.Property(e => e.Chauhaddi)
                .HasMaxLength(50)
                .HasColumnName("CHAUHADDI");
            entity.Property(e => e.Cheque).HasMaxLength(50);
            entity.Property(e => e.Chequedate)
                .HasColumnType("datetime")
                .HasColumnName("CHEQUEDATE");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Customerfeedback)
                .HasMaxLength(500)
                .HasColumnName("CUSTOMERFEEDBACK");
            entity.Property(e => e.Customerid).HasColumnName("CUSTOMERID");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .HasColumnName("DIRECTION");
            entity.Property(e => e.Dueamount).HasColumnName("DUEAMOUNT");
            entity.Property(e => e.Editeddate)
                .HasColumnType("datetime")
                .HasColumnName("EDITEDDATE");
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.Loancustomerfull)
                .HasMaxLength(100)
                .HasColumnName("LOANCUSTOMERFULL");
            entity.Property(e => e.Loansalaryslip)
                .HasMaxLength(100)
                .HasColumnName("LOANSALARYSLIP");
            entity.Property(e => e.Plotno)
                .HasMaxLength(10)
                .HasColumnName("PLOTNO");
            entity.Property(e => e.Plotsize)
                .HasMaxLength(20)
                .HasColumnName("PLOTSIZE");
            entity.Property(e => e.Profit).HasColumnName("PROFIT");
            entity.Property(e => e.Projectid).HasColumnName("PROJECTID");
            entity.Property(e => e.Propertydetails)
                .HasMaxLength(250)
                .HasColumnName("PROPERTYDETAILS");
            entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");
            entity.Property(e => e.Saccountno)
                .HasMaxLength(25)
                .HasColumnName("SACCOUNTNO");
            entity.Property(e => e.Saletype)
                .HasMaxLength(10)
                .HasColumnName("SALETYPE");
            entity.Property(e => e.Sbankname)
                .HasMaxLength(50)
                .HasColumnName("SBANKNAME");
            entity.Property(e => e.Sbranchname)
                .HasMaxLength(50)
                .HasColumnName("SBRANCHNAME");
            entity.Property(e => e.Scheque)
                .HasMaxLength(50)
                .HasColumnName("SCheque");
            entity.Property(e => e.Schequedate)
                .HasColumnType("datetime")
                .HasColumnName("SCHEQUEDATE");
            entity.Property(e => e.Sfinalcommission).HasColumnName("SFINALCOMMISSION");
            entity.Property(e => e.Sifsc)
                .HasMaxLength(50)
                .HasColumnName("SIFSC");
            entity.Property(e => e.Sponsorcommision).HasColumnName("SPONSORCOMMISION");
            entity.Property(e => e.Sponsorid).HasColumnName("SPONSORID");
            entity.Property(e => e.Supi)
                .HasMaxLength(50)
                .HasColumnName("SUPI");
            entity.Property(e => e.Upi)
                .HasMaxLength(50)
                .HasColumnName("UPI");
        });

        modelBuilder.Entity<Saledirect>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SALEDIRECT");

            entity.Property(e => e.Aarajino)
                .HasMaxLength(50)
                .HasColumnName("AARAJINO");
            entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");
            entity.Property(e => e.Accountname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTNAME");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Block).HasMaxLength(10);
            entity.Property(e => e.Createddate).HasColumnType("datetime");
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Plotno).HasMaxLength(10);
            entity.Property(e => e.Plotsize).HasMaxLength(20);
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.Propertydetails)
                .HasMaxLength(250)
                .HasColumnName("PROPERTYDETAILS");
            entity.Property(e => e.Saletype)
                .HasMaxLength(10)
                .HasColumnName("SALETYPE");
            entity.Property(e => e.Sponsorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SPONSORNAME");
            entity.Property(e => e.Ttype)
                .HasMaxLength(50)
                .HasColumnName("TType");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WHATSAPP");
        });

        modelBuilder.Entity<Saleteam>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SALETEAM");

            entity.Property(e => e.Aarajino)
                .HasMaxLength(50)
                .HasColumnName("AARAJINO");
            entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");
            entity.Property(e => e.Accountname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTNAME");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Block).HasMaxLength(10);
            entity.Property(e => e.Createddate).HasColumnType("datetime");
            entity.Property(e => e.Finalamount).HasColumnName("FINALAMOUNT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
            entity.Property(e => e.Plotno).HasMaxLength(10);
            entity.Property(e => e.Plotsize).HasMaxLength(20);
            entity.Property(e => e.ProjectName).HasMaxLength(50);
            entity.Property(e => e.Propertydetails)
                .HasMaxLength(250)
                .HasColumnName("PROPERTYDETAILS");
            entity.Property(e => e.Saletype)
                .HasMaxLength(10)
                .HasColumnName("SALETYPE");
            entity.Property(e => e.Snrid).HasColumnName("SNRID");
            entity.Property(e => e.Sponsorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SPONSORNAME");
            entity.Property(e => e.Ttype)
                .HasMaxLength(50)
                .HasColumnName("TType");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WHATSAPP");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.State1)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.StateCode).HasMaxLength(5);
        });

        modelBuilder.Entity<TblTempStatement>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblTempStatement", "dbo");

            entity.Property(e => e.Amt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("iDate");
            entity.Property(e => e.ODate)
                .HasColumnType("datetime")
                .HasColumnName("oDate");
            entity.Property(e => e.PartyName).HasMaxLength(200);
            entity.Property(e => e.PaymentRecAmt).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
