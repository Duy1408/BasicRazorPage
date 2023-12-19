using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject
{
    public partial class Eyeglasses2023DBContext : DbContext
    {
        public Eyeglasses2023DBContext()
        {
        }

        public Eyeglasses2023DBContext(DbContextOptions<Eyeglasses2023DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eyeglass> Eyeglasses { get; set; } = null!;
        public virtual DbSet<LensType> LensTypes { get; set; } = null!;
        public virtual DbSet<StoreAccount> StoreAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }


        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eyeglass>(entity =>
            {
                entity.HasKey(e => e.EyeglassesId)
                    .HasName("PK__Eyeglass__93A83C7B134DE03B");

                entity.Property(e => e.EyeglassesId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EyeglassesDescription).HasMaxLength(250);

                entity.Property(e => e.EyeglassesName).HasMaxLength(100);

                entity.Property(e => e.FrameColor).HasMaxLength(50);

                entity.Property(e => e.LensTypeId).HasMaxLength(30);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.LensType)
                    .WithMany(p => p.Eyeglasses)
                    .HasForeignKey(d => d.LensTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Eyeglasse__LensT__29572725");
            });

            modelBuilder.Entity<LensType>(entity =>
            {
                entity.ToTable("LensType");

                entity.Property(e => e.LensTypeId).HasMaxLength(30);

                entity.Property(e => e.LensTypeDescription).HasMaxLength(250);

                entity.Property(e => e.LensTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<StoreAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__StoreAcc__349DA586713E8217");

                entity.ToTable("StoreAccount");

                entity.HasIndex(e => e.EmailAddress, "UQ__StoreAcc__49A14740C4630D44")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountPassword).HasMaxLength(40);

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
