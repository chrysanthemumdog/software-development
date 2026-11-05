using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UPRToDoService
{
    internal class ToDoService
    {
       // private readonly static List<ToDoItem> ToDoItems = new List<ToDoItem>();
        //private static int nextId = 1;

            private readonly ToDoStorage storage;
            public ToDoService(ToDoStorage storage)
            {
                this.storage = storage;
            }

        public IReadOnlyList<ToDoItem> GetAll()
        {
            return storage.Todos;
        }

        //ToDoItem deleteToDoItem = FindById(id);

        //ToDoItems.Remove(deleteToDoItem);

        //ToDoItem completedToDoItem = FindById(id);
        //completedToDoItem.Completed();

        //public List<ToDoItem> GetAll()
        //{
        //    return storage;
        //}

        public ToDoItem FindById(int id)
        {
            foreach (ToDoItem ToDoItems in storage.Todos)
            {
                if (ToDoItems.Id == id)
                {
                    return ToDoItems;
                }

            }


            return null;
        }
        public void Add(string t, string d, DateTime end)
        {


            ToDoItem ToDoItems = new ToDoItem(storage.NextId, t, d, end);
            storage.Todos.Add(ToDoItems);
            storage.NextId++;

        }

        public void Complete(int id)
        {
            ToDoItem completedToDoItem = FindById(id);
            if (completedToDoItem == null)
            {
                throw new ArgumentException("Задачата не съществува. ");
            }
            completedToDoItem.Completed();
        }

        public void Delete(int id)
        {
            ToDoItem deleteToDoItem = FindById(id);
            if (deleteToDoItem == null)
                throw new ArgumentException("Задачата не съществува. ");
            storage.Todos.Remove(deleteToDoItem);
        }
    }
}
