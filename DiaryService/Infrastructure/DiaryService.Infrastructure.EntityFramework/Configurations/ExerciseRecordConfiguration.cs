using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configuretions;

public class ExerciseRecordConfiguration
    : IEntityTypeConfiguration<ExerciseRecord>
{
    public void Configure(EntityTypeBuilder<ExerciseRecord> builder)
    {
        builder.ToTable("exercise");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("exercise_id");

        builder.Property(x => x.TeacherId)
            .HasColumnName("teacher_id")
            .IsRequired();

        builder.Property(x => x.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder.Property(x => x.Exercise)
            .HasColumnName("exercise")
            .HasConversion(
                x => x.Value,
                x => new Exercise(x))
            .IsRequired();

        builder.Property(x => x.CompletedExercise)
            .HasColumnName("completed_exercise")
            .HasConversion(
                x => x!.Value,
                x => new Exercise(x))
            .IsRequired(false);

        builder.Property(x => x.ExerciseDate)
            .HasColumnName("exercise_date")
            .IsRequired();

        builder.Property(x => x.CompletedExerciseDate)
            .HasColumnName("completed_exercise_date")
            .IsRequired(false);

        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}