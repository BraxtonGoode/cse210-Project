using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endverse;
    

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = endVerse;
    }


    public string GetDisplayText()
    {
        string text;

        if (_endverse == 0)
        {
            text = $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            text = $"{_book} {_chapter}:{_verse} - {_endverse}";
        }
        
        return text;
    }

}