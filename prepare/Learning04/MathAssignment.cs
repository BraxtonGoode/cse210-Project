using System;

public class MathAssignment : Assignment
{
    private string _textBookSection = "";
    private string _problems = "";

    public MathAssignment(string _studentName, string _topic, string textBookSection, string problems) : base(_studentName,_topic)
    {
        _textBookSection = textBookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textBookSection} Problems {_problems}";
    }


}