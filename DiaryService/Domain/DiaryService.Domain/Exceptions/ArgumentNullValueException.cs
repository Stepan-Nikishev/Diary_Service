namespace DiaryService.Domain.DiaryService.Domain.Exceptions;

public class ArgumentNullValueException(string paramName)
    : ArgumentNullException(paramName, $"\"{paramName}\" не может быть пустым");
