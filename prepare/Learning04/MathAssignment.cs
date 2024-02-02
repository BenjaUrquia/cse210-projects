public class MathTask : Task
{
    private string _textbookSection;
    private string _problems;

    public MathTask(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetTaskDetails()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}