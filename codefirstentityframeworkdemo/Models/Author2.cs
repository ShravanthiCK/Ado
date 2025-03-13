namespace codefirstentityframeworkdemo.Models
{
    public class Author2
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public IList<Course2> Courses { set; get; }
    }
}
