using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace codefirstentityframeworkdemo.Models
{
    public class Course1
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }// not an identity column 

        [Required]
        [Column("Stitle", TypeName = "varchar")]
        public string Title { set; get; }

        [Required]
        [MaxLength(220)]
        public string Description { set; get; }


        public float fullprice { set; get; }


        [ForeignKey("Author")]
        public int AuthorId { set; get; }

        public Author1 Author { set; get; }

    }
}
