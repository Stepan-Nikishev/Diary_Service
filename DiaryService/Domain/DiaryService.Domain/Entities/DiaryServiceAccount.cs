using DiaryService.Domain.DiaryService.Domain.Enums;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;
//using System.Diagnostics;
//using System.Transactions;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

internal class DiaryServiceAccount
{
    private ICollection<Transaction> transactions = [];
    public IReadOnlyCollection<Transaction> Transactions =>
        transactions.ToList<Transaction>();

    private static int countAccount = 0;
    public int IdAccount { get; } = countAccount;
    public FirstName Name { get; private set; }
    public MiddleName MiddleName { get; private set; }
    public LastName LastName { get; private set; }
    public DiaryServiceAccountType Type { get; private set; }

    public DiaryServiceAccount(FirstName name, MiddleName middleName, LastName lastName)
    {
        countAccount++;

        //Проверка на пустые строки
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        MiddleName = middleName ?? throw new ArgumentNullValueException(nameof(middleName)); 
        LastName = lastName ?? throw new ArgumentNullValueException(nameof(lastName)); 
    }

    private void CheckTeacherAccountType()
    {
        if (Type == DiaryServiceAccountType.Student)
            throw new DiaryServiceAccountStudentException();
    }

    private void CheckStudentAccountType()
    {
        if (Type == DiaryServiceAccountType.Teacher)
            throw new DiaryServiceAccountTeacherException();

    }
    public Transaction AddGrade(Grade grade, DateTime data)
    {
        var addedGrade = new Transaction(amount, data, note, TransactionStatus.Deposit, this);//транзакции нужнры

        transactions.Add(addedGrade);
        return addedGrade;
    }

    public Transaction AddExercise(Exercise exercise,  DateTime data)
    {
        var addedExercise = new Transaction(amount, data, note, TransactionStatus.Deposit, this);//транзакции нужнры

        transactions.Add(addedExercise);
        return addedExercise;
    }
}
