namespace BTTLDay03.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product> GetProductsList()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/a1.jpg",
                },
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/a1.jpg",
                },
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/a1.jpg",
                },
            };
            return products;
        }
    }
}
