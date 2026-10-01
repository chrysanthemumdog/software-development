using System.Runtime.Intrinsics.Arm;
using System.IO;
using System.Text.Json;


namespace Zadacha
{
    internal class Program
    {            

        static string filepath = "Data.txt";
        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool running;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TODO MANAGER ===");
                Console.WriteLine("1. Добави нова задача");
                Console.WriteLine("2. Виж всички задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("5. Изход");
                Console.Write("Изберете опция (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;
                    case "2":
                        ViewTasks(tasks);
                        break;
                    case "3":
                        CompleteTask(tasks);
                        break;
                    case "4":
                        DeleteTask(tasks);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Програмата приключи работа.");
                        return;
                    default:
                        Console.WriteLine("Невалиден избор.");
                        Pause();
                        break;
                }
            }
        }

        static void AddTask(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Добавяне на нова задача ---");

            Console.Write("Въведете заглавие: ");
            string title = Console.ReadLine();

            Console.Write("Въведете описание: ");
            string description = Console.ReadLine();

            Console.Write("Въведете краен срок (пр. 2026-06-30): ");
            string deadline = Console.ReadLine();

            tasks.Add(new Task(title, description, deadline));

            Console.WriteLine("\nЗадачата беше добавена успешно!");
            Pause();
        }

        static void ViewTasks(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Списък със задачи ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Все още няма въведени задачи.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    var task = tasks[i];
                    string status = task.IsCompleted ? "[Изпълнена]" : "[Неизпълнена]";
                    Console.WriteLine($"{i + 1}. {task.Title} {status}");
                    Console.WriteLine($"   Описание: {task.Description}");
                    Console.WriteLine($"   Краен срок: {task.Deadline}");
                    Console.WriteLine("-----------------------------------------------------------");
                }
            }
            Pause();
        }

        static void CompleteTask(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Маркиране на задача като изпълнена ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма налични задачи.");
                Pause();
                return;
            }

            ViewTaskSummary(tasks);
            Console.Write("Въведете номер на задачата за маркиране: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
            {
                tasks[index - 1].IsCompleted = true;
                Console.WriteLine("Задачата е маркирана като изпълнена!");
            }
            else
            {
                Console.WriteLine("Невалиден номер на задача.");
            }
            Pause();
        }

        static void DeleteTask(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Изтриване на задача ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма налични задачи за изтриване.");
                Pause();
                return;
            }

            ViewTaskSummary(tasks);
            Console.Write("Въведете номер на задачата за изтриване: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Задачата беше изтрита успешно!");
            }
            else
            {
                Console.WriteLine("Невалиден номер на задача.");
            }
            Pause();
        }

        static void ViewTaskSummary(List<Task> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "Изпълнена" : "Неизпълнена";
                Console.WriteLine($"{i + 1}. {tasks[i].Title} ({status})");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНатиснете произволен клавиш, за да продължите...");
            Console.ReadKey();
        }

    }
}