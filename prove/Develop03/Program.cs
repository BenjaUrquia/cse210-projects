using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Content { get; }

    public Word(string content)
    {
        Content = content;
    }

    public bool IsHidden { get; set; }
}

class ScriptureReference
{
    public string Reference { get; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

class Scripture
{
    private List<Word> words;
    private ScriptureReference reference;
    private Random random;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        random = new Random();
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');
        words = wordArray.Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference.Reference}:");
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "___ " : word.Content + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        ScriptureReference reference = new ScriptureReference("John 3:16");
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            Console.Clear();
        }
    }
}