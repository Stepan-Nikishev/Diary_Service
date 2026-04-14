using DiaryService.Domain.DiaryService.Domain.Entities;

namespace DiaryService.Domain.Repositories.Abstractions
{
    public interface ITeacherRepository : IRepository<Teacher, int>
    {
        Task<Teacher?> GetTeacherWithAccountsAsync(int teacherId);
        Task<Teacher?> GetTeacherWithJournalAsync(int teacherId);
        Task<IEnumerable<Teacher>> GetAllTeachersWithCoursesAsync();
        Task<Teacher?> GetTeacherByNameAsync(string firstName, string lastName);
    }
}