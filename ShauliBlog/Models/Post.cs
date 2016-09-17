using System;
using System.Collections.Generic;

namespace ShauliBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorWebsite { get; set; }
        public DateTime PublishDate { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}