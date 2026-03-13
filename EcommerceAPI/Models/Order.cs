namespace EcommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; } = new();
    }
}
