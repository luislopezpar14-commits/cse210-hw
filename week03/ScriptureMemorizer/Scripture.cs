using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        // Constructor will split text into Word objects and populate _words
    }

    public void HideRandomWords(int numberToHide)
    {
    }

    public string GetDisplayText()
    {
        return string.Empty;
    }

    public bool IsCompletelyHidden()
    {
        return false;
    }
}