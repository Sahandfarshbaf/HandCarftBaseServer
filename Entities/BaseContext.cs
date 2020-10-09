using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Api> Api { get; set; }
        public virtual DbSet<CatApi> CatApi { get; set; }
        public virtual DbSet<CatFrom> CatFrom { get; set; }
        public virtual DbSet<CatProduct> CatProduct { get; set; }
        public virtual DbSet<CatProductLanguage> CatProductLanguage { get; set; }
        public virtual DbSet<CatRole> CatRole { get; set; }
        public virtual DbSet<CatStatus> CatStatus { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<FormsApi> FormsApi { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MobileAppType> MobileAppType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleForms> RoleForms { get; set; }
        public virtual DbSet<RoleFormsApi> RoleFormsApi { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SellerAddress> SellerAddress { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }
        public virtual DbSet<Systems> Systems { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<TablesServiceDiscovery> TablesServiceDiscovery { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>(entity =>
            {
                entity.ToTable("API");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatApiid).HasColumnName("CatAPIID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Type).HasComment(@"1 = GET
2 = POST
3 = PUT
4 = Delete");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(512);

                entity.HasOne(d => d.CatApi)
                    .WithMany(p => p.Api)
                    .HasForeignKey(d => d.CatApiid)
                    .HasConstraintName("FK_API_CatAPI");
            });

            modelBuilder.Entity<CatApi>(entity =>
            {
                entity.ToTable("CatAPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.SystemsId).HasColumnName("SystemsID");

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.CatApi)
                    .HasForeignKey(d => d.SystemsId)
                    .HasConstraintName("FK_CatAPI_Systems");
            });

            modelBuilder.Entity<CatFrom>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Icon).HasMaxLength(512);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Rorder).HasColumnName("ROrder");

                entity.Property(e => e.SystemsId).HasColumnName("SystemsID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(512);

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.CatFrom)
                    .HasForeignKey(d => d.SystemsId)
                    .HasConstraintName("FK_CatFrom_Systems");
            });

            modelBuilder.Entity<CatProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Icon).HasMaxLength(256);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.InverseP)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_CatProduct_CatProduct");
            });

            modelBuilder.Entity<CatProductLanguage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatProductId).HasColumnName("CatProductID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Icon).HasMaxLength(256);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.CatProduct)
                    .WithMany(p => p.CatProductLanguage)
                    .HasForeignKey(d => d.CatProductId)
                    .HasConstraintName("FK_CatProductLanguage_CatProduct");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.CatProductLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_CatProductLanguage_Language");
            });

            modelBuilder.Entity<CatRole>(entity =>
            {
                entity.HasIndex(e => e.Rkey)
                    .HasName("IX_CatRole")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.SystemsId).HasColumnName("SystemsID");

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.CatRole)
                    .HasForeignKey(d => d.SystemsId)
                    .HasConstraintName("FK_CatRole_Systems");
            });

            modelBuilder.Entity<CatStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.ColorCode).HasMaxLength(32);

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bdate).HasColumnName("BDate");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Fname).HasMaxLength(32);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MobileAppTypeId).HasColumnName("MobileAppTypeID");

                entity.Property(e => e.MobileAppVersion).HasMaxLength(32);

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.PresenterCustomerId).HasColumnName("PresenterCustomerID");

                entity.Property(e => e.ProfileImageHurl)
                    .HasColumnName("ProfileImageHURL")
                    .HasMaxLength(514);

                entity.Property(e => e.ProfileImageUrl)
                    .HasColumnName("ProfileImageURL")
                    .HasMaxLength(512);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Customer_Location");

                entity.HasOne(d => d.MobileAppType)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.MobileAppTypeId)
                    .HasConstraintName("FK_Customer_MobileAppType");

                entity.HasOne(d => d.PresenterCustomer)
                    .WithMany(p => p.InversePresenterCustomer)
                    .HasForeignKey(d => d.PresenterCustomerId)
                    .HasConstraintName("FK_Customer_Customer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Customer_Users");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_Customer_Work");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(1024);

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.IssureFamily).HasMaxLength(32);

                entity.Property(e => e.IssureName).HasMaxLength(32);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.Titel).HasMaxLength(512);

                entity.Property(e => e.Xgps)
                    .HasColumnName("XGPS")
                    .HasMaxLength(128);

                entity.Property(e => e.Ygps)
                    .HasColumnName("YGPS")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerAddress_Customer");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Employee_Users");
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatFromsId).HasColumnName("CatFromsID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Icon).HasMaxLength(512);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Rorder).HasColumnName("ROrder");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(512);

                entity.HasOne(d => d.CatFroms)
                    .WithMany(p => p.Forms)
                    .HasForeignKey(d => d.CatFromsId)
                    .HasConstraintName("FK_Forms_CatFrom");
            });

            modelBuilder.Entity<FormsApi>(entity =>
            {
                entity.ToTable("FormsAPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apiid).HasColumnName("APIID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.FormsId).HasColumnName("FormsID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.HasOne(d => d.Api)
                    .WithMany(p => p.FormsApi)
                    .HasForeignKey(d => d.Apiid)
                    .HasConstraintName("FK_FormsAPI_API");

                entity.HasOne(d => d.Forms)
                    .WithMany(p => p.FormsApi)
                    .HasForeignKey(d => d.FormsId)
                    .HasConstraintName("FK_FormsAPI_Forms");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.FlagIcon).HasMaxLength(256);

                entity.Property(e => e.IsRtl).HasColumnName("IsRTL");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.ShortName).HasMaxLength(16);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.EnName).HasMaxLength(64);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InverseCountry)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Location_Location1");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.InverseP)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_Location_Location");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.InverseProvince)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Location_Location2");
            });

            modelBuilder.Entity<MobileAppType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AparatUrl)
                    .HasColumnName("AparatURL")
                    .HasMaxLength(512);

                entity.Property(e => e.CatProductId).HasColumnName("CatProductID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CoverImageHurl)
                    .HasColumnName("CoverImageHURL")
                    .HasMaxLength(514);

                entity.Property(e => e.CoverImageUrl)
                    .HasColumnName("CoverImageURL")
                    .HasMaxLength(512);

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.EnName).HasMaxLength(256);

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.ProductMeterId).HasColumnName("ProductMeterID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.CatProduct)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatProductId)
                    .HasConstraintName("FK_Product_CatProduct");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatRoleId).HasColumnName("CatRoleID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.CatRole)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.CatRoleId)
                    .HasConstraintName("FK_Role_CatRole");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.InverseP)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_Role_Role");
            });

            modelBuilder.Entity<RoleForms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FormsId).HasColumnName("FormsID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Forms)
                    .WithMany(p => p.RoleForms)
                    .HasForeignKey(d => d.FormsId)
                    .HasConstraintName("FK_RoleForms_Forms");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleForms)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleForms_Role");
            });

            modelBuilder.Entity<RoleFormsApi>(entity =>
            {
                entity.ToTable("RoleFormsAPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.FormsApiid).HasColumnName("FormsAPIID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.RoleFormsId).HasColumnName("RoleFormsID");

                entity.HasOne(d => d.FormsApi)
                    .WithMany(p => p.RoleFormsApi)
                    .HasForeignKey(d => d.FormsApiid)
                    .HasConstraintName("FK_RoleFormsAPI_FormsAPI");

                entity.HasOne(d => d.RoleForms)
                    .WithMany(p => p.RoleFormsApi)
                    .HasForeignKey(d => d.RoleFormsId)
                    .HasConstraintName("FK_RoleFormsAPI_RoleForms");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bdate).HasColumnName("BDate");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Fname).HasMaxLength(32);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MobileAppTypeId).HasColumnName("MobileAppTypeID");

                entity.Property(e => e.MobileAppVersion).HasMaxLength(32);

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.ProfileImageHurl)
                    .HasColumnName("ProfileImageHURL")
                    .HasMaxLength(514);

                entity.Property(e => e.ProfileImageUrl)
                    .HasColumnName("ProfileImageURL")
                    .HasMaxLength(512);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Seller)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Seller_Location");

                entity.HasOne(d => d.MobileAppType)
                    .WithMany(p => p.Seller)
                    .HasForeignKey(d => d.MobileAppTypeId)
                    .HasConstraintName("FK_Seller_MobileAppType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Seller)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Seller_Users");
            });

            modelBuilder.Entity<SellerAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(1024);

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.Titel).HasMaxLength(512);

                entity.Property(e => e.Xgps)
                    .HasColumnName("XGPS")
                    .HasMaxLength(128);

                entity.Property(e => e.Ygps)
                    .HasColumnName("YGPS")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.SellerAddress)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK_SellerAddress_Seller");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatStatusId).HasColumnName("CatStatusID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.Color).HasMaxLength(7);

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NextStatusId).HasColumnName("NextStatusID");

                entity.Property(e => e.StatusTypeId).HasColumnName("StatusTypeID");

                entity.HasOne(d => d.CatStatus)
                    .WithMany(p => p.Status)
                    .HasForeignKey(d => d.CatStatusId)
                    .HasConstraintName("FK_Status_CatStatus");

                entity.HasOne(d => d.NextStatus)
                    .WithMany(p => p.InverseNextStatus)
                    .HasForeignKey(d => d.NextStatusId)
                    .HasConstraintName("FK_Status_Status");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Status)
                    .HasForeignKey(d => d.StatusTypeId)
                    .HasConstraintName("FK_Status_StatusType");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Systems>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Icon).HasMaxLength(512);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(32);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Rorder).HasColumnName("ROrder");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatStatusId).HasColumnName("CatStatusID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.SystemsId).HasColumnName("SystemsID");

                entity.HasOne(d => d.CatStatus)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.CatStatusId)
                    .HasConstraintName("FK_Tables_CatStatus");

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.SystemsId)
                    .HasConstraintName("FK_Tables_Systems");
            });

            modelBuilder.Entity<TablesServiceDiscovery>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.SystemsId).HasColumnName("SystemsID");

                entity.Property(e => e.TablesId).HasColumnName("TablesID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(512);

                entity.HasOne(d => d.Systems)
                    .WithMany(p => p.TablesServiceDiscovery)
                    .HasForeignKey(d => d.SystemsId)
                    .HasConstraintName("FK_TablesServiceDiscovery_Systems");

                entity.HasOne(d => d.Tables)
                    .WithMany(p => p.TablesServiceDiscovery)
                    .HasForeignKey(d => d.TablesId)
                    .HasConstraintName("FK_TablesServiceDiscovery_Tables");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FinalStatusId).HasColumnName("FinalStatusID");

                entity.Property(e => e.FullName).HasMaxLength(256);

                entity.Property(e => e.Hpassword)
                    .HasColumnName("HPassword")
                    .HasMaxLength(512);

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Username).HasMaxLength(64);
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate).HasColumnName("CDate");

                entity.Property(e => e.CuserId).HasColumnName("CUserID");

                entity.Property(e => e.DaUserId).HasColumnName("DaUserID");

                entity.Property(e => e.Ddate).HasColumnName("DDate");

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.DuserId).HasColumnName("DUserID");

                entity.Property(e => e.Mdate).HasColumnName("MDate");

                entity.Property(e => e.MuserId).HasColumnName("MUserID");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
