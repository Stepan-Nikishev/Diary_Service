using DiaryService.Domain.DiaryService.Domain.Entities.Base;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DiaryService.Domain.Entities;

public class Journal : Entity<Guid>
{
    public Guid TeacherId { get; private set; }
    public Teacher Teacher { get; private set; }

    public Guid StudentId { get; private set; }
    public Student Student { get; private set; }

    public Guid ExerciseId { get; private set; }
    public ExerciseRecord ExerciseRecord { get; private set; }

    public int Grade { get; private set; }

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
        TeacherId = teacher.Id;

        Student = student;
        StudentId = student.Id;

        ExerciseRecord = exerciseRecord;
        ExerciseId = exerciseRecord.Id;

        Grade = grade.Value;

        GradeDate = gradeDate;
    }

    public string GetTeacherView()
    {
        return
            $"Студент: {Student.Name} {Student.LastName} " +
            $"Оценка: {Grade} " +
            $"Задание: \"{ExerciseRecord.Exercise}\"";
    }

    public string GetStudentView()
    {
        return
            $"Учитель: {Teacher.Name} {Teacher.LastName} " +
            $"Оценка: {Grade} " +
            $"Задание: \"{ExerciseRecord.Exercise}\"";
    }

    public override string ToString()
    {
        return GetTeacherView();
    }
}