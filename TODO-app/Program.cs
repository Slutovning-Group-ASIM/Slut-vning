using System;

namespace MyApp
{
    public class TodoTask // Class to represent a task in the TODO app
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }

    // DisplayMenu(); 
    // Method to display the menu options to the user
    public class TodoManager // Class to manage the methods related to the TODO app
    {
        public List<TodoTask> tasks = new List<TodoTask>(); // List to store the tasks

        // DisplayAllTasks();

        // DisplayTasksByStatus();

        // AddTask();
        
        // DeleteTask();

        // EditTask();

        // CompleteTask();
        public void CompleteTask(int id) // Method to complete a task based on its id
        {
            // Assuming user chose to complete task from menu, do the below steps
            TodoTask foundTask = tasks.FirstOrDefault(task => task.Id == id);      
            // if id match in list, show user message that task is completed
            if (foundTask != null)
            {
                // if task already completed, show user message that task is already completed
                if (foundTask.IsCompleted)
                {
                    Console.WriteLine("Task is already completed.");
                    return;
                }
                else if (!foundTask.IsCompleted)
                {
                    foundTask.IsCompleted = true;
                    Console.WriteLine("Task marked as completed.");
                    return;
                }
            }         
            // else show error message
            if (foundTask == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }            
        }
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }    
}