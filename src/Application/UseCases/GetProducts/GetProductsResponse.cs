using System.Collections.Generic;

namespace Project.Application.UseCases.GetProducts
{
    public class GetProductsResponse
    {
        public List<ProductDto> Products { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}