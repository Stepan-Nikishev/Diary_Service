namespace DiaryService.Domain.DiaryService.ValueObjects.Exceptions;

public class ArgumentNullOrWhiteSpaceException(string paramName)
    : ArgumentNullException(paramName, $"{paramName} не может быть пустым.");
