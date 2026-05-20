using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class DiaryServiceAccount : Entity<Guid>
{
    private readonly ICollection<Journal> journal = [];
    public IReadOnlyCollection<Journal> Journal => journal.ToList().AsReadOnly();

    private readonly ICollection<Journal> completedExercise = [];
    public IReadOnlyCollection<Journal> CompletedExercise => completedExercise.ToList().AsReadOnly();

    public string GetJournal() =>
    journal.Any() ? string.Join("\n", journal.Select(j => j.ToString())) : "Журнал пуст";

    public string GetCompletedExercise() =>
        completedExercise.Any() ? string.Join("\n", completedExercise.Select(c => c.ToString())) : "Нет выполненных заданий";

    public FirstName Name { get; private set; }
    public MiddleName MiddleName { get; private set; }
    public LastName LastName { get; private set; }

    public DiaryServiceAccount(FirstName name, MiddleName middleName, LastName lastName) : base(Guid.NewGuid())
    {
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        MiddleName = middleName ?? throw new ArgumentNullValueException(nameof(middleName)); 
        LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName)); 
    }

    public Journal AddGrade(DiaryServiceAccount toAccount, Grade grade, DateTime data)
    {
        var addedGrade = new Journal(Guid.NewGuid(), grade, data, this, toAccount);
        journal.Add(addedGrade);
        return addedGrade;
    }

    public Journal AddExercise(DiaryServiceAccount toAccount, Exercise exercise, DateTime data)
    {
        var addedExercise = new Journal(Guid.NewGuid(), exercise, data, this, toAccount);
        journal.Add(addedExercise);
        return addedExercise;
    }

    public Journal AddCompletedExercise(DiaryServiceAccount toAccount, Exercise exercise)
    {
        var addedCompletedExercise = new Journal(Guid.NewGuid(), exercise, DateTime.UtcNow, this, toAccount, true);
        completedExercise.Add(addedCompletedExercise);
        journal.Add(addedCompletedExercise);
        return addedCompletedExercise;
    }


    public override string ToString()
    => $"{Name} {Id}";

}
