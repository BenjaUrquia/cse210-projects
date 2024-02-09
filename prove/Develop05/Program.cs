using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Name { get; protected set; }
        public int Value { get; protected set; }
        public int CurrentProgress { get; protected set; }
        public bool Completed { get; set; }

        public abstract bool IsCompleted();

        public virtual void RecordEvent()
        {
            CurrentProgress++;
        }
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override bool IsCompleted()
        {
            return Completed;
        }

        public override void RecordEvent()
        {
            if (!Completed)
            {
                base.RecordEvent();
                Completed = true;
                Program.Score += Value;
            }
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override bool IsCompleted()
        {
            return false;
        }

        public override void RecordEvent()
        {
            base.RecordEvent();
            Program.Score += Value;
        }
    }

    class ChecklistGoal : Goal
    {
        public int TargetProgress { get; private set; }

        public ChecklistGoal(string name, int value, int targetProgress, int currentProgress) : base()
        {
            Name = name;
            Value = value;
            TargetProgress = targetProgress;
            CurrentProgress = currentProgress;
        }

        public override bool IsCompleted()
        {
            return CurrentProgress >= TargetProgress;
        }

        public override void RecordEvent()
        {
            base.RecordEvent();
            if (CurrentProgress < TargetProgress)
            {
                Program.Score += Value;
            }
            else if (CurrentProgress == TargetProgress)
            {
                Program.Score += Value * 10;
            }
            else
            {
                Program.Score += 0;
            }
        }
    }

    class Program
    {
        public static int Score { get; set; }
        private static List<Goal> goals = new List<Goal>();

        static void Main(string[] args)
        {
            LoadGoals();
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save Goals and Exit");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ViewGoals();
                    break;
                case 2:
                    AddNewGoal();
                    break;
                case 3:
                    RecordEvent();
                    break;
                case 4:
                    ViewScore();
                    break;
                case 5:
                    SaveGoals();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            DisplayMenu();
        }

        static void ViewGoals()
        {
            Console.WriteLine("Goals:");
            int index = 1;
            foreach (var goal in goals)
            {
                string status;
                if (goal is ChecklistGoal checklistGoal)
                {
                    status = goal.IsCompleted() ? "[X]" : $"[ ] ({goal.CurrentProgress}/{checklistGoal.TargetProgress})";
                }
                else if (goal is SimpleGoal simpleGoal)
                {
                    status = simpleGoal.Completed ? "[X]" : "[ ]";
                }
                else
                {
                    status = goal.IsCompleted() ? "[X]" : "[ ]";
                }
                Console.WriteLine($"{index++}. {status} {goal.Name}");
            }
            Console.WriteLine();
        }

        static void AddNewGoal()
        {
            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal value: ");
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. Eternal");
            Console.WriteLine("3. Checklist");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    goals.Add(new SimpleGoal(name, value));
                    break;
                case 2:
                    goals.Add(new EternalGoal(name, value));
                    break;
                case 3:
                    Console.Write("Enter target progress: ");
                    int targetProgress = int.Parse(Console.ReadLine());
                    Console.Write("Enter current progress: ");
                    int currentProgress = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, value, targetProgress, currentProgress));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("Goal added successfully.\n");
        }

        static void RecordEvent()
        {
            Console.WriteLine("Select the goal to record event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice >= 1 && choice <= goals.Count)
            {
                Goal selectedGoal = goals[choice - 1];
                selectedGoal.RecordEvent();
                Console.WriteLine("Event recorded successfully.\n");

                ViewGoals();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine();
            }
        }

        static void ViewScore()
        {
            Console.WriteLine($"Current Score: {Score}\n");
        }

        static void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                foreach (var goal in goals)
                {
                    if (goal is SimpleGoal simpleGoal)
                    {
                        writer.WriteLine($"{goal.Name},{goal.Value},{goal.CurrentProgress},{simpleGoal.Completed},{0}");
                    }
                    else
                    {
                        writer.WriteLine($"{goal.Name},{goal.Value},{goal.CurrentProgress},{goal.Completed},{(goal is ChecklistGoal ? ((ChecklistGoal)goal).TargetProgress : 0)}");
                    }
                }
                writer.WriteLine($"Score,{Score}");
            }
            Console.WriteLine("Goals saved successfully.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 5) // Ensure there are enough parts
                        {
                            string name = parts[0];
                            int value = int.Parse(parts[1]);
                            int currentProgress = int.Parse(parts[2]);
                            bool completed = bool.Parse(parts[3]);
                            int targetProgress = int.Parse(parts[4]);
                            if (targetProgress > 0)
                            {
                                goals.Add(new ChecklistGoal(name, value, targetProgress, currentProgress) { Completed = completed });
                            }
                            else
                            {
                                if (currentProgress == 0)
                                {
                                    goals.Add(new SimpleGoal(name, value) { Completed = completed });
                                }
                                else
                                {
                                    goals.Add(new EternalGoal(name, value) { Completed = completed });
                                }
                            }
                        }
                    }
                }
                Score = int.Parse(File.ReadLines("goals.txt").ReadLastLine().Split(',')[1]);
            }
        }
    }

    public static class Extensions
    {
        public static string ReadLastLine(this IEnumerable<string> source)
        {
            string line = null;
            foreach (string item in source)
            {
                line = item;
            }
            return line;
        }
    }
}