using Domain.Entities;
using Domain.Repositories;

namespace Domain.CommandHandlers;

public class AddProductCommandHandler
{
    private static IProductsRepository ProductsRepository;

    public AddProductCommandHandler(IProductsRepository productsRepository)
    {
        ProductsRepository = productsRepository;
    }


    public (bool Sucess, string Message) Handle(Product product)
    {
        //some validations 

        if(string.IsNullOrEmpty(product.Name))
        {
            return (false, "Field Name is empty");
        }

        ProductsRepository.Add(product);

        return (true, "Sucess");

    }
}
