using System;
using System.Collections.Generic;

class Citizen
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string Address { get; set; }

    public Citizen(int id, string name, string birthDate, string address)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
        Address = address;
    }
}

class CivilRegistry
{
    private List<Citizen> citizens = new List<Citizen>();
    private int nextId = 1;

    public void AddCitizen(string name, string birthDate, string address)
    {
        Citizen newCitizen = new Citizen(nextId, name, birthDate, address);
        citizens.Add(newCitizen);
        Console.WriteLine($"Citizen added with ID: {nextId}");
        nextId++;
    }

    public void DisplayCitizens()
    {
        if (citizens.Count == 0)
        {
            Console.WriteLine("No citizens in the registry.");
            return;
        }
        Console.WriteLine("Civil Registry Records: ");
        foreach (var citizen in citizens)
        {
            Console.WriteLine($"ID: {citizen.Id}, Name: {citizen.Name}, Birth Date: {citizen.BirthDate}, Address: {citizen.Address}");
        }
    }

    public void DeleteCitizen(int id)
    {
        Citizen citizenToDelete = citizens.Find(c => c.Id == id);
        if (citizenToDelete != null)
        {
            citizens.Remove(citizenToDelete);
            Console.WriteLine($"Deleting Citizen: {citizenToDelete.Name}");
        }
        else
        {
            Console.WriteLine($"Citizen with ID {id} not found.");
        }
    }
}

class Program
{
    static void ShowMenu()
    {
        Console.WriteLine("Civil Registry System");
        Console.WriteLine("1. Add a new citizen");
        Console.WriteLine("2. Display all citizens");
        Console.WriteLine("3. Delete a citizen");
        Console.WriteLine("4. Exit");
    }

    static void Main()
    {
        CivilRegistry registry = new CivilRegistry();
        int choice;

        while (true)
        {
            ShowMenu();
            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter birth date (DD/MM/YYYY): ");
                    string birthDate = Console.ReadLine();
                    Console.Write("Enter address: ");
                    string address = Console.ReadLine();
                    registry.AddCitizen(name, birthDate, address);
                    break;
                case 2:
                    registry.DisplayCitizens();
                    break;
                case 3:
                    Console.Write("Enter ID of citizen to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }
                    registry.DeleteCitizen(id);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

