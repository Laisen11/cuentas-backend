using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject.Models
{
    public partial class FinalProjectContext : DbContext
    {
        public FinalProjectContext()
        {
        }

        public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-8RL8T6O\\SQLEXPRESS;Database=FinalProject;Integrated Security=True");
                optionsBuilder.UseSqlServer("Server=tcp:finalprojectapidbserver.database.windows.net,1433;Initial Catalog=FinalProject_db;Persist Security Info=False;User ID=Administrador;Password=Admin#2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProviderNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdProvider)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IdProvider");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdInvoice)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IdInvoice");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
