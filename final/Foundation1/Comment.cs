public class Comment
{
    private string _user { get; set; }
    private string _comment { get; set; }
    public Comment(string user, string comment)
    {
        _user = user;
        _comment = comment;
    }
    public string GetUser()
    {
        return _user;
    }
    public string GetComment()
    {
        return _comment;
    }
}