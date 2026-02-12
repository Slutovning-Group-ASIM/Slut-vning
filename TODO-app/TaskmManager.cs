using System;
using System.Collections.Generic;
using System.Text;

public void DisplayAllTasks()
{
    Console.Clear();
    Console.WriteLine("--- DIN ATT-GÖRA-LISTA ---");

      if (tasks.Count == 0)
    {
        Console.WriteLine("Inga uppgifter att visa.");
        return;
    }

   
    Console.WriteLine($"{"ID",-5} {"Status",-10} {"Titel"}");
    Console.WriteLine("-----------------------------------");

    for (int i = 0; i < tasks.Count; i++)
    {
              int id = i + 1;

                string statusSymbol = tasks[i].IsCompleted ? "[X] Klar" : "[ ] Ej klar";

        if (tasks[i].IsCompleted) Console.ForegroundColor = ConsoleColor.Green;

              Console.WriteLine($"{id,-5} {statusSymbol,-10} {tasks[i].Description}");

        Console.ResetColor();
    }
}

public void AddTask(string desc)
    {
        tasks.Add(new TodoTask(desc));
        Console.WriteLine("Uppgift tillagd!");
    }
}

