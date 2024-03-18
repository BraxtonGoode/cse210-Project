using System;

public class WritingAssignment : Assignment
{
    private string _title = "";
   

    public WritingAssignment(string _studentName, string _topic, string title) : base(_studentName,_topic)
    {
        _title = title;
     
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudenName(); 

        return $"{_title} by {studentName}";
    }


}