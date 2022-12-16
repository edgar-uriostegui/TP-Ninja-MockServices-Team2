namespace ProductCatalogService.Domain.Models;
/// <summary>
/// Product entity
/// </summary>
public class ProductEntity
{
    /// <summary>
    /// Id product
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// Stock Keeping Unit 
    /// </summary>
    public string Sku { get; private set; }
    /// <summary>
    /// Name product
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Description product
    /// </summary>
    public string Description { get; private set; }
    /// <summary>
    /// Cost product
    /// </summary>
    public decimal Cost { get; private set; }
    /// <summary>
    /// Category product
    /// </summary>
    public string Category { get; private set; }
    /// <summary>
    /// Quantity product
    /// </summary>
    public int NumberInStock { get; private set; }
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sku"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="cost"></param>
    /// <param name="category"></param>
    /// <param name="numberInStock"></param>
    public ProductEntity(int id, string sku, string name, string description, decimal cost, string category, int numberInStock)
    {
        Id = id;
        Sku = sku;
        Name = name;
        Description = description;
        Cost = cost;
        Category = category;
        NumberInStock = numberInStock;
    }
}
