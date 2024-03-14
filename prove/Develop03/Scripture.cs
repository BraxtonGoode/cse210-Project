using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] WordsArray = text.Split(' ');
        foreach (string wordText in WordsArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
            
        }
       
    
        
   
    }

    public void HideRandomWords(int numToHide)
    {
      Random random = new Random();
        for (int i = 0; i < numToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
        
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim(); // Trim to remove extra space at the end
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}