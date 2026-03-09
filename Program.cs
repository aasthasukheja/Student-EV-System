using System;

namespace StudentEligibilitySystem
{
    // 1. Entity Class
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public int Age { get; set; }
        public int Attendance { get; set; }
    }

    // 3. Eligibility Engine
    class EligibilityEngine
    {
        public void CheckEligibility(Student student, string program, Predicate<Student> rule)
        {
            bool result = rule(student);

            Console.WriteLine("========= ELIGIBILITY CHECK =========");
            Console.WriteLine("Student Name : " + student.Name);
            Console.WriteLine("Program      : " + program);
            Console.WriteLine("Eligible     : " + result);
            Console.WriteLine("-----------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 4. Create Student Object (Hardcoded Dataset)
            Student student = new Student
            {
                StudentId = 301,
                Name = "Ananya",
                Marks = 78,
                Age = 18,
                Attendance = 85
            };

            // 2. Define Eligibility Predicates

            // Engineering Rule
            Predicate<Student> engineeringEligibility = s => s.Marks >= 60;

            // Medical Rule
            Predicate<Student> medicalEligibility = s => s.Marks >= 70 && s.Age >= 17;

            // Management Rule
            Predicate<Student> managementEligibility = s => s.Marks >= 55 && s.Attendance >= 75;

            // Create Eligibility Engine
            EligibilityEngine engine = new EligibilityEngine();

            // Validate Programs
            engine.CheckEligibility(student, "Engineering", engineeringEligibility);
            engine.CheckEligibility(student, "Medical", medicalEligibility);
            engine.CheckEligibility(student, "Management", managementEligibility);

            Console.ReadLine();
        }
    }
}





// 5

using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

public class AnalysisEngine
{
    public void Analyze(List<Student> students)
    {
        Console.WriteLine("Passed Students:");
        Console.WriteLine(string.Join("\n",
            students.Where(s => s.Marks >= 50)
                    .Select(s => s.Name)));

        Console.WriteLine();

        Console.WriteLine("Topper:");
        Console.WriteLine(students
            .OrderByDescending(s => s.Marks)
            .Select(s => s.Name + " - " + s.Marks)
            .First());

        Console.WriteLine();

        Console.WriteLine("Students Sorted by Marks:");
        Console.WriteLine(string.Join("\n",
            students.OrderByDescending(s => s.Marks)
                    .Select(s => s.Name + " - " + s.Marks)));
    }
}

public class Solution
{
    public static void Main()
    {
        var students = new List<Student>
        {
            new Student { StudentId = 101, Name = "Ananya", Marks = 78 },
            new Student { StudentId = 102, Name = "Ravi", Marks = 45 },
            new Student { StudentId = 103, Name = "Neha", Marks = 88 },
            new Student { StudentId = 104, Name = "Arjun", Marks = 67 }
        };

        new AnalysisEngine().Analyze(students);
              Console.WriteLine();
    }
}


// 6

using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

public class InventoryEngine
{
    public void Analyze(List<Product> products)
    {
        Console.WriteLine("Low Stock Products:");
        Console.WriteLine(string.Join("\n",
            products.Where(p => p.Quantity < 10)
                    .Select(p => p.Name)));

        Console.WriteLine();

        Console.WriteLine("Products Sorted by Price:");
        Console.WriteLine(string.Join("\n",
            products.OrderBy(p => p.Price)
                    .Select(p => p.Name + " - " + (int)p.Price)));

        Console.WriteLine();

        Console.WriteLine("Total Inventory Value:");
        Console.WriteLine("Rs " + (int)products.Sum(p => p.Price * p.Quantity));
    }
}

public class Solution
{
    public static void Main()
    {
        var products = new List<Product>
        {
            new Product { ProductId = 201, Name = "Laptop", Price = 60000, Quantity = 5 },
            new Product { ProductId = 202, Name = "Mouse", Price = 800, Quantity = 25 },
            new Product { ProductId = 203, Name = "Keyboard", Price = 1500, Quantity = 8 },
            new Product { ProductId = 204, Name = "Monitor", Price = 12000, Quantity = 12 }
        };

        new InventoryEngine().Analyze(products);
              Console.WriteLine();
    }
}


// 7

using System;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int Experience { get; set; }
    public double Salary { get; set; }
    public int PerformanceRating { get; set; }
}

public class PromotionEngine
{
    public void Validate(Employee employee, string department, Predicate<Employee> rule)
    {
        bool result = rule(employee);

        Console.WriteLine("========= PROMOTION VALIDATION =========");
        Console.WriteLine("Employee Name : " + employee.Name);
        Console.WriteLine("Department    : " + department);
        Console.WriteLine("Eligible      : " + result);
        Console.WriteLine("--------------------------------------\n");
    }
}

public class Solution
{
    public static void Main()
    {
        Employee employee = new Employee
        {
            EmployeeId = 501,
            Name = "Ravi",
            Experience = 5,
            Salary = 65000,
            PerformanceRating = 4
        };

        // Promotion Rules using Predicate
        Predicate<Employee> technicalRule = e => e.Experience >= 3;

        Predicate<Employee> hrRule = e => e.Experience >= 2 && e.PerformanceRating >= 4;

        Predicate<Employee> managementRule = e => e.Experience >= 5 && e.Salary >= 60000;

        PromotionEngine engine = new PromotionEngine();

        engine.Validate(employee, "Technical", technicalRule);
        engine.Validate(employee, "HR", hrRule);
        engine.Validate(employee, "Management", managementRule);
    }
}


// 8
using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}

public class AnalyticsEngine
{
    public void Analyze(List<Employee> employees)
    {
        Console.WriteLine("High Salary Employees:");
        employees.Where(e => e.Salary >= 50000)
                 .Select(e => e.Name)
                 .ToList()
                 .ForEach(Console.WriteLine);

        Console.WriteLine();
        Console.WriteLine("Employees Sorted by Salary:");
        employees.OrderByDescending(e => e.Salary)
                 .Select(e => e.Name + " - " + e.Salary)
                 .ToList()
                 .ForEach(Console.WriteLine);

        Console.WriteLine();
        Console.WriteLine("Average Salary:");
        Console.WriteLine("Rs " + employees.Average(e => e.Salary));
    }
}

public class Solution
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee{EmployeeId=301, Name="Ramesh", Salary=45000},
            new Employee{EmployeeId=302, Name="Suresh", Salary=52000},
            new Employee{EmployeeId=303, Name="Kavya", Salary=68000},
            new Employee{EmployeeId=304, Name="Anita", Salary=39000}
        };

        AnalyticsEngine engine = new AnalyticsEngine();
        engine.Analyze(employees);
        Console.WriteLine();
    }
}