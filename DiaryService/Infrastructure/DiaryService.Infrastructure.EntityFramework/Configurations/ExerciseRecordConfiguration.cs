using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configurations;

public class ExerciseRecordConfiguration
    : IEntityTypeConfiguration<ExerciseRecord>
{
    public void Configure(EntityTypeBuilder<ExerciseRecord> builder)
    {
        builder.ToTable("exercise_records");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Exercise)
            .IsRequired()
            .HasConversion(
                exercise => exercise.Value,
                value => new Exercise(value))
            .HasMaxLength(ExerciseValidator.MAX_LENGTH);

        builder.Property(x => x.Solution)
            .HasConversion(
                solution => solution.Value,
                value => new Exercise(value))
            .HasMaxLength(ExerciseValidator.MAX_LENGTH);

        builder.Property(x => x.ExerciseDate)
            .IsRequired();

        builder.Property(x => x.CompletedDate);

        builder.Ignore(x => x.IsCompleted);

        builder.HasOne(x => x.Teacher)
            .WithMany("_exercises")
            .HasForeignKey("TeacherId")
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Student)
            .WithMany("_exercises")
            .HasForeignKey("StudentId")
            .HasPrincipalKey(x => x.Id);
    }
}