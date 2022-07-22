using Domain.Entities;
using Domain.Repositories;

namespace Domain.CommandHandlers;

public class UpdateProductCommandHandler
{
    private readonly IProductsRepository ProductRepository;

    public UpdateProductCommandHandler(IProductsRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public (bool Success, string Message) Handle(Product product)
    {
        var existingProduct = ProductRepository.Get(product.Id);

        if (existingProduct is null)
        {
            return (false, "Product not found");
        }
        
        existingProduct.Name = product.Name;

        ProductRepository.Update(existingProduct);

        return (true, "Success");
    }

}
