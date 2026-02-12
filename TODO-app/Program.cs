using TODO_app;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TaskManager myManager = new TaskManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- TODO APP ---");
            Console.WriteLine("1. Visa uppgifter");
            Console.WriteLine("2. Lägg till uppgift");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myManager.DisplayAllTasks();
                    break;
                case "2":
                    Console.Write("Beskriv uppgiften: ");
                    string desc = Console.ReadLine();
                    myManager.AddTask(desc);
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }
    }
}