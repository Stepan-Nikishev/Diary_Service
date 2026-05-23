using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class ExerciseRecord : Entity<Guid>
{
    public Guid TeacherId { get; private set; }
    public Teacher Teacher { get; private set; }

    public Guid StudentId { get; private set; }
    public Student Student { get; private set; }

    public Exercise Exercise { get; private set; }

    public Exercise? CompletedExercise { get; private set; }

    public DateTime ExerciseDate { get; private set; }

    public DateTime? CompletedExerciseDate { get; private set; }

    public bool IsCompleted =>
        CompletedExercise != null;

    private readonly List<Journal> _journals = [];
    public IReadOnlyCollection<Journal> Journals =>
        _journals.AsReadOnly();

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
        TeacherId = teacher.Id;

        Student = student;
        StudentId = student.Id;

        Exercise = exercise;

        ExerciseDate = exerciseDate;
    }

    internal void Complete(Exercise completedExercise)
    {
        if (IsCompleted)
            throw new ExerciseCompletedException();

        CompletedExercise = completedExercise;

        CompletedExerciseDate = DateTime.UtcNow;
    }

    internal void AddJournal(Journal journal)
    {
        _journals.Add(journal);
    }
}