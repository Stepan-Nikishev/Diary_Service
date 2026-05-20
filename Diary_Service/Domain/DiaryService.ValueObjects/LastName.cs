using DiaryService.Domain.DiaryService.ValueObjects.Base;
using DiaryService.Domain.DiaryService.ValueObjects.Validators;

namespace DiaryService.Domain.DiaryService.ValueObjects;

public class LastName(string lastname)
: ValueObject<string>(new NameValidator(), lastname);
