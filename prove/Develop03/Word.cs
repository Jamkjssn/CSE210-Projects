public class Word
{
    private string _theWord { get; set; }
    private bool isHidden { get; set; }
    private string _hidden { get; set; }
    private string _shown { get; set; }
    public Word(string word)
    {
        _theWord = word;
        _shown = word;
        isHidden = false;
        int wordlength = _theWord.Length;
        for (int i = 0; i < wordlength; i++)
        {
            _hidden = $"{_hidden}_";
        }
    }
    public void ToggleHidden()
    {
        if (isHidden == true)
        {
            _shown = _theWord;
            isHidden = false;
        }
        else
        {
            _shown = _hidden;
            isHidden = true;
        }
    }
    public void PrintShown()
    {
        Console.Write($"{_shown} ");
    }
    public bool IsWordHidden()
    {
        return isHidden;
    }
}