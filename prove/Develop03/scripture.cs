class Scripture
{
    private Reference _reference;
    private string _scripture;
    private Word[] _words;

    public Scripture(Reference reference, string scripture)
    {
        _reference = reference;
        _scripture = scripture;
        
        string[] parts = _scripture.Split(' ');
        _words = new Word[parts.Length];
        
        for (int i = 0; i < parts.Length; i++)
        {
            _words[i] = new Word(parts[i]);
        }
    }

    public void DisplayWithReference()
    {
        _reference.ReferenceDisplay();
        Console.WriteLine();
        Display();
    }

    public void Display()
    {
        foreach (Word word in _words)
        {
            word.Display();
        }
        Console.WriteLine(); 
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        
        while (true)
        {
            int randomIndex = random.Next(_words.Length);
            
            if (_words[randomIndex].IsRevealed())
            {
                _words[randomIndex].Hide();
                return; 
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsRevealed())
            {
                return false;
            }
        }
        return true;
    }
}
