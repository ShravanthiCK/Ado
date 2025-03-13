namespace EntityFrameworkDemo1.Models
{
    public class CustomerRange
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; } = string.Empty;

        public int? orderscount { get; set; }

    }
}
