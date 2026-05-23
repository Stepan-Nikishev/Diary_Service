using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Teacher : Entity<Guid>
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

    public ExerciseRecord GiveExercise(Student student, Exercise exercise, DateTime date)
    {
        var exerciseRecord = new ExerciseRecord(this, student, exercise, date);

        _exercises.Add(exerciseRecord);

        student.ReceiveExercise(exerciseRecord);

        return exerciseRecord;
    }

    public Journal GradeStudent(Student student, ExerciseRecord exerciseRecord, Grade grade, DateTime date)
    {
        if (!exerciseRecord.IsCompleted)
            throw new ExerciseNotCompletedException();

        if (exerciseRecord.StudentId != student.Id)
            throw new ExerciseNotBelongException();

        var journal = new Journal(this, student, exerciseRecord, grade, date);

        _journals.Add(journal);

        student.ReceiveJournal(journal);

        exerciseRecord.AddJournal(journal);

        return journal;
    }

    public string ViewIssuedExercises()
    {
        if (!_exercises.Any())
            return "Нет выданных заданий";

        return string.Join(
            "\n",
            _exercises.Select(x =>
                $"Студенту {x.Student.Name} {x.Student.LastName} " +
                $"выдано задание: \"{x.Exercise}\""));
    }

    public string ViewJournal()
    {
        if (!_journals.Any())
            return "Журнал пуст";

        return string.Join(
            "\n",
            _journals.Select(x => x.GetTeacherView()));
    }
}