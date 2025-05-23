namespace AcunmedyaAkademiProject3.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            CategoryName = string.Empty;
            Products = new List<Product>();
        }
    }
}