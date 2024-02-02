public class WritingTask : Task
{
    private string _title;

    public WritingTask(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingDetails()
    {
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}