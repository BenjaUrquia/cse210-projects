using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Activity
{
    protected string description;
    protected int duration;

    public Activity(string activityName, string activityDescription)
    {
        description = activityDescription;
        Console.WriteLine($"------ {activityName} ------\n{description}");
        Console.Write($"Enter the duration of the activity in seconds for {activityName}: ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nGet ready to begin {activityName}...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"\nGood job! You have completed this activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int duration)
    {
        char[] spinChars = { '-', '\\', '|', '/' };
        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < TimeSpan.FromSeconds(duration))
        {
            foreach (char spinChar in spinChars)
            {
                Console.Write($"\r{spinChar}  ");
                Thread.Sleep(100);
            }
        }
    }

    protected void CountdownTimer(int remainingTime)
    {
        while (remainingTime > 0)
        {
            Console.Write($"\rCountdown: {remainingTime} seconds");
            Thread.Sleep(1000);
            remainingTime--;
        }
        Console.WriteLine("\rCountdown: 0 seconds");
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public new void StartActivity()
    {
        ShowSpinner(3);

        Console.WriteLine("\nGet ready to start breathing...");

        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < TimeSpan.FromSeconds(base.duration))
        {
            Console.WriteLine($"\rBreathe in...");
            CountdownTimer(3);
            Console.WriteLine($"\rBreathe out...");
            CountdownTimer(3);
        }

        base.EndActivity();
    }
}

class ReflectionActivity : Activity
{
    private List<string> reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    public new void StartActivity()
    {
        Console.WriteLine("\nGet ready to reflect...");
        ShowSpinner(3);

        Console.WriteLine("\nReflection Activity in progress...");

        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < TimeSpan.FromSeconds(base.duration))
        {
            string randomPrompt = GetRandomPrompt();
            Console.WriteLine($"\r{randomPrompt}");
            ShowSpinner(3);

            AskReflectionQuestions();
        }

        base.EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(reflectionPrompts.Count);
        return reflectionPrompts[index];
    }

    private void AskReflectionQuestions()
    {
        Random random = new Random();
        int numberOfQuestionsToShow = 2;
        List<string> selectedQuestions = reflectionQuestions.OrderBy(q => random.Next()).Take(numberOfQuestionsToShow).ToList();

        foreach (string question in selectedQuestions)
        {
            Console.WriteLine($"\r{question}");
            ShowSpinner(3);
        }
    }
}

class ListingActivity : Activity
{
    private List<string> listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public new void StartActivity()
    {
        Console.WriteLine("\nGet ready to list...");

        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"\r{randomPrompt}");
        CountdownTimer(5);

        Console.WriteLine("\nListing Activity in progress...");

        List<string> itemsListed = ListItems();

        Console.WriteLine($"\nYou listed {itemsListed.Count} items:");

        foreach (string item in itemsListed)
        {
            Console.WriteLine(item);
        }

        base.EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(listingPrompts.Count);
        return listingPrompts[index];
    }

    private List<string> ListItems()
    {
        List<string> itemsListed = new List<string>();
        DateTime startTime = DateTime.Now;

        while (DateTime.Now - startTime < TimeSpan.FromSeconds(base.duration))
        {
            Console.Write("\rList an item: ");
            string listItem = Console.ReadLine();
            itemsListed.Add(listItem);
        }

        return itemsListed;
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nActivities Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Select an activity (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity();
                    break;
                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}