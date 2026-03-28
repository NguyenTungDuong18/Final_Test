using Microsoft.EntityFrameworkCore;
using TestRepo.Repository.Entities;

namespace TestRepo.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // public DbSet<User> Users { get; set; }
    public DbSet<users> users { get; set; }
    public DbSet<sellers> sellers { get; set; }
    public DbSet<products> products { get; set; }
    public DbSet<category> categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<users>(builder =>
        {
            builder.Property(x => x.password).IsRequired();
            builder.Property(x => x.email).IsRequired();
            builder.HasIndex(x => x.email).IsUnique();
            builder.Property(x => x.role).IsRequired();

            builder.HasOne(x => x.sellers).WithOne(x => x.users).HasForeignKey<sellers>(x => x.user_id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<sellers>(builder =>
        {
            builder.Property(x => x.tax_code).IsRequired();
            builder.Property(x => x.company_address).IsRequired();
            builder.Property(x => x.company_name).IsRequired();

            builder.HasMany(x => x.products).WithOne(x => x.sellers).HasForeignKey(x => x.userId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<products>(builder =>
        {
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.name).IsRequired();


        });

        modelBuilder.Entity<category>(builder =>
        {
            builder.Property(x => x.name).IsRequired();

            builder.HasMany(x => x.children).WithOne(x => x.Parent).HasForeignKey(x => x.parent_id)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}