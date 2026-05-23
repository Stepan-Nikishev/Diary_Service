using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;

var teacher = new Teacher(
    new FirstName("Иван"),
    new MiddleName("Сергеевич"),
    new LastName("Петров"));

var student1 = new Student(
    new FirstName("Алексей"),
    new MiddleName("Игоревич"),
    new LastName("Смирнов"));

var student2 = new Student(
    new FirstName("Мария"),
    new MiddleName("Андреевна"),
    new LastName("Кузнецова"));

var exercise1 = teacher.GiveExercise(
    student1,
    new Exercise("Задание1"),
    DateTime.UtcNow);

var exercise2 = teacher.GiveExercise(
    student2,
    new Exercise("Задание2"),
    DateTime.UtcNow);

Console.WriteLine();

Console.WriteLine(teacher.ViewIssuedExercises());

Console.WriteLine();

student1.CompleteExercise(
    exercise1,
    new Exercise("Задание1 выполнено"));

student2.CompleteExercise(
    exercise2,
    new Exercise("Задание2 выполнено"));

teacher.GradeStudent(
    student1,
    exercise1,
    new Grade(5),
    DateTime.UtcNow);

teacher.GradeStudent(
    student2,
    exercise2,
    new Grade(4),
    DateTime.UtcNow);

Console.WriteLine(teacher.ViewJournal());

Console.WriteLine();

Console.WriteLine(student1.ViewJournal());

Console.WriteLine();

Console.WriteLine(student2.ViewJournal());