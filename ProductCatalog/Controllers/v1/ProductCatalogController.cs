using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ProductCatalog.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class ProductCatalogController : ControllerBase
{
    List<Product> products = new();
    public ProductCatalogController()
    {
        products.AddRange(new[] {
            new Product() { Id = 1, Sku="Sku1", Name = "Product 1", Description="Product 1", Cost=10, Category="Category 1", CategoryId=1, NumberInStock=100 },
            new Product() { Id = 2, Sku="Sku2", Name = "Product 2", Description="Product 2", Cost=20, Category="Category 1", CategoryId=2, NumberInStock=200 },
            new Product() { Id = 3, Sku="Sku3", Name = "Product 3", Description="Product 3", Cost=30, Category="Category 2", CategoryId=3, NumberInStock=300 },
            new Product() { Id = 4, Sku="Sku4", Name = "Product 4", Description="Product 4", Cost=40, Category="Category 3", CategoryId=4, NumberInStock=400 },
            new Product() { Id = 5, Sku="Sku5", Name = "Product 5", Description="Product 5", Cost=50, Category="Category 4", CategoryId=5, NumberInStock=500 },
            new Product() { Id = 6, Sku="Sku6", Name = "Product 6", Description="Product 6", Cost=60, Category="Category 4", CategoryId=6, NumberInStock=600 }
        });
    }

    [HttpGet("AllProducts")]
    public ActionResult<IEnumerable<Product>> AllProducts()
    {
        return Ok(products);
    }
    [HttpGet("ById/{id}")]
    public ActionResult<Product> ById(int id)
    {
        var product = products.Where(p => p.Id == id).First();
        return Ok(product);
    }
    [HttpGet("BySku/{sku}")]
    public ActionResult<Product> BySku(string sku)
    {
        var product = products.Where(p => p.Sku.ToUpper() == sku.ToUpper()).FirstOrDefault();
        return Ok(product);
    }
    [EnableQuery]
    [HttpGet("Search")]
    public ActionResult<IQueryable<Product>> Search() {
        var resultSearch = products.Where(p => p.NumberInStock > 0);
        return Ok(products);
    }
}
public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
    public string? Category { get; set; }
    public int CategoryId { get; set; }
    public int NumberInStock { get; set; }
}
