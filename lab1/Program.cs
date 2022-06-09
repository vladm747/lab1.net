using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            { 
                new Employee(0, "Makogonenko Olexandr", "Middle Angular"),
                new Employee(1, "Pishchuk Maxym", "Senior C#"),
                new Employee(2, "Dukhovny Daniel", "Senior C#"),
                new Employee(3, "Moroz Vladyslav", "Junior C#"),
                new Employee(4, "Vyshnepolskiy Tima", "Junior QA")
            };
            List<Employee> emp1 = new List<Employee>();
            emp1.Add(employees[2]);
            emp1.Add(employees[1]);
            emp1.Add(employees[4]);

            List<Employee> emp2 = new List<Employee>();
            emp2.Add(employees[0]);
            emp2.Add(employees[1]);
            emp2.Add(employees[3]);
            emp2.Add(employees[4]);


            List<Employee> emp3 = new List<Employee>();
            emp3.Add(employees[2]);
            emp3.Add(employees[3]);
            emp3.Add(employees[4]);

            List<Project> projects = new List<Project>()
            {
                new Project(0, "Forum", 450, DateTime.Now, DateTime.Now.AddDays(21), emp1),
                new Project(1, "Knowledge Accounting System", 300, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(13), emp2),
                new Project(2, "File Storage", 277, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(22), emp3)
            };

            foreach (var emp in emp1)
            {
                emp.Projects.Add(projects[0]);
            }
            foreach (var emp in emp2)
            {
                emp.Projects.Add(projects[1]);
            }
            foreach (var emp in emp3)
            {
                emp.Projects.Add(projects[2]);
            }


            Console.WriteLine("Output all project names: ");
            var q1 = from x in projects
                     select x.ProjectName;
            foreach (var x in q1)
                Console.WriteLine(x);
            Console.WriteLine();

            
            Console.WriteLine("Output all project names that starts with 'F': ");
            var q2 = from x in projects
                     where x.ProjectName.StartsWith('F')
                     select x.ProjectName;
            foreach (var x in q2)
                Console.WriteLine(x);
            Console.WriteLine();

           
            Console.WriteLine("Output projects that started earlier than 07/06/2022: ");
            var q3 = from x in projects
                     where x.Start <= DateTime.Now.AddDays(-1)
                     select x.ProjectName + " - " + x.Start.ToString();
            foreach (var x in q3)
                Console.WriteLine(x);
            Console.WriteLine();
            
            Console.WriteLine("Output projects in ascending order of  the finish date : ");
            var q4 = projects.OrderBy(x=>x.Finish).Select(x => x.ProjectName + " - " + x.Finish);
            foreach (var x in q4)
                Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Group employees by their positions");
            var q5 = from x in employees
                     group x by x.Position;

            foreach (var x in q5)
            {
                Console.WriteLine(x.Key);
                foreach (var item in x)
                {
                    Console.WriteLine(item.PersonName);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Output projects in descending order of  the start date : ");
            var q6 = projects.OrderByDescending(x => x.Start).Select(x => x.ProjectName + " - " + x.Start);
            foreach (var x in q6)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Output all projects and names of employees: ");

            var q7 = from x in projects
                     group x by x.ProjectName;

            foreach (var x in q7)
            {
                Console.WriteLine(x.Key + ":");
                foreach (var item in x)
                {
                    foreach (var emp in item.Employees)
                    {
                        Console.WriteLine(emp.PersonName);
                    }
                }
                Console.WriteLine();
            }

            var q13 = employees.OrderByDescending(x => x.PersonName).Select(emp => emp.PersonName).ToList();
            foreach (var x in q13)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Output all project names that doesn`t have any 'F' in the name:  ");
            var q8 = from x in projects
                     where !x.ProjectName.Contains('F')
                     select x.ProjectName;
            foreach (var x in q8)
                Console.WriteLine(x);
            Console.WriteLine();


            Console.WriteLine("Output all projects and positions of employees: ");
            var q9 = from x in projects
                     group x by x.ProjectName;

            foreach (var x in q9)
            {
                Console.WriteLine(x.Key + ":");
                foreach (var item in x)
                {
                    foreach (var emp in item.Employees)
                    {
                        Console.WriteLine(emp.Position);
                    }
                }
                Console.WriteLine();
            }

            var q10 = projects.Where(p => p.Cost >= 300).Select(p => p.ProjectName + ": " + p.Cost);
            foreach (var x in q10)
                Console.WriteLine(x);
            Console.WriteLine();

            var q11 = projects.Select(p => p.ProjectName + ": " + p.Start.ToShortDateString() + "-" + p.Finish.ToShortDateString());
            foreach (var x in q11)
                Console.WriteLine(x);
            Console.WriteLine();

            var q12 = employees.OrderBy(x => x.PersonName).Select(emp=>emp.PersonName).ToList();
            foreach (var x in q12)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Output employees that don`t have 'senior' position");
            var q14 = from emp in employees
                      where !emp.Position.Contains("Senior")
                      select emp.PersonName + "-" + emp.Position;
            foreach (var x in q14)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Output all employees and their projects");
            var q15 = from emp in employees
                      group emp by emp.PersonName;
            foreach (var x in q15)
            {
                Console.WriteLine(x.Key + ":");
                foreach (var item in x)
                {
                    foreach (var emp in item.Projects)
                    {
                        Console.WriteLine(emp.ProjectName);
                    }
                }
                Console.WriteLine();
            }

            var q16 = from x in projects
                      from emp in x.Employees
                      join y in employees
                        on emp.PersonName equals y.PersonName;
        }
    }
}
