using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataModels.Models
{
    public partial class AgencyManagemntContext : DbContext
    {
        public AgencyManagemntContext()
        {
        }

        public AgencyManagemntContext(DbContextOptions<AgencyManagemntContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<AgencyDebt> AgencyDebts { get; set; }
        public virtual DbSet<DebtsReport> DebtsReports { get; set; }
        public virtual DbSet<ExportSlip> ExportSlips { get; set; }
        public virtual DbSet<ExportSlipDetail> ExportSlipDetails { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<TurnoverReport> TurnoverReports { get; set; }
        public virtual DbSet<TypeOfAgency> TypeOfAgencies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local);database=AgencyManagemnt;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.ToTable("Agency");

                entity.Property(e => e.AgencyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.AgencyName).HasMaxLength(100);

                entity.Property(e => e.DayReception).HasColumnType("smalldatetime");

                entity.Property(e => e.District).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Agencies)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__Agency__TypeId__286302EC");
            });

            modelBuilder.Entity<AgencyDebt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AgencyDebt");

                entity.Property(e => e.AgencyId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirsDebt).HasColumnType("money");

                entity.Property(e => e.Incurred).HasColumnType("money");

                entity.HasOne(d => d.Agency)
                    .WithMany()
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AgencyDeb__Agenc__2A4B4B5E");
            });

            modelBuilder.Entity<DebtsReport>(entity =>
            {
                entity.HasKey(e => e.DebtsId)
                    .HasName("PK__DebtsRep__9A1D87163FE78DE3");

                entity.ToTable("DebtsReport");

                entity.Property(e => e.DebtsId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExportSlip>(entity =>
            {
                entity.ToTable("ExportSlip");

                entity.Property(e => e.ExportSlipId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.ExportSlips)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExportSli__Agenc__300424B4");
            });

            modelBuilder.Entity<ExportSlipDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExportSlipDetail");

                entity.Property(e => e.ExportSlipId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemsId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExportSlip)
                    .WithMany()
                    .HasForeignKey(d => d.ExportSlipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExportSli__Expor__32E0915F");

                entity.HasOne(d => d.Items)
                    .WithMany()
                    .HasForeignKey(d => d.ItemsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExportSli__Items__31EC6D26");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemsId)
                    .HasName("PK__Items__19AFBB7EE3A9CCA9");

                entity.Property(e => e.ItemsId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemsName).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__Items__UnitId__2D27B809");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.ReceiptId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Proceeds).HasColumnType("money");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Receipts__Procee__35BCFE0A");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("Reference");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TurnoverReport>(entity =>
            {
                entity.HasKey(e => e.TurnoverId)
                    .HasName("PK__Turnover__F0EEF8B3B30FB783");

                entity.ToTable("TurnoverReport");

                entity.Property(e => e.TurnoverId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfAgency>(entity =>
            {
                entity.ToTable("TypeOfAgency");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Value).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
