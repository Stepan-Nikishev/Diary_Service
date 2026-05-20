using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryService.Infrastructure.EntityFramework.Configuretions;

public class StudentConfiguration
    : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(name => name.Value, str => new FirstName(str))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.MiddleName)
            .IsRequired()
            .HasConversion(middleName => middleName.Value, str => new MiddleName(str))
            .HasMaxLength(NameValidator.MAX_LENGTH);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasConversion(lastName => lastName.Value, str => new LastName(str))
            .HasMaxLength(NameValidator.MAX_LENGTH);
    }
}
