using System;
using System.Collections.Generic;

public class Resume
{
    public string PersonName { get; }
    public List<Job> Jobs { get; }

    public Resume(string personName)
    {
        PersonName = personName;
        Jobs = new List<Job>();
    }

    public void AddJob(Job job)
    {
        Jobs.Add(job);
    }

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {PersonName}");
        Console.WriteLine("Jobs:");
        foreach (var job in Jobs)
        {
            job.DisplayJobDetails();
        }
    }
}