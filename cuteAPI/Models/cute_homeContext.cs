using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cuteAPI.Models
{
    public partial class cute_homeContext : DbContext
    {
        public cute_homeContext()
        {
        }

        public cute_homeContext(DbContextOptions<cute_homeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<CollectionDetail> CollectionDetails { get; set; }
        public virtual DbSet<CommisionPayment> CommisionPayments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<LeasingContract> LeasingContracts { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<WalletDetail> WalletDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("appointment");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasColumnName("appointmentDate");

                entity.Property(e => e.EmployeeObservations)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("employeeObservations");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.UserObservations)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userObservations");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appointme__idEmp__440B1D61");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appointme__idUse__4316F928");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.IdCollection)
                    .HasName("PK__collecti__5053C1A9817FFA7A");

                entity.ToTable("collection");

                entity.Property(e => e.IdCollection).HasColumnName("idCollection");

                entity.Property(e => e.Debt)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("debt");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__idUse__5070F446");
            });

            modelBuilder.Entity<CollectionDetail>(entity =>
            {
                entity.HasKey(e => e.IdMovement)
                    .HasName("PK__collecti__5B3BB2F52E51A4C5");

                entity.ToTable("collectionDetail");

                entity.Property(e => e.IdMovement).HasColumnName("idMovement");

                entity.Property(e => e.Ammount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("ammount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCollection).HasColumnName("idCollection");

                entity.Property(e => e.IdContract).HasColumnName("idContract");

                entity.Property(e => e.MovementType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("movementType");

                entity.HasOne(d => d.IdCollectionNavigation)
                    .WithMany(p => p.CollectionDetails)
                    .HasForeignKey(d => d.IdCollection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__idCol__534D60F1");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.CollectionDetails)
                    .HasForeignKey(d => d.IdContract)
                    .HasConstraintName("FK__collectio__idCon__5441852A");
            });

            modelBuilder.Entity<CommisionPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("commisionPayment");

                entity.Property(e => e.Ammount)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("ammount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdContract).HasColumnName("idContract");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__commision__idCon__4CA06362");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__commision__idEmp__4BAC3F29");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__employee__227F26A51B66A5CA");

                entity.ToTable("employee");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.CommisionPercentage).HasColumnName("commisionPercentage");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("hashedPassword");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("hiringDate");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employeeRole");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employeeR__idEmp__3C69FB99");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employeeR__idRol__3D5E1FD2");
            });

            modelBuilder.Entity<LeasingContract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PK__leasingC__9145BAA3257F604D");

                entity.ToTable("leasingContract");

                entity.Property(e => e.IdContract).HasColumnName("idContract");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.MonthlyRent)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("monthlyRent");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.LeasingContractIdEmployeeNavigations)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leasingCo__idEmp__47DBAE45");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.LeasingContracts)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leasingCo__idPro__48CFD27E");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.LeasingContractIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__leasingCo__idUse__46E78A0C");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty)
                    .HasName("PK__property__6C08B9A704FB232C");

                entity.ToTable("property");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Garage).HasColumnName("garage");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.MonthlyRent)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("monthlyRent");

                entity.Property(e => e.NumberOfBaths).HasColumnName("numberOfBaths");

                entity.Property(e => e.NumberOfRooms).HasColumnName("numberOfRooms");

                entity.Property(e => e.SurfaceInSquareMeters).HasColumnName("surfaceInSquareMeters");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__role__E5045C547C76C674");

                entity.ToTable("role");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__users__3717C982E047F1BA");

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("hashedPassword");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__users__idEmploye__38996AB5");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.HasKey(e => e.IdWallet)
                    .HasName("PK__wallet__887A655F7CE587C1");

                entity.ToTable("wallet");

                entity.Property(e => e.IdWallet).HasColumnName("idWallet");

                entity.Property(e => e.AvailableProps).HasColumnName("availableProps");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__wallet__idEmploy__5812160E");
            });

            modelBuilder.Entity<WalletDetail>(entity =>
            {
                entity.HasKey(e => e.IdDetail)
                    .HasName("PK__walletDe__75EC3C06006F3B0E");

                entity.ToTable("walletDetail");

                entity.Property(e => e.IdDetail).HasColumnName("idDetail");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdProperty).HasColumnName("idProperty");

                entity.Property(e => e.IdWallet).HasColumnName("idWallet");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.WalletDetails)
                    .HasForeignKey(d => d.IdProperty)
                    .HasConstraintName("FK__walletDet__idPro__5CD6CB2B");

                entity.HasOne(d => d.IdWalletNavigation)
                    .WithMany(p => p.WalletDetails)
                    .HasForeignKey(d => d.IdWallet)
                    .HasConstraintName("FK__walletDet__idWal__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
