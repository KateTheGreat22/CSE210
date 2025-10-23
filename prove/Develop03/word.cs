using System.Dynamic;

class Word
{
    //attributes

    private string _word;
    private bool _shown;
    //behaviors

    public Word(string words) //constructer
    {
        _word = words;
        _shown = true;
    }

    public void Display()
    {
        if (_shown)
        {
            Console.Write(" " + _word);
        }

        else
        {
            Console.Write(" ___");
        }

    }

    public void Hide() //setter
    {
        _shown = false;
    }

    public bool IsRevealed() // this is a getter
    {
        return _shown;
    }
}
