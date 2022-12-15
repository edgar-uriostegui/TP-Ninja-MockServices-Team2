namespace ProductCatalog.Models;

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public string Category { get; set; }
    public int CategoryId { get; set; }
    public int NumberInStock { get; set; }

    public Product()
    {

    }

    public Product(int id, string sku, string name, string description, decimal cost, string category, int categoryId, int numberInStock)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Description = description;
        Cost = cost;
        Category = category;
        CategoryId = categoryId;
        NumberInStock = numberInStock;
    }
}
