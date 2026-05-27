namespace DiaryService.Domain.DiaryService.Domain.Exceptions;

public class ExerciseNotBelongException() : InvalidOperationException("Это задание не принадлежит студенту");