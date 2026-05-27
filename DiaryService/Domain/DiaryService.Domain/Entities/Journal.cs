using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Journal : Entity<Guid>
{
    public Teacher Teacher { get; private set; }

    public Student Student { get; private set; }

    public ExerciseRecord ExerciseRecord { get; private set; }

    public Grade Grade { get; private set; }

    public DateTime GradeDate { get; private set; }

    private Journal()
        : base(Guid.Empty)
    {
    }

    public Journal(
        Teacher teacher,
        Student student,
        ExerciseRecord exerciseRecord,
        Grade grade,
        DateTime gradeDate)
        : base(Guid.NewGuid())
    {
        Teacher = teacher;
        Student = student;
        ExerciseRecord = exerciseRecord;
        Grade = grade;
        GradeDate = gradeDate;
    }
}