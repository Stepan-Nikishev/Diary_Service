using DiaryService.Domain.DiaryService.Domain.Exception;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

internal class Teacher
{
    public FirstName Name { get; private set; }
    public MiddleName MiddleName { get; private set; }
    public LastName LastName { get; private set; }

    private ICollection<DiaryServiceAccount> TeacherAccounts = new List<DiaryServiceAccount>();

    public Teacher (FirstName name, MiddleName middleName, LastName lastName)
    {
        Name = name;
        MiddleName = middleName;
        LastName = lastName;
    }

    public DiaryServiceAccount CreateTeacherAccount(FirstName name, MiddleName middleName, LastName lastName)
    {
        var account = new DiaryServiceAccount(name, middleName, lastName);
        TeacherAccounts.Add(account);
        return account;
    }

    private void Check(DiaryServiceAccount account, string paramName)
    {
        if (account == null)
            throw new ArgumentNullValueException(paramName);

        if (!TeacherAccounts.Contains(account))
            throw new DiaryServiceAccountNotFound();
    }

    public void Grade(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Grade grade)
    {
        Check(fromAccount, nameof(fromAccount));
        Check(toAccount, nameof(toAccount));
        fromAccount.AddGrade(toAccount, grade, DateTime.UtcNow);
    }

    public void Exercise(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Exercise exercise)
    {
        Check(fromAccount, nameof(fromAccount));
        Check(toAccount, nameof(toAccount));
        fromAccount.AddExercise(toAccount, exercise, DateTime.UtcNow);
    }



}
