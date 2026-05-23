namespace DiaryService.Domain.DiaryService.Domain.Exceptions;

public class ExerciseNotCompletedException() : InvalidOperationException("Нельзя оценить невыполненное задание");