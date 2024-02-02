using System;

class MyProgram
{
    static void Main(string[] args)
    {
        // Create a base "Task" object
        Task t1 = new Task("John Smith", "Mathematics");
        Console.WriteLine(t1.GetOverview());

        // Now create the derived class tasks
        MathTask t2 = new MathTask("Elena Gonzalez", "Geometry", "5.2", "10-20");
        Console.WriteLine(t2.GetOverview());
        Console.WriteLine(t2.GetTaskDetails());

        WritingTask t3 = new WritingTask("Carlos Rivera", "World Literature", "The Impact of Shakespeare");
        Console.WriteLine(t3.GetOverview());
        Console.WriteLine(t3.GetWritingDetails());
    }
}