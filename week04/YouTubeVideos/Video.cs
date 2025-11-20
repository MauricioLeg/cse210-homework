public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void GetDisplayText()
    {

        Console.WriteLine($"{_title} - {_author}: {_length} seconds");
        Console.WriteLine($"Comments ({_comments.Count()} comments):");
        for (int i=0; i < _comments.Count(); i++)
        {
            Console.WriteLine(_comments[i].GetDisplayText());
        }
    }
}