using DiaryService.Domain.DiaryService.Domain.Exception;
using DiaryService.Domain.DiaryService.Domain.Exceptions;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities
{
    public class Student
    {
        public FirstName Name { get; private set; }
        public MiddleName MiddleName { get; private set; }
        public LastName LastName { get; private set; }

        private ICollection<DiaryServiceAccount> StudentsAccounts = new List<DiaryServiceAccount>();

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

            if (!StudentsAccounts.Contains(account))
                throw new DiaryServiceAccountNotFound();
        }

        public DiaryServiceAccount CreateStudentAccount(FirstName name, MiddleName middleName, LastName lastName)
        {
            var account = new DiaryServiceAccount(name, middleName, lastName);
            StudentsAccounts.Add(account);
            return account;
        }

        public void CompletedExercise(DiaryServiceAccount fromAccount, DiaryServiceAccount toAccount, Exercise exercise)
        {
            CheckStudent(fromAccount, nameof(fromAccount));
            fromAccount.AddCompletedExercise(toAccount, exercise, DateTime.UtcNow);
        }

        public string ViewJournal(DiaryServiceAccount studentAccount, DiaryServiceAccount teacherAccount)
        {
            CheckStudent(studentAccount, nameof(studentAccount));

            var entries = teacherAccount.Journal
                .Where(j => j.Destination != null && j.Destination.IdAccount == studentAccount.IdAccount)
                .ToList();

            if (!entries.Any())
                return "У вас пока нет записей от учителя";

            return string.Join("\n", entries.Select(j => j.ToString()));
        }

        public string ViewMyCompletedExercises(DiaryServiceAccount studentAccount)
        {
            CheckStudent(studentAccount, nameof(studentAccount));
            return studentAccount.GetCompletedExecise();
        }
    }
}
