using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace codefirstentityframeworkdemo.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }
        [Required]
        public DateTime DatePublished { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string Body { set; get; }
    }
}
