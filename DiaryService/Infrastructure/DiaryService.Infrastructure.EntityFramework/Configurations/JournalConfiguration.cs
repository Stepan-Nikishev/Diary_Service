using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace DiaryService.Infrastructure.EntityFramework.Configuretions;

public class JournalConfiguration
    : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Date)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(),
                str => Enum.Parse<JournalStatus>(str));

        builder.Property(x => x.Grade)
            .IsRequired(false)
            .HasConversion(grade => grade!.Value, str => new Grade(str));

        builder.Property(x => x.Exercise)
            .IsRequired(false)
            .HasConversion(exercise => exercise.Value, str => new Exercise(str));

        builder.HasOne(x => x.Source)
            .WithMany(x => x.Journal);

        builder.HasOne(x => x.Destination)
            .WithMany();
    }
}