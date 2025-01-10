using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class CarRentalContext : DbContext
{
    public CarRentalContext()
    {
    }

    public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbAutomaker> TbAutomakers { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbBlogComment> TbBlogComments { get; set; }

    public virtual DbSet<TbBooking> TbBookings { get; set; }

    public virtual DbSet<TbBranch> TbBranches { get; set; }

    public virtual DbSet<TbBrokenCar> TbBrokenCars { get; set; }

    public virtual DbSet<TbCar> TbCars { get; set; }

    public virtual DbSet<TbCarReview> TbCarReviews { get; set; }

    public virtual DbSet<TbContract> TbContracts { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbDriverCapability> TbDriverCapabilities { get; set; }

    public virtual DbSet<TbFuel> TbFuels { get; set; }

    public virtual DbSet<TbGearbox> TbGearboxes { get; set; }

    public virtual DbSet<TbImportHistory> TbImportHistories { get; set; }

    public virtual DbSet<TbLiquidation> TbLiquidations { get; set; }

    public virtual DbSet<TbMaintenanceHistory> TbMaintenanceHistories { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbNotificalAdmin> TbNotificalAdmins { get; set; }

    public virtual DbSet<TbProductionModel> TbProductionModels { get; set; }

    public virtual DbSet<TbReceiver> TbReceivers { get; set; }

    public virtual DbSet<TbStaff> TbStaffs { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbTestimonial> TbTestimonials { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source= HONEY\\MSSQLSERVER01; initial catalog=CarRental; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.HasKey(e => e.Idadmin);

            entity.ToTable("TB_Admin");

            entity.Property(e => e.Idadmin).HasColumnName("IDAdmin");
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbAutomaker>(entity =>
        {
            entity.HasKey(e => e.Idautomaker);

            entity.ToTable("TB_Automaker");

            entity.Property(e => e.Idautomaker).HasColumnName("IDAutomaker");
            entity.Property(e => e.AutomakerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.Idblog);

            entity.ToTable("TB_Blog");

            entity.Property(e => e.Idblog).HasColumnName("IDBlog");
            entity.Property(e => e.Idadmin).HasColumnName("IDAdmin");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PublishTime).HasColumnType("datetime");

            entity.HasOne(d => d.IdadminNavigation).WithMany(p => p.TbBlogs)
                .HasForeignKey(d => d.Idadmin)
                .HasConstraintName("FK_TB_Blog_TB_Admin1");
        });

        modelBuilder.Entity<TbBlogComment>(entity =>
        {
            entity.HasKey(e => e.Idcomment);

            entity.ToTable("TB_BlogComment");

            entity.Property(e => e.Idcomment).HasColumnName("IDComment");
            entity.Property(e => e.Idblog).HasColumnName("IDBlog");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.IdblogNavigation).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.Idblog)
                .HasConstraintName("FK_TB_BlogComment_TB_Blog");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.TbBlogComments)
                .HasForeignKey(d => d.Idcustomer)
                .HasConstraintName("FK_TB_BlogComment_TB_Customer");
        });

        modelBuilder.Entity<TbBooking>(entity =>
        {
            entity.HasKey(e => e.Idbooking);

            entity.ToTable("TB_Booking");

            entity.Property(e => e.Idbooking).HasColumnName("IDBooking");
            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");
            entity.Property(e => e.BookingTime).HasColumnType("datetime");
            entity.Property(e => e.Idbranch).HasColumnName("IDBranch");
            entity.Property(e => e.Idcar).HasColumnName("IDCar");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.IdbranchNavigation).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.Idbranch)
                .HasConstraintName("FK_TB_Booking_TB_Branch");

            entity.HasOne(d => d.IdcarNavigation).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.Idcar)
                .HasConstraintName("FK_TB_Booking_TB_Car");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.TbBookings)
                .HasForeignKey(d => d.Idcustomer)
                .HasConstraintName("FK_TB_Booking_TB_Customer");
        });

        modelBuilder.Entity<TbBranch>(entity =>
        {
            entity.HasKey(e => e.Idbranch);

            entity.ToTable("TB_Branch");

            entity.Property(e => e.Idbranch).HasColumnName("IDBranch");
            entity.Property(e => e.Adress).HasMaxLength(500);
            entity.Property(e => e.NameBranch).HasMaxLength(200);
        });

        modelBuilder.Entity<TbBrokenCar>(entity =>
        {
            entity.HasKey(e => e.IdbrokenCar);

            entity.ToTable("TB_BrokenCar");

            entity.Property(e => e.IdbrokenCar).HasColumnName("IDBrokenCar");
            entity.Property(e => e.Idcar).HasColumnName("IDCar");

            entity.HasOne(d => d.IdcarNavigation).WithMany(p => p.TbBrokenCars)
                .HasForeignKey(d => d.Idcar)
                .HasConstraintName("FK_TB_BrokenCar_TB_Car");
        });

        modelBuilder.Entity<TbCar>(entity =>
        {
            entity.HasKey(e => e.Idcar);

            entity.ToTable("TB_Car");

            entity.Property(e => e.Idcar).HasColumnName("IDCar");
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.IdproductionModel).HasColumnName("IDProductionModel");
            entity.Property(e => e.Image).HasMaxLength(50);

            entity.HasOne(d => d.IdproductionModelNavigation).WithMany(p => p.TbCars)
                .HasForeignKey(d => d.IdproductionModel)
                .HasConstraintName("FK_TB_Car_TB_ProductionModel");
        });

        modelBuilder.Entity<TbCarReview>(entity =>
        {
            entity.HasKey(e => e.IdcarReview).HasName("PK_Table_1");

            entity.ToTable("TB_CarReview");

            entity.Property(e => e.IdcarReview).HasColumnName("IDCarReview");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Review).HasMaxLength(50);
        });

        modelBuilder.Entity<TbContract>(entity =>
        {
            entity.HasKey(e => e.Idcontract);

            entity.ToTable("TB_Contract");

            entity.Property(e => e.Idcontract).HasColumnName("IDContract");
            entity.Property(e => e.ContractPrice)
                .HasColumnType("money")
                .HasColumnName("Contract_Price");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Idadmin).HasColumnName("IDAdmin");
            entity.Property(e => e.Idcar).HasColumnName("IDCar");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.RentalDate).HasColumnName("Rental_Date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdadminNavigation).WithMany(p => p.TbContracts)
                .HasForeignKey(d => d.Idadmin)
                .HasConstraintName("FK_TB_Contract_TB_Admin");

            entity.HasOne(d => d.IdcarNavigation).WithMany(p => p.TbContracts)
                .HasForeignKey(d => d.Idcar)
                .HasConstraintName("FK_TB_Contract_TB_Car1");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.TbContracts)
                .HasForeignKey(d => d.Idcustomer)
                .HasConstraintName("FK_TB_Contract_TB_Customer");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.Idcustomer);

            entity.ToTable("TB_Customer");

            entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Idcard)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDCard");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbDriverCapability>(entity =>
        {
            entity.HasKey(e => e.IddriverCapabilities).HasName("PK_ID_DriverCapabilities");

            entity.ToTable("TB_DriverCapabilities");

            entity.Property(e => e.IddriverCapabilities).HasColumnName("IDDriverCapabilities");
            entity.Property(e => e.DriverCapabilitiesName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbFuel>(entity =>
        {
            entity.HasKey(e => e.Idfuel);

            entity.ToTable("TB_Fuel");

            entity.Property(e => e.Idfuel).HasColumnName("IDFuel");
            entity.Property(e => e.FuelName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbGearbox>(entity =>
        {
            entity.HasKey(e => e.Idgearbox);

            entity.ToTable("TB_Gearbox");

            entity.Property(e => e.Idgearbox).HasColumnName("IDGearbox");
            entity.Property(e => e.GearboxName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbImportHistory>(entity =>
        {
            entity.HasKey(e => e.Idimport);

            entity.ToTable("TB_ImportHistory");

            entity.Property(e => e.Idimport).HasColumnName("IDImport");
            entity.Property(e => e.Idcar).HasColumnName("IDCar");
            entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");

            entity.HasOne(d => d.IdcarNavigation).WithMany(p => p.TbImportHistories)
                .HasForeignKey(d => d.Idcar)
                .HasConstraintName("FK_TB_ImportHistory_TB_Car");

            entity.HasOne(d => d.IdsupplierNavigation).WithMany(p => p.TbImportHistories)
                .HasForeignKey(d => d.Idsupplier)
                .HasConstraintName("FK_TB_ImportHistory_TB_Supplier");
        });

        modelBuilder.Entity<TbLiquidation>(entity =>
        {
            entity.HasKey(e => e.Idliquidation);

            entity.ToTable("TB_Liquidation");

            entity.Property(e => e.Idliquidation).HasColumnName("IDLiquidation");
            entity.Property(e => e.ClearancePrice).HasColumnType("money");
            entity.Property(e => e.Idcar).HasColumnName("IDCar");
            entity.Property(e => e.Idreceiver).HasColumnName("IDReceiver");

            entity.HasOne(d => d.IdcarNavigation).WithMany(p => p.TbLiquidations)
                .HasForeignKey(d => d.Idcar)
                .HasConstraintName("FK_TB_Liquidation_TB_Car");

            entity.HasOne(d => d.IdreceiverNavigation).WithMany(p => p.TbLiquidations)
                .HasForeignKey(d => d.Idreceiver)
                .HasConstraintName("FK_TB_Liquidation_TB_Receiver");
        });

        modelBuilder.Entity<TbMaintenanceHistory>(entity =>
        {
            entity.HasKey(e => e.Idmaintenance).HasName("PK_MaintenanceHistory");

            entity.ToTable("TB_MaintenanceHistory");

            entity.Property(e => e.Idmaintenance).HasColumnName("IDMaintenance");
            entity.Property(e => e.Idcontract).HasColumnName("IDContract");
            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");

            entity.HasOne(d => d.IdcontractNavigation).WithMany(p => p.TbMaintenanceHistories)
                .HasForeignKey(d => d.Idcontract)
                .HasConstraintName("FK_TB_MaintenanceHistory_TB_Contract");

            entity.HasOne(d => d.IdstaffNavigation).WithMany(p => p.TbMaintenanceHistories)
                .HasForeignKey(d => d.Idstaff)
                .HasConstraintName("FK_TB_MaintenanceHistory_TB_Staff");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.Idmenu);

            entity.ToTable("TB_Menu");

            entity.Property(e => e.Idmenu).HasColumnName("IDMenu");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TbNotificalAdmin>(entity =>
        {
            entity.HasKey(e => e.Idnotifical);

            entity.ToTable("TB_NotificalAdmin");

            entity.Property(e => e.Idnotifical).HasColumnName("IDNotifical");
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductionModel>(entity =>
        {
            entity.HasKey(e => e.IdproductionModel);

            entity.ToTable("TB_ProductionModel");

            entity.Property(e => e.IdproductionModel).HasColumnName("IDProductionModel");
            entity.Property(e => e.Idautomaker).HasColumnName("IDAutomaker");
            entity.Property(e => e.IddriverCapabilities).HasColumnName("IDDriverCapabilities");
            entity.Property(e => e.Idfuel).HasColumnName("IDFuel");
            entity.Property(e => e.Idgearbox).HasColumnName("IDGearbox");
            entity.Property(e => e.ProductionModelName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdautomakerNavigation).WithMany(p => p.TbProductionModels)
                .HasForeignKey(d => d.Idautomaker)
                .HasConstraintName("FK_TB_ProductionModel_TB_Automaker");

            entity.HasOne(d => d.IddriverCapabilitiesNavigation).WithMany(p => p.TbProductionModels)
                .HasForeignKey(d => d.IddriverCapabilities)
                .HasConstraintName("FK_TB_ProductionModel_TB_DriverCapabilities");

            entity.HasOne(d => d.IdfuelNavigation).WithMany(p => p.TbProductionModels)
                .HasForeignKey(d => d.Idfuel)
                .HasConstraintName("FK_TB_ProductionModel_TB_Fuel");

            entity.HasOne(d => d.IdgearboxNavigation).WithMany(p => p.TbProductionModels)
                .HasForeignKey(d => d.Idgearbox)
                .HasConstraintName("FK_TB_ProductionModel_TB_Gearbox");
        });

        modelBuilder.Entity<TbReceiver>(entity =>
        {
            entity.HasKey(e => e.Idreceiver);

            entity.ToTable("TB_Receiver");

            entity.Property(e => e.Idreceiver).HasColumnName("IDReceiver");
            entity.Property(e => e.Gmail).HasMaxLength(50);
            entity.Property(e => e.NameReceiver).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbStaff>(entity =>
        {
            entity.HasKey(e => e.Idstaff);

            entity.ToTable("TB_Staff");

            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.Idcard)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("IDcard");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StaffName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.HasKey(e => e.Idsupplier);

            entity.ToTable("TB_Supplier");

            entity.Property(e => e.Idsupplier).HasColumnName("IDSupplier");
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTestimonial>(entity =>
        {
            entity.HasKey(e => e.Idtestimonial);

            entity.ToTable("TB_Testimonial");

            entity.Property(e => e.Idtestimonial).HasColumnName("IDTestimonial");
            entity.Property(e => e.Detail).HasMaxLength(300);
            entity.Property(e => e.Image).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Profession).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
