using System;

public class WritingAssignment : Assignment
{
    private string _writingInformation;

    public WritingAssignment(string studentName, string topic, string writingInformation)
        : base(studentName, topic)
    {
        _writingInformation = writingInformation;
    }

    public string GetWritingInformation()
    {
        string _studentName = GetStudentName();
        
        return $"{base.GetSummary()} by {_studentName}\n{_writingInformation}";
    }
}
