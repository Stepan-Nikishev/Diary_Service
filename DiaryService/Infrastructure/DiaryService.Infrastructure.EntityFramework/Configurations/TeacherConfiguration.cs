using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configurations;

public class TeacherConfiguration
    : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(
                name => name.Value,
                value => new FirstName(value))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.MiddleName)
            .IsRequired()
            .HasConversion(
                middleName => middleName.Value,
                value => new MiddleName(value))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasConversion(
                lastName => lastName.Value,
                value => new LastName(value))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.HasMany<ExerciseRecord>("_exercises")
            .WithOne(x => x.Teacher)
            .HasForeignKey("TeacherId")
            .HasPrincipalKey(x => x.Id);

        builder.HasMany<Journal>("_journals")
            .WithOne(x => x.Teacher)
            .HasForeignKey("TeacherId")
            .HasPrincipalKey(x => x.Id);

        builder.Ignore(x => x.Exercises);
        builder.Ignore(x => x.Journals);
    }
}