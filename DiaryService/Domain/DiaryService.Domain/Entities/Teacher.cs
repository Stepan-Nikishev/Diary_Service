using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Teacher : Entity<Guid>
{
    public FirstName Name { get; private set; }

    public MiddleName MiddleName { get; private set; }

    public LastName LastName { get; private set; }

    private readonly ICollection<ExerciseRecord> _exercises = [];

    private readonly ICollection<Journal> _journals = [];

    public IReadOnlyCollection<ExerciseRecord> Exercises =>
        _exercises.ToList().AsReadOnly();

    public IReadOnlyCollection<Journal> Journals =>
        _journals.ToList().AsReadOnly();

    private Teacher()
        : base(Guid.Empty)
    {
    }

    public Teacher(
        FirstName name,
        MiddleName middleName,
        LastName lastName)
        : base(Guid.NewGuid())
    {
        Name = name;
        MiddleName = middleName;
        LastName = lastName;
    }

    public ExerciseRecord CreateExercise(
        Student student,
        Exercise exercise,
        DateTime exerciseDate)
    {
        return new ExerciseRecord(
            this,
            student,
            exercise,
            exerciseDate);
    }

    public Journal EvaluateExercise(
        ExerciseRecord exerciseRecord,
        Grade grade,
        DateTime gradeDate)
    {
        if (!exerciseRecord.IsCompleted)
            throw new ExerciseNotCompletedException();

        return new Journal(
            this,
            exerciseRecord.Student,
            exerciseRecord,
            grade,
            gradeDate);
    }
}