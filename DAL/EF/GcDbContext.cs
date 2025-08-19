using System.Diagnostics;
using GameCatalog.BL.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GameCatalog.DAL.EF;

public class GcDbContext : IdentityDbContext<IdentityUser>
{
    public GcDbContext(DbContextOptions<GcDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; init; }
    public DbSet<Review> Reviews { get; init; }
    public DbSet<Account> Accounts { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=GameCatalog.db");
        }

        optionsBuilder.LogTo(logmessage => Debug.WriteLine(logmessage), LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(game => game.Id);
            entity.Property(game => game.Genres).HasConversion(
                gen => string.Join(',', gen.Select(game => game.ToString())),
                gen => gen.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Genre>).ToList()
            ).IsRequired();
        });

        modelBuilder.Entity<Review>(r => { r.HasKey(review => review.Id); });

        modelBuilder.Entity<Account>(a => { a.HasKey(answer => answer.Id); });

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Account)
            .WithMany(a => a.Reviews)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Review>()
            .HasOne(r => r.Game)
            .WithMany(g => g.Reviews)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    public bool CreateDatabase(bool deleteDb)
    {
        if (deleteDb) Database.EnsureDeleted();
        var isCreatedNow = Database.EnsureCreated();
        return isCreatedNow && deleteDb;
    }
}