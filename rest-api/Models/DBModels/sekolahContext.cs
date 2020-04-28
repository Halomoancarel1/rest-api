using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rest_api.Models.DBModels
{
    public partial class sekolahContext : DbContext
    {
        public sekolahContext()
        {
        }

        public sekolahContext(DbContextOptions<sekolahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Siswa> Siswa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=sekolah;User=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.ToTable("siswa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Alamat)
                    .IsRequired()
                    .HasColumnName("alamat")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasColumnName("nama")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.created_date)
                    .IsRequired()
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");
            });
        }
    }
}
