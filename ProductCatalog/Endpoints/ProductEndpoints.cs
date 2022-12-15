using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Endpoints;

public static class ProductEndpoints
{
    public static void ConfigureProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/productCatalog/AllProducts", () => Results.Ok(ProductStore.products));
        app.MapGet("/api/v1/productCatalog/ById/{id:int}", (int id) => Results.Ok(ProductStore.products.Where(p => p.Id == id).First()));
        app.MapGet("/api/v1/productCatalog/BySku/{sku}", (string sku) => Results.Ok(ProductStore.products.Where(p => p.Sku.ToUpper() == sku.ToUpper()).FirstOrDefault()));
        app.MapPost("/api/v1/productCatalog/Search", SearchProducts);
    }
    private static IResult SearchProducts(Product product)
    {
        var result = ProductStore.products.Where(
        p => (p.Id == product.Id)
        || (p.Sku == product.Sku)
        || (p.Name == product.Name)
        || (p.Description == product.Description)
        || (p.Cost == product.Cost)
        || (p.Category == product.Category)
        || (p.CategoryId == product.CategoryId)
        && (p.NumberInStock > 0)
        );
        return Results.Ok(result);
    }
}
