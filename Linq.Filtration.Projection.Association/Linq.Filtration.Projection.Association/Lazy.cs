using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}

class Lazy
{
    static void Main()
    {
        List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
            new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department(){ Id = 3, Country = "France", City = "Paris" },
            new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
        };

        List<Employee> employees = new List<Employee>()
        {
            new Employee()
            { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee()
            { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee()
            { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee()
            { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee()
            { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee()
            { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
            new Employee()
            { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        // 1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.
        var ukrainianEmployeesExceptOdesa = employees
            .Where(emp => departments.Any(dep => dep.Id == emp.DepId && dep.Country == "Ukraine" && dep.City != "Odesa"))
            .Select(emp => new { emp.FirstName, emp.LastName });

        Console.WriteLine("Employees working in Ukraine, except Odesa:");
        foreach (var emp in ukrainianEmployeesExceptOdesa)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}");
        }

        // 2) Вывести список стран без повторений.
        var uniqueCountries = departments.Select(dep => dep.Country).Distinct();
        Console.WriteLine("\nUnique countries:");
        foreach (var country in uniqueCountries)
        {
            Console.WriteLine(country);
        }

        // 3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.
        var olderThan25Employees = employees.Where(emp => emp.Age > 25).Take(3);
        Console.WriteLine("\nOldest employees:");
        foreach (var emp in olderThan25Employees)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }

        // 4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.
        var kievStudentsAbove23 = employees
            .Where(emp => departments.Any(dep => dep.Id == emp.DepId && dep.City == "Kyiv") && emp.Age > 23)
            .Select(emp => new { emp.FirstName, emp.LastName, emp.Age });

        Console.WriteLine("\nStudents from Kyiv older than 23:");
        foreach (var emp in kievStudentsAbove23)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName}, Age: {emp.Age}");
        }
    }
}