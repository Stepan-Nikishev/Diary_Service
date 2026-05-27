using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configurations;

public class JournalConfiguration
    : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.ToTable("journals");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(j => j.Grade)
            .HasConversion(
                v => v.Value,
                v => new Grade(v))
            .IsRequired();

        builder.Property(x => x.GradeDate)
            .IsRequired();

        builder.HasOne(x => x.Teacher)
            .WithMany("_journals")
            .HasForeignKey("TeacherId")
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Student)
            .WithMany()
            .HasForeignKey("StudentId")
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.ExerciseRecord)
            .WithMany()
            .HasForeignKey("ExerciseRecordId")
            .HasPrincipalKey(x => x.Id);
    }
}