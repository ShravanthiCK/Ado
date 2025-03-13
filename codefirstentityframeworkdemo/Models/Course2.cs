namespace codefirstentityframeworkdemo.Models
{
    public class Course2
    {
        public int Id { set; get; }// not an identity column 


        public string Title { set; get; }


        public string Description { set; get; }


        public float fullprice { set; get; }


        public int Author2Id { set; get; }

        public Author2 Author { set; get; }
    }
}
