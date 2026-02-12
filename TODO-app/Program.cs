using System;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ToDoTask.DisplayMenu();
        }

    }

public class ToDoTask
    {
        public static List<ToDoTask> tasks = new();
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        private static int _nextId = 1;
        public int Id { get; private set; }

        public ToDoTask(string title)
        {
            Title = title;
            IsCompleted = false;
            Id = _nextId++;
        }

        public ToDoTask()
        {
        }

        public static void AddTask(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Titeln får inte vara tom. Försök igen.");
            }
            else
            {
                Console.WriteLine($"\n{title} har lagts till i din To Do lista.");
                tasks.Add(new ToDoTask(title));
                Console.WriteLine("\nTryck ENTER för att gå tillbaka till menyn...");
                Console.ReadLine();
            }


        }
        public void DeleteTask(int id)
        {
            
            var selectedId = tasks.FirstOrDefault(p => p.Id == id); // Checks if object with id excists
            if(selectedId != null)
            {
                tasks.Remove(selectedId);
                System.Console.WriteLine("Produkten har tagits bort!");
            }
            else
                System.Console.WriteLine("Något gick fel");
                
        }
        public static void DisplayMenu()
        {
            bool isRunning = true;
            var service = new ToDoTask();
            while (isRunning)
            {
                Console.WriteLine("\nVälkommen till din To Do List!\n");
                Console.WriteLine("[1] - Lägg till uppgift");
                Console.WriteLine("[2] - Visa alla uppgifter");
                Console.WriteLine("[3] - Markera som klar");
                Console.WriteLine("[4] - Ta bort uppgift");
                Console.WriteLine("[0] - Avsluta\n");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ange uppgiftens titel:");
                            string title = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(title))
                            {
                                Console.WriteLine("Titeln får inte vara tom. Försök igen.");
                            }
                            else
                            {
                                AddTask(title);
                            }
                            Console.Clear();
                            break;
                        case 2:
                            DisplayAllTasks();
                            break;
                        case 3:
                            // CompleteTask();
                            break;
                        case 4:
                            isRunning = false;
                            break;
                        case 0:
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                }
            }
        }

        public static void CompleteTask(int id)
        {

            ToDoTask task = tasks.FirstOrDefault(task => task.Id == id);

            if (task != null)
            {

                if (task.IsCompleted)
                {
                    Console.WriteLine("Task is already completed.");
                    return;
                }
                else if (!task.IsCompleted)
                {
                    task.IsCompleted = true;
                    Console.WriteLine("Task marked as completed.");
                    return;
                }
            }
            // else show error message
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }
        }
        public static void DisplayAllTasks()
        {
            Console.Clear();
            Console.WriteLine("--- To Do: ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No data to display.");
                return;
            }


            Console.WriteLine($"{"ID",-5} {"Status",-10} {"Titel"}");
            Console.WriteLine("-----------------------------------");

            for (int i = 0; i < tasks.Count; i++)
            {
                //      int id = i + 1;

                string statusSymbol = tasks[i].IsCompleted ? "[X] Done" : "[ ] Not done :";

                if (tasks[i].IsCompleted) Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{tasks[i].Id,-5} {statusSymbol,-10} {tasks[i].Title}");

                Console.ResetColor();
            }
        }




    }

}