using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Student : Entity<Guid>
{
    public FirstName Name { get; private set; }

    public MiddleName MiddleName { get; private set; }

    public LastName LastName { get; private set; }

    private readonly ICollection<ExerciseRecord> _exercises = [];

    public IReadOnlyCollection<ExerciseRecord> Exercises =>
        _exercises.ToList().AsReadOnly();


    private Student()
        : base(Guid.Empty)
    {
    }

    public Student(
        FirstName name,
        MiddleName middleName,
        LastName lastName)
        : base(Guid.NewGuid())
    {
        Name = name;
        MiddleName = middleName;
        LastName = lastName;
    }

    public void CompleteExercise(
        ExerciseRecord exerciseRecord,
        Exercise solution)
    {
        if (exerciseRecord.Student != this)
            throw new ExerciseNotBelongException();

        exerciseRecord.SetSolution(solution);
    }
}