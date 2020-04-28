using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rest_api.Models.DBModels
{
    public partial class jobContext : DbContext
    {
        public jobContext()
        {
        }

        public jobContext(DbContextOptions<jobContext> options)
            : base(options)
        {
        }

        public virtual DbSet<jobTask> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=job;User=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<jobTask>(entity =>
            {
                entity.ToTable("jobtask");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IsComplete)
                    .HasColumnName("is_complete")
                    .HasColumnType("boolean");

                entity.Property(e => e.Percentage)
                    .HasColumnName("percentage")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
