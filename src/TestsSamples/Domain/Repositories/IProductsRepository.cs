using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductsRepository
    {
        public void Add(Product product);

        public void Update(Product product);

        public Product Get(int id);


    }
}
