using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.Domain.Repositories.Abstractions.Base;

namespace DiaryService.Domain.DiaryService.Domain.Repositories;

public interface IJournalRepository : IRepository<Journal, Guid>
{
    Task<IReadOnlyCollection<Journal>> GetStudentGradesAsync(Guid studentId, CancellationToken cancellationToken);
}