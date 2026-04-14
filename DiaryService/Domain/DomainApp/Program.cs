using DiaryService.Domain.DiaryService.Domain.Entities;
using DiaryService.Domain.DiaryService.ValueObjects;

namespace DiaryService.Domain.DomainApp;

class Program
{
    static void Main(string[] args)
    {
        var teacher = new Teacher(
            new FirstName("Иван"),
            new MiddleName("Иванович"),
            new LastName("Иванов"));

        var student = new Student(
            new FirstName("Петр"),
            new MiddleName("Петрович"),
            new LastName("Петров"));

        var student2 = new Student(
            new FirstName("Александр"),
            new MiddleName("Александрович"),
            new LastName("Александров"));


        var teacherAccount = teacher.CreateTeacherAccount(
            new FirstName("Иван"),
            new MiddleName("Иванович"),
            new LastName("Иванов"));

        var studentAccount = student.CreateStudentAccount(
            new FirstName("Петр"),
            new MiddleName("Петрович"),
            new LastName("Петров"));

        var studentAccount2 = student2.CreateStudentAccount(
            new FirstName("Александр"),
            new MiddleName("Александрович"),
            new LastName("Александров"));

        Console.WriteLine("1. Добавление оценок и заданий:");
        teacher.Grade(teacherAccount, studentAccount, new Grade(5));
        teacher.Grade(teacherAccount, studentAccount, new Grade(4));
        teacher.Exercise(teacherAccount, studentAccount, new Exercise("Решить уравнения"));
        teacher.Exercise(teacherAccount, studentAccount, new Exercise("Написать сочинение"));
        Console.WriteLine();


        Console.WriteLine("1.1 Добавление оценок и заданий другому ученику:");
        teacher.Grade(teacherAccount, studentAccount2, new Grade(3));
        teacher.Grade(teacherAccount, studentAccount2, new Grade(2));
        teacher.Exercise(teacherAccount, studentAccount2, new Exercise("Написать сочинение"));
        Console.WriteLine();


        Console.WriteLine("2. Выполнение задания:");
        student.CompletedExercise(studentAccount, teacherAccount, new Exercise("Решить уравнения"));
        Console.WriteLine();


        Console.WriteLine("3. Журнал учителя (все записи):");
        Console.WriteLine(teacher.ViewJournal(teacherAccount));
        Console.WriteLine();


        Console.WriteLine("4. Журнал ученика (только его записи):");
        Console.WriteLine(student.ViewJournal(studentAccount, teacherAccount));
        Console.WriteLine();

        Console.WriteLine("4.1 Журнал ученика2 (только его записи):");
        Console.WriteLine(student2.ViewJournal(studentAccount2, teacherAccount));
        Console.WriteLine();


        Console.WriteLine("5. Учитель смотрит журнал ученика:");
        Console.WriteLine(teacher.ViewJournal(teacherAccount, studentAccount));
        Console.WriteLine();

        Console.WriteLine("5.1 Учитель смотрит журнал ученика2:");
        Console.WriteLine(teacher.ViewJournal(teacherAccount, studentAccount2));
        Console.WriteLine();


        Console.WriteLine("6. Выполненные задания ученика:");
        Console.WriteLine(student.ViewMyCompletedExercises(studentAccount));

    }

}