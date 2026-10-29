using System.Threading.Tasks;

namespace UPRToDoService
{
    internal class Program
    {
        static ToDoService service = new ToDoService();

        static void Main(string[] args)
        {
            // Program program = new Program();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("======= TODO MANAGER ========");
                Console.WriteLine("1. Добави задача");
                Console.WriteLine("2. Покажи задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("x. Изход");

                Console.WriteLine();
                Console.Write("Избор: ");
                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            {
                                AddTodo(); Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                ListAllTodos(); Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                CompleteTodo(); Console.ReadLine();
                                break;
                            }
                        case "4":
                            {
                                DeleteTodo(); Console.ReadLine();
                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine("Край на програмата");
                                Console.ReadLine();
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Невалиден избор.");
                                break;
                            }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void DeleteTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Изтрий задача =======\n");
            ListAllTodos();

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            service.Delete(id);
            Console.WriteLine("Задачата е изтрита.");
        }

        private static void CompleteTodo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Маркирай задача като завършена =======\n");
            ListAllTodos();

            Console.Write("Избери Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невалидно id.");
                Console.Write("Избери Id: ");
            }

            service.Complete(id);
            Console.WriteLine("Задачата е завършена.");


        }

        private static void ListAllTodos()
        {
            
        
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===== Всички задачи  =======");
            var tasks = service.GetAll();
            if (tasks.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи");
            }
            else
            {
                foreach (Tasks todoItem in tasks)
                {
                    Console.WriteLine($"{todoItem}");
                }
            }
        }

        private static void AddTodo()
        {
            Console.Clear();
            Console.WriteLine("=====  Добавяне на задача =======");

            Console.Write("Заглавие:");
            string title = Console.ReadLine();

            Console.Write("Описание:");
            string description = Console.ReadLine();

            Console.Write("Краен срок:");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.WriteLine("Невалидна дата. Въведи отново!");
                Console.Write("Краен срок: ");
            }

            service.Add(title, description, dueDate);

            Console.WriteLine("Задачата е добавена.");
        }
    }
}
