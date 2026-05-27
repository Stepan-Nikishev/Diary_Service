using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class ExerciseRecord : Entity<Guid>
{
    public Teacher Teacher { get; private set; }

    public Student Student { get; private set; }

    public Exercise Exercise { get; private set; }

    public Exercise? Solution { get; private set; }

    public DateTime ExerciseDate { get; private set; }

    public DateTime? CompletedDate { get; private set; }

    public bool IsCompleted =>
        Solution is not null;

    private ExerciseRecord()
        : base(Guid.Empty)
    {
    }

    public ExerciseRecord(
        Teacher teacher,
        Student student,
        Exercise exercise,
        DateTime exerciseDate)
        : base(Guid.NewGuid())
    {
        Teacher = teacher;
        Student = student;
        Exercise = exercise;
        ExerciseDate = exerciseDate;
    }

    internal void SetSolution(Exercise solution)
    {
        if (IsCompleted)
            throw new ExerciseCompletedException();

        Solution = solution;
        CompletedDate = DateTime.UtcNow;
    }
}