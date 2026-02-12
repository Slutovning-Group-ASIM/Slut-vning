using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class ToDoTask
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public Guid Id { get; set; }

        public ToDoTask(string title)
        {
            Title = title;
            IsCompleted = false;
            Id = Guid.NewGuid();
        }
    }
}