namespace Project.Domain.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Product(){}

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}