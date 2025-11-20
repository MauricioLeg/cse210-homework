public class Comment
{
    private string _commenterName;
    private string _comment;

    public Comment(string commentText, string commenterName)
    {
        _commenterName = commenterName;
        _comment = commentText;
    }

    public string GetDisplayText()
    {
        return $"{_comment} - {_commenterName}";
    }
}