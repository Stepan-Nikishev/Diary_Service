using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class DiaryServiceAccount
{
    private ICollection<Journal> journal = [];
    public IReadOnlyCollection<Journal> Journal =>
        journal.ToList<Journal>();

    private ICollection<Journal> completedExecise = [];
    public IReadOnlyCollection<Journal> CompletedExecise =>
        completedExecise.ToList<Journal>();

    private static int countAccount = 0;
    public int IdAccount { get; } = countAccount;
    public FirstName Name { get; private set; }
    public MiddleName MiddleName { get; private set; }
    public LastName LastName { get; private set; }

    public DiaryServiceAccount(FirstName name, MiddleName middleName, LastName lastName)
    {
        countAccount++;

        //Проверка на пустые строки
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        MiddleName = middleName ?? throw new ArgumentNullValueException(nameof(middleName)); 
        LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName)); 
    }

    public Journal AddGrade(DiaryServiceAccount toAccount, Grade grade, DateTime data)
    {
        var addedGrade = new Journal(grade, data, JournalStatus.Grade, this, toAccount);

        journal.Add(addedGrade);
        return addedGrade;
    }

    public Journal AddExercise(DiaryServiceAccount toAccount, Exercise exercise,  DateTime data)
    {
        var addedExercise = new Journal(data, exercise, JournalStatus.Exercise, this, toAccount);

        journal.Add(addedExercise);
        return addedExercise;
    }

    public Journal AddCompletedExercise(DiaryServiceAccount toAccount, Exercise exercise, DateTime data)
    {
        var addedCompletedExercise = new Journal(data, exercise, this, toAccount);

        completedExecise.Add(addedCompletedExercise);
        return addedCompletedExercise;
    }

    public IReadOnlyList<Journal> ViewJornal(DiaryServiceAccount studentAccount)
    {
        return journal.Where(j => j.Destination == studentAccount).ToList().AsReadOnly();
    }
}
