using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPRToDoService
{
    internal class ToDoService
    {
        private readonly static List<Tasks> tasks = new List<Tasks>();
        private static int nextId = 1;



        //Tasks deleteTask = FindById(id);

        //tasks.Remove(deleteTask);




        //Tasks completedTask = FindById(id);
        //completedTask.Completed();

        public List<Tasks> GetAll()
        {
            return tasks;
        }


        public Tasks FindById(int id)
        {
            foreach (Tasks Tasks in tasks)
            {
                if (Tasks.Id == id)
                {
                    return Tasks;
                }

            }


            return null;
        }
        public void Add(string t, string d, DateTime end)
        {


            Tasks Tasks = new Tasks(nextId, t, d, end);
            tasks.Add(Tasks);
            nextId++;

        }

        public void Complete(int id)
        {
            Tasks completedTask = FindById(id);
            if (completedTask == null)
            {
                throw new ArgumentException("Задачата не съществува. ");
            }
            completedTask.Completed();
        }

        public void Delete(int id)
        {
            Tasks deleteTask = FindById(id);
            if (deleteTask == null)
                throw new ArgumentException("Задачата не съществува. ");
            tasks.Remove(deleteTask);
        }
    }
}
