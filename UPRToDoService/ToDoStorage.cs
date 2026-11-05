using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UPRToDoService
{
    internal class ToDoStorage
    {
        public int NextId { get; set; } = 1;
        public List<ToDoItem> Todos { get; set; } = new();
    }
}
