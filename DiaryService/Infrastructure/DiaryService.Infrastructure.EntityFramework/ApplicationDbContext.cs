using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DiaryService.Domain;
using DiaryService.Domain.DiaryService.Domain.Entities;

namespace DiaryService.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<DiaryServiceAccount> Accounts { get; set; }
    public DbSet<Journal> Journals { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }


}