namespace TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter name: ");
            string Name = Console.ReadLine();
            /*
                        Console.Write("Enter age: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Enter height: ");
                        int height = int.Parse(Console.ReadLine());

                        Console.Write("Enter grade: ");
                        byte grade = byte.Parse(Console.ReadLine());

                        Console.Write("Enter mean of grades: ");
                        double gradesMean = double.Parse(Console.ReadLine());

                        Console.Write("Enter tax: ");
                        decimal tax = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter stipend: ");
                        bool Stipend = bool.Parse(Console.ReadLine());

                        Console.Write("Enter class: ");
                        char Class = char.Parse(Console.ReadLine());

                        Console.Write("Enter birthday: ");
                        DateTime Birthday = DateTime.Parse(Console.ReadLine());

                        if (int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine($"Възраст: {age}");
                        }
                        else
                        {
                            Console.WriteLine("Невалидна възраст.");
                        }

                        if (grade <= 12 && grade >= 1)
                        {
                            Console.WriteLine($"Клас: {grade}");
                        }
                        else
                        {
                            Console.WriteLine("Невалиден клас.");
                        }

                        */

            int age;
            Console.Write("Въведете възраст:");
            while (!int.TryParse(Console.ReadLine(), out age) || age <= 6 || age >= 19)
            {
                Console.WriteLine("Невалидна възраст.");
            }

            byte grade;
            Console.Write("Въведете клас:");
            while (!byte.TryParse(Console.ReadLine(), out grade) || grade <= 1 || grade >= 12)
            {
                Console.WriteLine("Невалиден клас.");
            }

            double meanGrade;
            Console.Write("Въведете среден успех:");
            while (!double.TryParse(Console.ReadLine(), out meanGrade) || meanGrade < 2.00 || meanGrade > 6.00)
            {
                Console.WriteLine("Невалиден успех.");
            }

            decimal tax;
            Console.Write("Въведете такса:");
            while (!decimal.TryParse(Console.ReadLine(), out tax) || tax <= 0)
            {
                Console.WriteLine("Невалидна такса.");
            }

            bool hasScholarship;
            Console.Write("Въведете дали ученика взима стипендия:");
            while (!bool.TryParse(Console.ReadLine(),  out hasScholarship))
            {
                Console.WriteLine(hasScholarship);
            }                
                Console.WriteLine("Невалиден отговор.");
            {

            char Class;
            Console.Write("Въведете паралелка:");
            while (!char.TryParse(Console.ReadLine(), out Class))
            {
                Console.WriteLine("Невалидна паралелка.");
            }

            DateTime Birthdate;
            Console.Write("Въведете рожденна дата:");
            while (!DateTime.TryParse(Console.ReadLine(), out Birthdate))
            {
                Console.WriteLine("Невалидна рожденна дата.");
            }


        }
    }
}
