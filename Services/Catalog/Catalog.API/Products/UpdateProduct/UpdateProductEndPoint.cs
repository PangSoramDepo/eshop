
namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Categories, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/{id}", async (Guid Id, UpdateProductRequest request, ISender sender) =>
            {
                var requestWithId = request with { Id = Id };
                var command = requestWithId.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();
                return Results.Ok(response);
            })
                .WithName("UpdateProduct")
                .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Update Product")
                .WithDescription("Update Product");
        }
    }
}
