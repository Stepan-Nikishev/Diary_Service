using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;

namespace DiaryService.Domain.DiaryService.ValueObjects;

public class FirstName(string firstname)
    : ValueObject<string>(new NameValidator(), firstname);
