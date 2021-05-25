using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public enum TaskPriority
    {
        High,
        Medium,
        Low
    }
    public enum TaskState
    {
        NotFinished,
        Finished
    }
    public class SubTask
    {
        public string Name;
        public bool CheckSubTask;

        public SubTask(string text) 
        {
            Name = text;
            CheckSubTask = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class Task
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }
        public string Category { get; set; }
        public TaskState State { get; set; }
        public List<SubTask> SubTasks { get; set; }
        public List<String> Comments { get; set; }
        public List<string> Files { get; set; }
        public List<Employee> Employees { get; set; }

        private static int IdCount = 0;
        public Task()
        {
            State = TaskState.NotFinished;
            Files = new List<string>();
            SubTasks = new List<SubTask>();
            Employees = new List<Employee>();
            IdCount++;
            ID = IdCount; 
        }
    }
}
