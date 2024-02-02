public class Task
{
    private string _studentName;
    private string _topic;

    public Task(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public string GetOverview()
    {
        return $"{_studentName} - {_topic}";
    }
}
