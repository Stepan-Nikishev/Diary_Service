using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configuretions;

public class TeacherConfiguration
    : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teacher");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("firstname")
            .HasConversion(
                x => x.Value,
                x => new FirstName(x))
            .HasMaxLength(NameValidator.MAX_LENGTH)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasColumnName("middlename")
            .HasConversion(
                x => x.Value,
                x => new MiddleName(x))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.LastName)
            .HasColumnName("lastname")
            .HasConversion(
                x => x.Value,
                x => new LastName(x))
            .HasMaxLength(NameValidator.MAX_LENGTH)
            .IsRequired();
    }
}