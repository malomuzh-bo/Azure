namespace hw1403.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
