using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal Cost { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Project(int projectId, string projectName, decimal cost, DateTime start, DateTime finish, ICollection<Employee> employees)
        {
            ProjectId = projectId;
            ProjectName = projectName;
            Cost = cost;
            Start = start;
            Finish = finish;
            Employees = employees;
        }
    }
}
