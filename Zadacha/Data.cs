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
        private int id;
        private string title;
        private string description;
        private List<Task> tasks;
        private DateTime deadline;
        private bool isCompleted;


        public int Id { get; set; }
        public string Title {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrEmpty(title))
                        throw new ArgumentNullException("the title is null");
            }
        }

        public string Description { get; set; }
        public string Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description, string deadline)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id has to be a positive number");
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("the title is a must");
        }
    }
}
