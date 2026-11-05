namespace UPRToDoService
{
    internal class Program
    {


        static void Main(string[] args)
        {        
            ToDoStorage storage = new ToDoStorage();
            ToDoService service = new ToDoService(storage);
            // Program program = new Program();
            while (true)
            {

                Menu();

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            {
                                AddTodo(service); Console.ReadLine();
                                break;
                            }
                        case "2":
                            {
                                ListAllTodos(service); Console.ReadLine();
                                break;
                            }
                        case "3":
                            {
                                CompleteTodo(service); Console.ReadLine();
                                break;
                            }
                        case "4":
                            {
                                DeleteTodo(service); Console.ReadLine();
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

        private static void DeleteTodo(ToDoService service)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Изтрий задача =======\n");
            ListAllTodos(service);

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

        private static void CompleteTodo(ToDoService service)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("=====  Маркирай задача като завършена =======\n");
            ListAllTodos(service);

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

        private static void ListAllTodos(ToDoService service)
        {
            
        
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("===== Всички задачи  =======");
            var ToDoItems = service.GetAll();
            if (ToDoItems.Count == 0)
            {
                Console.WriteLine("Няма въведени задачи");
            }
            else
            {
                foreach (ToDoItem todoItem in ToDoItems)
                {
                    Console.WriteLine($"{todoItem}");
                }
            }
        }

        private static void AddTodo(ToDoService service)
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
        static void Menu()
        {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("======= TODO MANAGER ========");
                Console.WriteLine("1. Добави задача");
                Console.WriteLine("2. Покажи задачи");
                Console.WriteLine("3. Маркирай задача като изпълнена");
                Console.WriteLine("4. Изтрий задача");
                Console.WriteLine("x. Изход");

                Console.WriteLine();
                Console.Write("Избор");
        }
    }
}
