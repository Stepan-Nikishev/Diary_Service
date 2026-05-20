using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;

namespace DiaryService.Domain.DiaryService.ValueObjects;

public class MiddleName(string middlename)
: ValueObject<string>(new NameValidator(), middlename);
