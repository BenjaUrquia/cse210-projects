using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        JournalEntry entry1 = new JournalEntry("2024-01-20", "Question 1", "Answer 1");
        JournalEntry entry2 = new JournalEntry("2024-01-21", "Question 2", "Answer 2");

        journal.AddEntry(entry1);
        journal.AddEntry(entry2);

        Console.WriteLine("Displaying all entries:\n");
        journal.DisplayAll();

        Console.WriteLine("Displaying entry at index 0:\n");
        journal.DisplayEntry(0);
    }
}