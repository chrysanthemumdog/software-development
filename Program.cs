using System;
using System.Globalization;

namespace Homework
{
    internal class Program
    {
        private static int nextId = 1;

        static void Main(string[] args)
        {
            int currentId = nextId++;
            Student student = new Student(currentId, "Temp");

            Console.WriteLine("=== ДАННИ ЗА УЧЕНИК ===");

            while (true)
            {
                try
                {
                    Console.Write("Въведете име: ");
                    student.Name = Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте пак.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете възраст: ");
                    student.Age = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете клас: ");
                    student.Grade = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете среден успех: ");
                    student.AverageScore = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете такса: ");
                    student.Fee = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            while (true)
            {
                Console.Write("Получава ли стипендия? (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool scholarship))
                {
                    student.HasScholarship = scholarship;
                    break;
                }
                Console.WriteLine("Моля въведете true или false.");
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете паралелка: ");
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        student.ClassLetter = input[0];
                        break;
                    }
                    throw new ArgumentException("Не може да няма паралелка.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Въведете дата на раждане (dd.MM.yyyy): ");
                    student.BirthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Опитайте отново.");
                }
            }

            Console.WriteLine("\n=== ДАННИ ЗА УЧЕНИК ===");
            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"Име: {student.Name}");
            Console.WriteLine($"Възраст: {student.Age}");
            Console.WriteLine($"Клас: {student.Grade}");
            Console.WriteLine($"Среден успех: {student.AverageScore:F2}");
            Console.WriteLine($"Такса: {student.Fee:F2} лв.");
            Console.WriteLine($"Стипендия: {(student.HasScholarship ? "Да" : "Не")}");
            Console.WriteLine($"Паралелка: {student.ClassLetter}");
            Console.WriteLine($"Дата на раждане: {student.BirthDate:dd.MM.yyyy}");

        }
    }
}
