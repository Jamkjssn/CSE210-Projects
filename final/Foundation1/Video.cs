using System.Reflection.Metadata;

class Video
{
    private string _title { get; set; }
    private string _author { get; set; }
    private int _length { get; set; }
    private List<Comment> _comments { get; set; }
    public Video(string title, string author, int length, List<Comment> commentsList)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new();
        _comments = commentsList;
    }
    public int GetCommentCount()
    {
        return _comments.Count();
    }
    public void DisplayVideoInfo()
    {
        int numComments = GetCommentCount();
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Number of comments: {numComments}");
        Console.WriteLine($"\nVideo Comments:");

        int index = 1;
        foreach (Comment comment in _comments)
        {
            string user = comment.GetUser();
            string commentText = comment.GetComment();
            Console.WriteLine($"Comment #{index}");
            Console.WriteLine($"\tUser: {user}");
            Console.WriteLine($"\tComment: {commentText}\n");
            index++;
        }
    }
}