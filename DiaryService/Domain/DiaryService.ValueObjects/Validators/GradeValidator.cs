
using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Exceptions;

namespace DiaryService.Domain.DiaryService.ValueObjects.Validators;

public class GradeValidator : IValidator<int>
{
    public void Validate(int value)
    {
        if (value < 2 || value > 5)
            throw new GradeOutOfRangeException();
    }
}
