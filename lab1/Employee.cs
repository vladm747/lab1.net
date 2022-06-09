using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Employee: Person
    {
        public string Position { get; set; }
        public Employee(int id, string name, string position) :base(id, name)
        {
            Position = position;
        }

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
