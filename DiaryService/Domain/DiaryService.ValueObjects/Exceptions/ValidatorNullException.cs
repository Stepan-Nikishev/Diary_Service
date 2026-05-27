namespace DiaryService.Domain.DiaryService.ValueObjects.Exceptions;

public class ValidatorNullException(string paramName)
    : ArgumentNullException(paramName, $"Валидатор \"{paramName}\" не может быть null.");
