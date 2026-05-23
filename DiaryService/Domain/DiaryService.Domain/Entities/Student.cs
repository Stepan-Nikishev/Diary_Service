using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Student : Entity<Guid>
{
    public FirstName Name { get; private set; }

    public MiddleName MiddleName { get; private set; }

    public LastName LastName { get; private set; }

    private readonly List<Journal> _journals = [];
    public IReadOnlyCollection<Journal> Journals =>
        _journals.AsReadOnly();

    private readonly List<ExerciseRecord> _exercises = [];
    public IReadOnlyCollection<ExerciseRecord> Exercises =>
        _exercises.AsReadOnly();

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

    internal void ReceiveExercise(ExerciseRecord exercise)
    {
        _exercises.Add(exercise);
    }

    internal void ReceiveJournal(Journal journal)
    {
        _journals.Add(journal);
    }

    public void CompleteExercise(ExerciseRecord exerciseRecord, Exercise completedExercise)
    {
        if (!_exercises.Contains(exerciseRecord))
            throw new ExerciseCompletedException();

        exerciseRecord.Complete(completedExercise);
    }

    public string ViewExercises()
    {
        if (!_exercises.Any())
            return "Нет заданий";

        return string.Join(
            "\n",
            _exercises.Select(x =>
                $"Учитель {x.Teacher.Name} {x.Teacher.LastName} " +
                $"выдал задание: \"{x.Exercise}\""));
    }

    public string ViewJournal()
    {
        if (!_journals.Any())
            return "Нет оценок";

        return string.Join(
            "\n",
            _journals.Select(x => x.GetStudentView()));
    }
}