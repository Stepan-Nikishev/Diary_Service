using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.Domain.Exception;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Teacher : Entity<Guid>
{
    public FirstName Name { get; private set; }
    public MiddleName MiddleName { get; private set; }
    public LastName LastName { get; private set; }

    private ICollection<DiaryServiceAccount> TeacherAccounts = new List<DiaryServiceAccount>();

    public Teacher (FirstName name, MiddleName middleName, LastName lastName):base(Guid.NewGuid())
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

    private void CheckTeacher(DiaryServiceAccount account, string paramName)
    {
        if (account == null)
            throw new ArgumentNullValueException(paramName);

        if (!TeacherAccounts.Contains(account))
            throw new DiaryServiceAccountNotFound();
    }

    public void Grade(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Grade grade, DateTime data)
    {
        CheckTeacher(fromAccount, nameof(fromAccount));
        fromAccount.AddGrade(toAccount, grade, data);
    }

    public void Exercise(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Exercise exercise, DateTime data)
    {
        CheckTeacher(fromAccount, nameof(fromAccount));
        fromAccount.AddExercise(toAccount, exercise, data);
    }

    public string ViewJournal(DiaryServiceAccount teacherAccount, DiaryServiceAccount studentAccount = null)
    {
        CheckTeacher(teacherAccount, nameof(teacherAccount));

        if (studentAccount == null)
        {
            return teacherAccount.GetJournal();
        }
        else
        {
            var entries = teacherAccount.Journal
                .Where(j => j.Destination != null && j.Destination.Id == studentAccount.Id)
                .ToList();

            return entries.Any()
                ? string.Join("\n", entries.Select(j => j.ToString()))
                : $"У ученика {studentAccount} пока нет записей";
        }
    }


}
