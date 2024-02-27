using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>()
        {
            new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
            new Person(){ Name = "Oleg", Age = 15, City = "London" },
            new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
        };

        // 1) Выбрать людей, старших 25 лет.
        var olderThan25 = people.Where(person => person.Age > 25);
        PrintPeople("People older than 25:", olderThan25);

        // 2) Выбрать людей, проживающих не в Лондоне.
        var notInLondon = people.Where(person => person.City != "London");
        PrintPeople("People not living in London:", notInLondon);

        // 3) Выбрать имена людей, проживающих в Киеве.
        var kievResidents = people.Where(person => person.City == "Kyiv").Select(person => person.Name);
        Console.WriteLine("Names of people living in Kyiv:");
        foreach (var name in kievResidents)
        {
            Console.WriteLine(name);
        }

        // 4) Выбрать людей, старших 35 лет, с именем Sergey.
        var olderSergeys = people.Where(person => person.Name == "Sergey" && person.Age > 35);
        PrintPeople("Sergeys older than 35:", olderSergeys);

        // 5) Выбрать людей, проживающих в Одессе.
        var odessaResidents = people.Where(person => person.City == "Odesa");
        PrintPeople("People living in Odesa:", odessaResidents);
    }

    public static void PrintPeople(string message, IEnumerable<Person> people)
    {
        Console.WriteLine(message);
        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
        }
        Console.WriteLine();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
}
