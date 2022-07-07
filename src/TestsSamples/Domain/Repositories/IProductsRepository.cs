using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductsRepository
    {
        public void Add(Product product);
    }
}
