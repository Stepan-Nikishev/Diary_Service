using DiaryService.Domain.DiaryService.Domain.Exception;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities
{
    internal class Student
    {
        public FirstName Name { get; private set; }
        public MiddleName MiddleName { get; private set; }
        public LastName LastName { get; private set; }

        private ICollection<DiaryServiceAccount> StudentAccounts = new List<DiaryServiceAccount>();

        public Student(FirstName name, MiddleName middleName, LastName lastName)
        {
            Name = name;
            MiddleName = middleName;
            LastName = lastName;
        }

        private void CheckStudent(DiaryServiceAccount account, string paramName)
        {
            if (account == null)
                throw new ArgumentNullValueException(paramName);

            if (!StudentAccounts.Contains(account))
                throw new DiaryServiceAccountNotFound();
        }

        public DiaryServiceAccount CreateStudentAccount(FirstName name, MiddleName middleName, LastName lastName)
        {
            var account = new DiaryServiceAccount(name, middleName, lastName);
            StudentAccounts.Add(account);
            return account;
        }

        public void CompletedExercise(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Exercise exercise)
        {
            CheckStudent(fromAccount, nameof(fromAccount));
            CheckStudent(toAccount, nameof(toAccount));
            fromAccount.AddCompletedExercise(toAccount, exercise, DateTime.UtcNow);
        }

        public void View(DiaryServiceAccount studentAccount)
        {
            CheckStudent(studentAccount, nameof(studentAccount));
            studentAccount.ViewJornal(studentAccount);
        }
    }
}
