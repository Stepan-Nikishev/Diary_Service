using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Exceptions;

namespace DiaryService.Domain.DiaryService.ValueObjects.Validators;

public class ExerciseValidator : IValidator<string>
{
    public static int MAX_LENGTH => 100;

    public static int MIN_LENGTH => 3;


    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);

        if (value.Length < MIN_LENGTH)
            throw new ArgumentShortValueException(nameof(value), value, MIN_LENGTH);
    }
}
