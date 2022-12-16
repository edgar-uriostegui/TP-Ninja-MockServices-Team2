using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.EndPoints
{
    public static class OrderEndPoints
    {
        public static void ConfigureOrderEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/orderService/create", (Order orderRequest) =>
            {
                //return Results.Created($"/v1/OrderService/create/{createOrderRequest.Id}", createOrderRequest);
                return Results.Ok(createOrderRequest(orderRequest));
            });

            app.MapGet("/v1/orderService/getAll", () => Results.Ok(OrderStore.orders));
        }

        private static IResult createOrderRequest(Order order)
        {
            if (order.ProductId == 0 || string.IsNullOrEmpty(order.Description))
                return Results.BadRequest("Invalid ProductId or Description");

            order.Id = OrderStore.orders.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            OrderStore.orders.Add(order);
            return Results.Ok(order.Id);

            // ToDo
            // Once an order is created the stock of a product should be updated.
            //return Results.Created($"/v1/productCatalog/update/{order.ProductId}", order);
        }
    }
}
