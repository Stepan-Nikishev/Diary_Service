using DiaryService.Domain.DiaryService.Domain.Entities;

namespace DiaryService.Domain.Repositories.Abstractions
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<Student?> GetStudentWithAccountsAsync(int studentId);
        Task<Student?> GetStudentWithJournalAsync(int studentId);
        Task<IEnumerable<Student>> GetAllStudentsWithGradesAsync();
        Task<Student?> GetStudentByNameAsync(string firstName, string lastName);
        Task<IEnumerable<Journal>> GetStudentJournalAsync(int studentId);
    }
}