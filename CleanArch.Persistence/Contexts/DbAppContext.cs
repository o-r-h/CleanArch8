
using CleanArch.Domain.Common;
using Microsoft.EntityFrameworkCore;
using CleanArch.Domain.Entities;



#nullable disable

namespace CleanArch.Persistence.Contexts
{
    public partial class DbAppContext : DbContext
    {
        public DbAppContext()
        {
        }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Example> Examples { get; set; }


		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
            foreach (var entry in ChangeTracker.Entries <BaseEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedAt = DateTime.Now;
						entry.Entity.CreatedBy = "system";
						break;

					case EntityState.Modified:
						entry.Entity.ModifiedAt = DateTime.Now;
						entry.Entity.ModifiedBy = "system";
						break;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

			modelBuilder.Entity<Chofer>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.ToTable("Chofer");

				entity.Property(e => e.CreatedAt).HasColumnType("datetime");

				entity.Property(e => e.CreatedBy)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

				entity.Property(e => e.ModifiedBy)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Nombre).HasMaxLength(50);
				entity.Property(e => e.ApellidoMaterno).HasMaxLength(50);
				entity.Property(e => e.ApellidoPaterno).HasMaxLength(50);

			});


			modelBuilder.Entity<Example>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Example");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameExample).HasMaxLength(50);

                entity.Property(e => e.PriceExample).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
