using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.Domain.Enums;

namespace DiaryService.Domain.Repositories.Abstractions
{
    public interface IJournalRepository : IRepository<Journal, int>
    {
        Task<IEnumerable<Journal>> GetByTeacherIdAsync(int teacherId);
        Task<IEnumerable<Journal>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<Journal>> GetByStatusAsync(JournalStatus status);
        Task<IEnumerable<Journal>> GetByDateRangeAsync(DateTime from, DateTime to);
        Task<IEnumerable<Journal>> GetGradesForStudentAsync(int studentId);
        Task<IEnumerable<Journal>> GetExercisesForStudentAsync(int studentId);
        Task<IEnumerable<Journal>> GetCompletedExercisesForStudentAsync(int studentId);
        Task<double> GetAverageGradeForStudentAsync(int studentId);
    }
}