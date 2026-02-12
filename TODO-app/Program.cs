using System;
using System.Linq;
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
        public static void DeleteTask(int id)
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
                Console.WriteLine("[5] - Redigera uppgift");
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
                            int id = ChooseId();
                            if (id != -1)
                            {
                                CompleteTask(id);
                            }
                            break;
                        case 4:
                            int id2 = ChooseId();
                            if (id2 != -1)
                            {
                                DeleteTask(id2);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Redigera uppgift");
                            Console.WriteLine("================\n\n");

                            // Show list of tasks so the user can see/choose ID
                            DisplayAllTasks();

                            Console.Write("\nAnge ID på uppgiften du vill ändra: ");
                            if (int.TryParse(Console.ReadLine(), out int editId))
                            {
                                Console.Write("Ange ny titel: ");
                                string newTitle = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(newTitle))
                                {
                                    EditTask(editId, newTitle);
                                }
                                else
                                {
                                    Console.WriteLine("Titeln får inte vara tom.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt ID.");
                            }
                            break;
                        case 0:
                            isRunning = false;
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
        // 
        public static int ChooseId()
        {            
            // menu to let user either show all tasks or choose id straight away
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("[1] - Visa alla uppgifter");
            Console.WriteLine("[2] - Välj ID direkt");
            Console.WriteLine("[0] - Avbryt");
            while (true)
            {
            string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllTasks();
                            break;
                        case 2:
                            Console.WriteLine("Ange ID för uppgiften:");
                            string idInput = Console.ReadLine();
                            if (int.TryParse(idInput, out int id))
                            {
                                return id;
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt ID, försök igen.");
                                return -1; // Returnerar -1 för att indikera ogiltigt ID
                            }
                        case 0:
                            // exit the method and return to main menu
                            return -1; // Returnerar -1 för att indikera avbrott
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            return -1; // Returnerar -1 för att indikera ogiltigt val
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    return -1; // Returnerar -1 för att indikera ogiltigt val
                }
            }            
        }

         // CompleteTask();
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
        public static void EditTask(int id, string newTitle)
        {
            // Find task based on ID
            ToDoTask taskToEdit = tasks.FirstOrDefault(t => t.Id == id);

            if (taskToEdit != null)
            {
                taskToEdit.Title = newTitle;
                Console.WriteLine($"Uppgift {id} har uppdaterats till: {newTitle}");
            }
            else
            {
                Console.WriteLine($"Kunde inte hitta någon uppgift med ID: {id}");
            }
        }




    }

}
