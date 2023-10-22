public class Word
{
    public string theWord { get; set; }
    public bool isHidden { get; set; }
    public string hidden { get; set; }
    public string shown { get; set; }
    public Word(string word)
    {
        theWord = word;
        shown = word;
        isHidden = false;
        int wordlength = theWord.Length;
        for (int i = 0; i < wordlength; i++)
        {
            hidden = $"{hidden}_";
        }
    }
    public void ToggleHidden()
    {
        if (isHidden == true)
        {
            shown = theWord;
            isHidden = false;
        }
        else
        {
            shown = hidden;
            isHidden = true;
        }
    }
}