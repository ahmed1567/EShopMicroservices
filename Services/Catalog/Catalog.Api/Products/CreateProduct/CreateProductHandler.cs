using System.Threading;
using System.Threading.Tasks;
namespace Catalog.Api.Products.CreateProduct;

using BuildingBlocks.CQRS;
using Catalog.Api.Models;

// Command
public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category, string ImageFile)
: ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);


// Handler
internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{


    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            ImageFile = command.ImageFile,
            Category = command.Category
        };

        return new CreateProductResult(product.Id);
    }
}