using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title, string description, string deadline)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
        }
    }
}
