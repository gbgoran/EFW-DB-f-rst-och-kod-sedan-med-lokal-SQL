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
                    .HasName("PK__Comments__C3B4DFAA02B76C73");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.FkIssue)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkIssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__FK_Iss__1DB06A4F");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B87DFEE993");
            });

            modelBuilder.Entity<Issues>(entity =>
            {
                entity.HasKey(e => e.IssueId)
                    .HasName("PK__Issues__6C861624E49AFD66");

                entity.Property(e => e.IssueId).ValueGeneratedNever();

                entity.HasOne(d => d.FkCustomer)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.FkCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__FK_Custo__1AD3FDA4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
