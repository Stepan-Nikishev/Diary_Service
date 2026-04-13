using DiaryService.Domain.DiaryService.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiaryService.Domain.DiaryService.ValueObjects;

public class Grade(int grade) : ValueObject<int>(
       new GradeValidator(), grade)
{
    public static bool operator >(Grade g1, Grade g2)
    => g1.Value > g2.Value;

    public static bool operator <(Grade g1, Grade g2)
        => g1.Value < g2.Value;

    public static bool operator >=(Grade g1, Grade g2)
        => g1.Value >= g2.Value;

    public static bool operator <=(Grade g1, Grade g2)
        => g1.Value <= g2.Value;
}
