using DiaryService.Domain.DiaryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiaryService.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    public DbSet<Teacher> Teachers => Set<Teacher>();

    public DbSet<Journal> Diaries => Set<Journal>();

    public DbSet<ExerciseRecord> Exercises => Set<ExerciseRecord>();


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