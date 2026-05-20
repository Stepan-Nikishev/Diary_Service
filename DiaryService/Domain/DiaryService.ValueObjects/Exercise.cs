using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;

namespace DiaryService.Domain.DiaryService.ValueObjects;

public class Exercise(string exercise)
    : ValueObject<string>(new ExerciseValidator(), exercise);

