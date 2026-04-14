using DiaryService.Domain.DiaryService.Domain.Entities;

namespace DiaryService.Domain.Repositories.Abstractions
{
    public interface IDiaryServiceAccountRepository : IRepository<DiaryServiceAccount, int>
    {
        Task<IEnumerable<DiaryServiceAccount>> GetAccountsByTeacherIdAsync(int teacherId);
        Task<IEnumerable<DiaryServiceAccount>> GetAccountsByStudentIdAsync(int studentId);
        Task<DiaryServiceAccount?> GetAccountWithJournalAsync(int accountId);
        Task<IEnumerable<Journal>> GetJournalEntriesAsync(int accountId);
        Task<IEnumerable<Journal>> GetReceivedEntriesAsync(int accountId);
        Task<IEnumerable<Journal>> GetSentEntriesAsync(int accountId);
    }
}