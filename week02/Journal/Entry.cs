using System;

public class Entry
{
    DateTime theCurrentTime;
    public string dateText;
    public string prompt;
    public string userAnswer;
    public Entry()
    {
        theCurrentTime = DateTime.Now;
        dateText = theCurrentTime.ToShortDateString();
    }
}