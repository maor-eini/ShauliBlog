using System.ComponentModel.DataAnnotations;

namespace ShauliBlog.ViewModels
{
    public class CommentFormViewModel
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        [Required]
        [StringLength(30)]
        public string Writer { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }

        [Required]
        public string WriterWebsite { get; set; }
    }
}
