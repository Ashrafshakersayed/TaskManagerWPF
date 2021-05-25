using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class Program
    {
        //All Employees
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee{Name = "kero", Email = "kero@gmail.com", NID = 1001, Age = 30 },
            new Employee{Name = "Gorge", Email = "Gorge@gmail.com", NID = 1002, Age = 30 },
            new Employee{Name = "Ashrf", Email = "Ashrf@gmail.com", NID = 1003, Age = 30 },
            new Employee{Name = "Shahier", Email = "Shahier@gmail.com", NID = 1004, Age = 30 }

        };
        //All Teams
        public static List<Team> Teams = new List<Team>();



        //Opening 
        public static void Start()
        {
            //Data for test
            List<SubTask> subTasksForTask1 = new List<SubTask>
            {
                new SubTask("SubTask 1" ) ,
                new SubTask("SubTask 2") ,
                new SubTask("SubTask 3")
            };
            List<SubTask> subTasksForTask2 = new List<SubTask>
            {
                new SubTask("SubTask 1" ) ,
                new SubTask("SubTask 2") ,
                new SubTask("SubTask 3")
            };
            List<SubTask> subTasksForTask3 = new List<SubTask>
            {
                new SubTask("SubTask 1" ) ,
                new SubTask("SubTask 2") ,
                new SubTask("SubTask 3")
            };
            List<Task> tasks = new List<Task>();

            tasks.Add(new Task
            {
                Name = "Task 1",
                Priority = TaskPriority.High,
                Category = "cat 1",
                Deadline = DateTime.Now,
                State = TaskState.NotFinished,
                SubTasks = subTasksForTask1,
                Employees = new List<Employee> { Program.Employees[0] },
                Comments = new List<string>()
            });

            tasks.Add(new Task
            {
                Name = "Task 2",
                Priority = TaskPriority.Medium,
                Category = "cat 2",
                Deadline = DateTime.Now,
                State = TaskState.NotFinished,
                SubTasks = subTasksForTask2,
                Employees = new List<Employee> { Program.Employees[1] },
                Comments = new List<string>()
            });

            tasks.Add(new Task
            {
                Name = "Task 3",
                Priority = TaskPriority.Low,
                Category = "cat 3",
                Deadline = DateTime.Now,
                State = TaskState.NotFinished,
                SubTasks = subTasksForTask3,
                Employees = new List<Employee> { Program.Employees[2], Program.Employees[3] },
                Comments = new List<string>()
            });

            List<Employee> EmpList = new List<Employee>();
            foreach (var item in Employees)
            {
                EmpList.Add(item);
            }
            Teams.Add(new Team
            {
                Name = "Team 1",
                Employees = EmpList,
                Tasks = tasks,
                Categories = new List<string> { "cat 1", "cat 2", "cat 3" }
            });
        }

    }
}
