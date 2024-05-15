using Microsoft.EntityFrameworkCore;
using Moto.Domain.Entities;

namespace Moto.Infrastructure.Context;

public class MotoDbContext : DbContext
{
    public MotoDbContext(DbContextOptions<MotoDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<BikeEntity> Bikes { get; set; }

    public DbSet<RentEntity> Rents { get; set; }

    public DbSet<PlanEntity> Plans { get; set; }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(e =>
        {
            e.HasKey(x => x.Id).HasName("PK_USERS");

            e.ToTable("Users");

            e.Property(x => x.Id)
                .HasColumnName("user_id")
                .ValueGeneratedNever();

            e.Property(x => x.Name)
                .HasColumnName("user_name");

            e.Property(x => x.Cnpj)
                .HasColumnName("user_cnpj");

            e.Property(x => x.Cnh)
                .HasColumnName("user_cnh");
            
            e.Property(x => x.CnhType)
                .HasColumnName("user_cnh_type");

            e.Property(x => x.BirthDate)
                .HasColumnName("user_birth_date");

            e.Property(x => x.CreatedDate)
                .HasColumnName("user_created_date");

            e.Property(x => x.UpdatedDate)
                .HasColumnName("user_updated_date");

            e.Property(x => x.Password)
                .HasColumnName("user_password");

            e.Ignore(x => x.CnhImage);

            e.HasIndex(x => x.Cnpj)
                .IsUnique();

            e.HasIndex(x => x.Cnh)
                .IsUnique();
        });

        modelBuilder.Entity<BikeEntity>(e =>
        {
            e.HasKey(x => x.Id).HasName("PK_BIKES");

            e.ToTable("Bikes");

            e.Property(x => x.Id)
                .HasColumnName("bike_id")
                .ValueGeneratedNever();

            e.Property(x => x.Year)
                .HasColumnName("bike_year");

            e.Property(x => x.Plate)
                .HasColumnName("bike_plate");

            e.Property(x => x.Model)
                .HasColumnName("bike_model");

            e.Property(x => x.CreatedDate)
                .HasColumnName("bike_created_date");

            e.Property(x => x.UpdatedDate)
                .HasColumnName("bike_updated_date");

            e.HasIndex(x => x.Plate)
                .IsUnique();
        });

        modelBuilder.Entity<RentEntity>(e =>
        {
            e.HasKey(x => x.Id).HasName("PK_RENTS");

            e.ToTable("Rents");

            e.Property(x => x.Id)
                .HasColumnName("rent_id")
                .ValueGeneratedNever();

            e.Property(x => x.StartDate)
                .HasColumnName("rent_start_date");

            e.Property(x => x.StartDate)
                .HasColumnName("rent_end_date");

            e.Property(x => x.UserId)
                .HasColumnName("rent_user_id");

            e.Property(x => x.BikeId)
                .HasColumnName("rent_bike_id");

            e.Property(x => x.PlanId)
                .HasColumnName("rent_plan_id");

            e.Property(x => x.CreatedDate)
                .HasColumnName("rent_created_date");

            e.Property(x => x.UpdatedDate)
                .HasColumnName("rent_updated_date");

            e.HasIndex(x => new { x.UserId });
            e.HasIndex(x => new { x.BikeId });
            e.HasIndex(x => new { x.PlanId });

        });

        modelBuilder.Entity<PlanEntity>(e =>
        {
            e.HasKey(x => x.Id).HasName("PK_PLANS");

            e.ToTable("Plans");

            e.Property(x => x.Id)
                .HasColumnName("plan_id")
                .ValueGeneratedNever();

            e.Property(x => x.Days)
                 .HasColumnName("plan_days");

            e.Property(x => x.Price)
                .HasColumnName("plan_price")
                .HasColumnType("decimal(18,2)");

            e.Property(x => x.Fee)
                .HasColumnName("flan_fee")
                .HasColumnType("decimal(4,2)");

            e.Property(x => x.CreatedDate)
                .HasColumnName("plan_created_date");

            e.Property(x => x.UpdatedDate)
                .HasColumnName("plan_updated_date");
        });

        modelBuilder.Entity<PlanEntity>().HasData(
          new PlanEntity(7, 30, 1.2M),
          new PlanEntity(15, 28, 1.4M),
          new PlanEntity(30, 22, 1M),
          new PlanEntity(45, 20, 1M),
          new PlanEntity(50, 18, 12M)
        );
    }
}
