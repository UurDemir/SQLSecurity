using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlwaysEncrypted.DataAccess
{
    public partial class AdventureWorksDW2017Context : DbContext
    {
        public AdventureWorksDW2017Context()
        {
        }

        public AdventureWorksDW2017Context(DbContextOptions<AdventureWorksDW2017Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DimEmployee> DimEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AdventureWorksDW2017;Integrated Security=True;Column Encryption Setting=Enabled");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK_DimEmployee_EmployeeKey");

                entity.Property(e => e.BaseRate).HasColumnType("money");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactName).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactPhone).HasMaxLength(25);

                entity.Property(e => e.EmployeeNationalIdalternateKey)
                    .HasColumnName("EmployeeNationalIDAlternateKey")
                    .HasMaxLength(15);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ParentEmployeeNationalIdalternateKey)
                    .HasColumnName("ParentEmployeeNationalIDAlternateKey")
                    .HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.ParentEmployeeKeyNavigation)
                    .WithMany(p => p.InverseParentEmployeeKeyNavigation)
                    .HasForeignKey(d => d.ParentEmployeeKey)
                    .HasConstraintName("FK_DimEmployee_DimEmployee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
