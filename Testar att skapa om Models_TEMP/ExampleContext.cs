using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1.Models
{
    public partial class ExampleContext : DbContext
    {
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Issues> Issues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPGB;Initial Catalog=Inlamn2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Comments__C3B4DFAA08C6D4EF");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.FkIssue)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkIssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__FK_Iss__160F4887");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B82BBBBF21");
            });

            modelBuilder.Entity<Issues>(entity =>
            {
                entity.HasKey(e => e.IssueId)
                    .HasName("PK__Issues__6C86162494041D9A");

                entity.Property(e => e.IssueId).ValueGeneratedNever();

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.FkCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__FK_Custo__1332DBDC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
