public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private readonly Random _rng = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        
        string[] wordsArray = text.Split(' ');

        foreach (string word in wordsArray)
        {
            Word wordObject = new Word(word);
            _words.Add(wordObject);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int requested = Math.Max(0, Math.Min(numberToHide, 3));
        List<int> available = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                available.Add(i);
            }
        }
        
        if (requested == 0 || available.Count == 0)
        {
            return;
        }
        int toHide = Math.Min(requested, available.Count);
        for (int i = 0; i < toHide; i++)
        {
            int j = _rng.Next(i, available.Count);
            (available[i], available[j]) = (available[j], available[i]);
        }

        for (int k = 0; k < toHide; k++)
        {
            _words[available[k]].Hide();
        }
    }
    public string GetDisplayText()
    {
        var parts = new List<string>(_words.Count);
        foreach(var w in _words)
        {
            parts.Add(w.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()} {string.Join(" ", parts)}";
    }
    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}