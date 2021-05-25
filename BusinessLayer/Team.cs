using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Team
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Task> Tasks { get; set; }
        public List<string> Categories { get; set; }
        private static int IdCount = 0; 
        public Team()
        {
            Employees = new List<Employee>();
            Tasks = new List<Task>();
            Categories = new List<string>();
            IdCount++;
            ID = IdCount;
                
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
