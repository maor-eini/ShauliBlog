namespace ShauliBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string WriterWebsite { get; set; }
        public string Text { get; set; }
        public Post Post { get; set; }
    }
}