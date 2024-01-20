using System;
using System.Collections.Generic;
public class Journal
{
    private List<JournalEntry> _entries;

    public Journal()
    {
        _entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    public void DisplayEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries[index].Display();
        }
        else
        {
            Console.WriteLine("Invalid entry index.");
        }
    }
}
