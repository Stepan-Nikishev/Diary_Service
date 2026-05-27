using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.DomainApp;

public static class Program
{
    public static void Main()
    {
        var teacher = new Teacher(
            new FirstName("Иван"),
            new MiddleName("Сергеевич"),
            new LastName("Петров"));

        var student = new Student(
            new FirstName("Алексей"),
            new MiddleName("Дмитриевич"),
            new LastName("Сидоров"));

        var exercise = teacher.CreateExercise(
            student,
            new Exercise("Задание 1"),
            DateTime.UtcNow);

        Console.WriteLine($"Задание: {exercise.Exercise.Value}");

        var solution = new Exercise("Решено задание 1");

        student.CompleteExercise(exercise, solution);

        Console.WriteLine($"Дата выполнения: {exercise.CompletedDate}");

        var journal = teacher.EvaluateExercise(
            exercise,
            new Grade(5),
            DateTime.UtcNow);

        Console.WriteLine($"Оценка: {journal.Grade}");
    }
}