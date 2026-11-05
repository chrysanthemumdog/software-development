using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace UPRToDoService
{
    internal class FileStorage
    {
        private readonly string path;

        public FileStorage(string path)
        {
            this.path = path;
        }

        public ToDoStorage Load()
        {
            if (File.Exists(path))
            {
                return new ToDoStorage();
            }

            string json = File.ReadAllText(path);
            ToDoStorage todoStorage  = JsonSerializer.Deserialize<ToDoStorage>(json);

            return todoStorage;
        }

        public void Save(ToDoStorage toDoStorage)
        {
            string json = JsonSerializer.Serialize(toDoStorage);
            File.WriteAllText(path, json);
        }
    }
}
