using WedStoreApp.Entities;

namespace WebStoreAppRepositories
{
    public interface IProductRepositories
    {
        List<Product> GetAllProduct();
        Product? GetProductById(int id);
        bool AddProduct(Product product);
    }
}