public class JournalEntry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public JournalEntry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"{_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n");
    }
}
