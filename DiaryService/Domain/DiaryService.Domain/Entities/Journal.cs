using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public record Journal
{
    public Grade? Grade { get; }
    public DateTime Date { get; }
    public Exercise? Exercise { get; }
    public JournalStatus Status { get; }
    public DiaryServiceAccount? Source { get; }
    public DiaryServiceAccount? Destination { get; }

    // Конструктор 1: Только оценка (без Source/Destination)
    public Journal(Grade grade, DateTime date, JournalStatus status)
    {
        if (status != JournalStatus.Grade)
            throw new InvalidGradeException();

        Grade = grade ?? throw new ArgumentNullValueException(nameof(grade));
        Date = date;
        Status = status;
        Exercise = null;
        Source = null;
        Destination = null;
    }

    // Конструктор 2: Только задание (без Source/Destination)
    public Journal(DateTime date, Exercise exercise, JournalStatus status)
    {
        if (status != JournalStatus.Exercise)
            throw new InvalidExerciseException();

        Date = date;
        Exercise = exercise ?? throw new ArgumentNullValueException(nameof(exercise));
        Status = status;
        Grade = null;
        Source = null;
        Destination = null;
    }

    // Конструктор 3: Выполненное задание (без Source/Destination)
    public Journal(DateTime date, Exercise exercise)
    {
        Date = date;
        Exercise = exercise ?? throw new ArgumentNullValueException(nameof(exercise));
        Status = JournalStatus.CompletedExercise;
        Grade = null;
        Source = null;
        Destination = null;
    }

    // Конструктор 4: Оценка с Source и Destination (для учителя -> ученику)
    public Journal(Grade grade, DateTime date, JournalStatus status,
        DiaryServiceAccount source, DiaryServiceAccount destination)
        : this(grade, date, status)
    {
        if (status != JournalStatus.Grade)
            throw new InvalidGradeException();

        Source = source ?? throw new ArgumentNullValueException(nameof(source));
        Destination = destination ?? throw new ArgumentNullValueException(nameof(destination));
    }

    // Конструктор 5: Задание с Source и Destination (для учителя -> ученику)
    public Journal(DateTime date, Exercise exercise, JournalStatus status,
        DiaryServiceAccount source, DiaryServiceAccount destination)
        : this(date, exercise, status)
    {
        if (status != JournalStatus.Exercise)
            throw new InvalidExerciseException();

        Source = source ?? throw new ArgumentNullValueException(nameof(source));
        Destination = destination ?? throw new ArgumentNullValueException(nameof(destination));
    }

    // Конструктор 6: Выполненное задание с Source и Destination (для ученика -> учителю)
    public Journal(DateTime date, Exercise exercise,
        DiaryServiceAccount source, DiaryServiceAccount destination)
        : this(date, exercise)
    {
        Source = source ?? throw new ArgumentNullValueException(nameof(source));
        Destination = destination ?? throw new ArgumentNullValueException(nameof(destination));
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