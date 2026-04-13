using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public record Journal
{
    public Grade Grade { get; }
    public DateTime Date { get; }
    public Exercise Exercise { get; }
    public JournalStatus Status { get; }
    public DiaryServiceAccount? Source { get; } = null;
    public DiaryServiceAccount? Destination { get; } = null;


    public Journal(
        Grade grade,
        DateTime date,
        JournalStatus status)
    {
        Grade = grade;
        Date = date;
        Status = status;
    }

    public Journal(
        DateTime date,
        Exercise exercise,
        JournalStatus status)
    {
        Date = date;
        Exercise = exercise;
        Status = status;
    }


    public Journal(
        DateTime date,
        Exercise exercise,
        JournalStatus status,
        DiaryServiceAccount source,
        DiaryServiceAccount destination) : this(date,exercise,  status)
    {
        if (status != JournalStatus.Exercise)
            throw new InvalidGradeException();
        Status = status;
        Source = source;
        Destination = destination;
    }

    public Journal(
       Grade grade,
       DateTime date,
       JournalStatus status,
       DiaryServiceAccount source,
       DiaryServiceAccount destination) : this(grade, date, status)
    {
        if (status != JournalStatus.Grade)
            throw new InvalidExerciseException();
        Status = status;
        Source = source;
        Destination = destination;
    }

    
    public override string ToString()
        => $"{Grade} {Date} {Exercise}";
}
