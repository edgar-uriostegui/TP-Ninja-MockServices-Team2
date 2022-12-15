using ProductCatalog.Models;

namespace ProductCatalog.Data;

public class ProductStore
{
    public static List<Product> products = new()
    {
        new Product(1, "Sku1", "Product 1", "Product 1", 10, "Category 1", 1, 100),
        new Product(2, "Sku2", "Product 2", "Product 2", 20, "Category 1", 2, 200),
        new Product(3, "Sku3", "Product 3", "Product 3", 30, "Category 2", 3, 300),
        new Product(4, "Sku4", "Product 4", "Product 4", 40, "Category 3", 4, 400),
        new Product(5, "Sku5", "Product 5", "Product 5", 50, "Category 4", 5, 500),
        new Product(6, "Sku6", "Product 6", "Product 6", 60, "Category 4", 6, 600)
    };
}
