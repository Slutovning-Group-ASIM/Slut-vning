using System;
using System.Collections.Generic;
using System.Text;

namespace TODO_app
{
    public class TaskManager
    {
        private List<TodoTask> tasks = new List<TodoTask>();

        // T2.1, T2.2 & T2.3
        public void DisplayAllTasks()
        {
            Console.WriteLine("\n--- ALLA UPPGIFTER ---");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Listan är tom.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    string status = tasks[i].IsCompleted ? "[Klar]" : "[ ]";
                    Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
                }
            }
        }

        public void AddTask(string desc)
        {
            tasks.Add(new TodoTask(desc));
            Console.WriteLine("Uppgift tillagd!");
        }
    }
}
