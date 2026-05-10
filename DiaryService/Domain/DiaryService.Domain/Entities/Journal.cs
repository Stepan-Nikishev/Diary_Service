using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;
using System.Diagnostics;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Journal : Entity<Guid>
{
    public Grade? Grade { get; }
    public DateTime Date { get; }
    public Exercise? Exercise { get; }
    public JournalStatus Status { get; }
    public DiaryServiceAccount? Source { get; }
    public DiaryServiceAccount? Destination { get; }


    protected Journal(
        Guid id,
        Grade? grade,
        Exercise? exercise,
        DateTime date,
        JournalStatus status,
        DiaryServiceAccount source,
        DiaryServiceAccount destination)
        : base(id)
    {
        Grade = grade;
        Exercise = exercise;
        Date = date;
        Status = status;
        Source = source;
        Destination = destination;
    }

    public Journal(Guid id, Grade grade, DateTime date, DiaryServiceAccount source, 
        DiaryServiceAccount destination)
    : this(
        id,
        grade,
        null,
        date,
        JournalStatus.Grade,
        source,
        destination)
    {
    }

    public Journal(Guid id, Exercise exercise, DateTime date,  DiaryServiceAccount source, 
        DiaryServiceAccount destination)
    : this(
        id,
        null,
        exercise,
        date,
        JournalStatus.Exercise,
        source,
        destination)
    {
    }

    public Journal(Guid id, Exercise exercise, DateTime date, DiaryServiceAccount source, 
        DiaryServiceAccount destination, bool completed)
    : this(
        id,
        null,
        exercise,
        date,
        JournalStatus.CompletedExercise,
        source,
        destination)
    {
    }

    public override string ToString()
    {
        switch (Status)
        {
            case JournalStatus.Grade:
                int gradeValue = Grade?.Value ?? 0;
                return $"[ОЦЕНКА] {Date} | {gradeValue}";

            case JournalStatus.Exercise:
                string exerciseName = Exercise?.ToString() ?? "нет задания";
                return $"[ЗАДАНИЕ] {Date} | {exerciseName}";

            case JournalStatus.CompletedExercise:
                string completedName = Exercise?.ToString() ?? "нет задания";
                return $"[ВЫПОЛНЕНО] {Date} | {completedName}";

            default:
                return $"[ЗАПИСЬ] {Date}";
        }
    }
}