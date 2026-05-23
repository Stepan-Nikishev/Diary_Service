using DiaryService.Domain.DiaryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configuretions;

public class JournalConfiguration
    : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.ToTable("diary");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("diary_id");

        builder.Property(x => x.TeacherId)
            .HasColumnName("teacher_id")
            .IsRequired();

        builder.Property(x => x.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder.Property(x => x.ExerciseId)
            .HasColumnName("exercise_id")
            .IsRequired();

        builder.Property(x => x.Grade)
            .HasColumnName("grade")
            .IsRequired();

        builder.Property(x => x.GradeDate)
            .HasColumnName("grade_date")
            .IsRequired();

        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Journals)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Journals)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ExerciseRecord)
            .WithMany(x => x.Journals)
            .HasForeignKey(x => x.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}