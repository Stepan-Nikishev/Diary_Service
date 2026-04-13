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
            throw new ArgumentNullValueException(paramName);//!!

        if (!TeacherAccounts.Contains(account))
            throw new DiaryServiceAccountNotFound();//!!
    }

    public void Grade(DiaryServiceAccount account, Grade grade)
    {
        Check(account, nameof(account));
        account.AddGrade(grade, DateTime.UtcNow);
    }

    public void Exercise(DiaryServiceAccount account, Exercise exercise)
    {
        Check(account, nameof(account));
        account.AddExercise(exercise, DateTime.UtcNow);
    }



}
