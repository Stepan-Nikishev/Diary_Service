namespace DiaryService.Domain.DiaryService.ValueObjects.Exceptions;

public class GradeOutOfRangeException() : ArgumentOutOfRangeException("Оценка не может быть меньше 2 и больше 5");
